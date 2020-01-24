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
            var ControleData = DateTime.Now;
            while (true)
            {
                var ehMaior = DateTime.Compare(ControleData, DateTime.Now);
                if (ehMaior < 0)
                {
                    Console.WriteLine($"Valor a ser puchado :{ControleData}");
                    ControleData = ControleData.AddMinutes(1);
                    new ProcessoEntradaBancoEM().BuscarPorUltimoRegistro();
                }
            }
        }
    }
}
