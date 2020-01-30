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
            new Integracao().Submain(5);
        }
    }
}
