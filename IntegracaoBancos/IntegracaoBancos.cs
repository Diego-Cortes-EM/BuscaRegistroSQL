using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace IntegracaoBancos
{
    class IntegracaoBancos
    {
        [STAThread]
        static void Main(string[] args)
        {
            int idUltimoAlunoBuscado = new LeituraConfiguração().lerRegistro();
            var ControleData = DateTime.Now;
            var InserirDados = new MapeadorDadosEM();
            while (true)
            {
                var ehMaior = DateTime.Compare(ControleData, DateTime.Now);
                if (ehMaior < 0)
                {
                    Console.WriteLine($"Valor a ser puchado :{ControleData}");
                    ControleData = ControleData.AddMinutes(1);
                    var DadosBuscados = new MapeadorDadosSql();
                    List<RegistroEntrada> registroEntradas = DadosBuscados.BuscaRegistroDoDia(idUltimoAlunoBuscado);
                    if (registroEntradas.Count != 0)
                    {
                        foreach (var registro in registroEntradas)
                        {
                            if (registro.Equals(registroEntradas.Last()))
                            {
                                idUltimoAlunoBuscado = registro.Id;
                                new LeituraConfiguração().UltimoRegistro(registro.Id);
                            }
                            if (InserirDados.ConsultaAluno(registro.Matricula.Value))
                            {
                                InserirDados.RegistraEntrada(registro);
                            }
                            char? sentido;
                            if (registro.Sentido == 1)
                            {
                                sentido = 'E';
                            }
                            else
                            {
                                if (registro.Sentido == 2)
                                {
                                    sentido = 'S';
                                }
                                else
                                {
                                    sentido = null;
                                }
                            }
                            var nulo = sentido == null? "nao tem entrada" : sentido.ToString();
                            Console.WriteLine($"{registro.Id} - {registro.Matricula} - {registro.Horario.ToString()} - {nulo} ");
                        }
                    }
                }
            }
        }
    }
}
