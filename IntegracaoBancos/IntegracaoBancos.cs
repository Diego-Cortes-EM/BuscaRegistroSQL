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
                    SubMain();
                    Console.WriteLine($"Valor a ser puchado :{ControleData}");
                    ControleData = ControleData.AddMinutes(1);
                }
            }
        }

        private static void SubMain()
        {
            var ultimoRegistro = new UltimoRegistro();
            var appSettings = ConfigurationManager.AppSettings;
            var configuracaoServidores = principalmain(appSettings);
            var stringConexao = new UltilitariosStringConexao(configuracaoServidores);
            var mapeadorDadosEM = new MapeadorDadosEM(stringConexao.StringBancoFBC());
            var mapeadorDadosSql = new MapeadorDadosSql(stringConexao.StringBancoSQL());

            new ProcessoEntradaBancoEM().BuscarPorUltimoRegistro(mapeadorDadosSql, mapeadorDadosEM, ultimoRegistro);

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
