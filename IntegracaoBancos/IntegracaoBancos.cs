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
            var leitura = new LeituraConfiguração();
            var teste = leitura.lerConfiguracao();
            int idUltimoAlunoBuscado = 0;
            var ControleData = DateTime.Now;
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
                            }
                            var sentido = registro.Sentido == 1 ? 'E' : 'S';
                            Console.WriteLine($"{registro.Id} - {registro.Matricula} - {registro.Horario.ToString()} - {sentido} ");
                        }
                    }
                }
            }
        }
    }
}
