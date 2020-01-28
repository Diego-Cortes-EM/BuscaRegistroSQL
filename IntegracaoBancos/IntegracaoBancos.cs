using IntegracaoBancos.Configuracao;
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace IntegracaoBancos
{
    public class IntegracaoBancos
    {
        public static void Main()
        {
            var ControleData = DateTime.Now;
            while (true)
            {
                var ehMaior = DateTime.Compare(ControleData, DateTime.Now);
                if (ehMaior < 0)
                {
                    new Integracao().Submain();
                    Console.WriteLine($"Valor a ser puchado :{ControleData}");
                    ControleData = ControleData.AddMinutes(1);
                }
            }
        }
    }
}
