using System;
using System.Collections.Specialized;
using System.Configuration;

namespace IntegracaoBancos
{
    class IntegracaoBancos
    {
        [STAThread]
        static void Main(string[] args)
        {
            var appSettings = ConfigurationManager.AppSettings;
            var configuracaoServidores = principalmain(appSettings);
            var stringConexao = new UltilitariosStringConexao(configuracaoServidores);
            var mapeadorDadosEM = new MapeadorDadosEM(stringConexao.StringBancoFBC());
            var mapeadorDadosSql = new MapeadorDadosSql(stringConexao.StringBancoSQL());

            var ControleData = DateTime.Now;
            while (true)
            {
                var ehMaior = DateTime.Compare(ControleData, DateTime.Now);
                if (ehMaior < 0)
                {
                    Console.WriteLine($"Valor a ser puchado :{ControleData}");
                    ControleData = ControleData.AddMinutes(1);
                    new ProcessoEntradaBancoEM().BuscarPorUltimoRegistro(mapeadorDadosSql, mapeadorDadosEM);
                }
            }
        }

        private static ConfiguracaoServidores principalmain(NameValueCollection appSettings)
        {
            var configuracaoServidor = new ConfiguracaoServidores
            {
                nomeServidor = appSettings.Get("CaminhoServidorSQL"),
                nomeBanco = appSettings.Get("NomeBancoSQL"),
                usuario = appSettings.Get("UsuarioBancoSQL"),
                senha = appSettings.Get("SenhaBancoSQL"),
                localizacaoEM = appSettings.Get("CaminhoServidorFBC")
            };
            return configuracaoServidor;

        }

    }
}
