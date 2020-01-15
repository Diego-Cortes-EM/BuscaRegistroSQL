using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;
using IntegracaoBancos;
using System.Linq;

namespace IntermediadorDeBancos
{
    public partial class ControladorBancos : ServiceBase
    {
        private int eventId = 1;
        private MapeadorDadosEM InserirDados = new MapeadorDadosEM();
        private int idUltimoAlunoBuscado;

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(System.IntPtr handle, ref ServiceStatus serviceStatus);

        public ControladorBancos(string[] args)
        {
            // Update the service state to Start Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

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
            if (!EventLog.SourceExists(eventSourceName))
            {
                EventLog.CreateEventSource(eventSourceName, logName);
            }

            eventLog1.Source = eventSourceName;
            eventLog1.Log = logName;
            // Update the service state to Running.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
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
        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            int idUltimoAlunoBuscado = new LeituraConfiguração().lerRegistro();
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
                    eventLog1.WriteEntry($@"{registro.Id} - {registro.Matricula} - {registro.Horario.ToString()} - {sentido} ", EventLogEntryType.Information, eventId++);
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
    }
}
