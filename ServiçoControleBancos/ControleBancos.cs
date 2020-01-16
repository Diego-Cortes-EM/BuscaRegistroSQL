using IntegracaoBancos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ServicoControleBancos
{
    public partial class ControleBancos : ServiceBase
    {
        private int eventId = 1;


        public ControleBancos(string[] args)
        {
            InitializeComponent();

            string eventSourceName = "MySource";
            string logName = "MyNewLog";

            if (args.Length > 0)
            {
                eventSourceName = args[0];
            }

            if (args.Length > 1)
            {
                logName = args[1];
            }

            eventLog1 = new EventLog();

            if (!EventLog.SourceExists(eventSourceName))
            {
                EventLog.CreateEventSource(eventSourceName, logName);
            }

            eventLog1.Source = eventSourceName;
            eventLog1.Log = logName;

        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("In OnStart.");
            // Set up a timer that triggers every minute.
            Timer timer = new Timer();
            timer.Interval = 60000; // 60 seconds
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();

        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            MapeadorDadosEM InserirDados = new MapeadorDadosEM();
            int idUltimoAlunoBuscado = new LeituraConfiguração().lerRegistro();
            eventLog1.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventId++);
            var DadosBuscados = new MapeadorDadosSql();
            List<RegistroEntrada> registroEntradas = DadosBuscados.BuscaRegistroDoDia(idUltimoAlunoBuscado);
            if (registroEntradas.Count != 0)
            {
                foreach (var registro in registroEntradas)
                {
                    if (registro.Equals(registroEntradas.Last()))
                    {
                        idUltimoAlunoBuscado = registro.Id;
                        new LeituraConfiguração().UltimoRegistro(registro);
                    }
                    if (InserirDados.ConsultaAluno(registro.Matricula))
                    {
                        InserirDados.RegistraEntrada(registro);
                    }
                    var sentido = registro.Sentido == 1 ? 'E' : 'S';
                    Console.WriteLine($"{registro.Id} - {registro.Matricula} - {registro.Horario.ToString()} - {sentido} ");
                }
            }
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In OnStop.");
        }
        protected override void OnContinue()
        {
            eventLog1.WriteEntry("In OnContinue.");
        }
        public enum ServiceState
        {
            SERVICE_STOPPED = 0x00000001,
            SERVICE_START_PENDING = 0x00000002,
            SERVICE_STOP_PENDING = 0x00000003,
            SERVICE_RUNNING = 0x00000004,
            SERVICE_CONTINUE_PENDING = 0x00000005,
            SERVICE_PAUSE_PENDING = 0x00000006,
            SERVICE_PAUSED = 0x00000007,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatus
        {
            public int dwServiceType;
            public ServiceState dwCurrentState;
            public int dwControlsAccepted;
            public int dwWin32ExitCode;
            public int dwServiceSpecificExitCode;
            public int dwCheckPoint;
            public int dwWaitHint;
        };
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(System.IntPtr handle, ref ServiceStatus serviceStatus);
    }
}
