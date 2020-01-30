using IntegracaoBancos.Configuracao;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntegracaoBancos
{
    public class Integracao
    {
        private NameValueCollection _appSettings;
        private ConfiguracaoServidores _configuracaoServidores;
        private UltilitariosStringConexao _ultilitariosStringConexao;
        private MapeadorDadosEM _mapeadorDadosEM;
        private MapeadorDadosSql _mapeadorDadosSql;
        private ProcessoEntradaBancoEM _processoEntradaBancoEM;

        public Integracao()
        {
            _appSettings = ConfigurationManager.AppSettings;
            _configuracaoServidores = StringDeConfiguracoes(_appSettings);
            _ultilitariosStringConexao = new UltilitariosStringConexao(_configuracaoServidores);
            _mapeadorDadosEM = new MapeadorDadosEM(_ultilitariosStringConexao.StringBancoFBC());
            _mapeadorDadosSql = new MapeadorDadosSql(_ultilitariosStringConexao.StringBancoSQL());
            _processoEntradaBancoEM = new ProcessoEntradaBancoEM();
        }
        public void Submain(int quantidadeSegundos)
        {
            BuscarEhInserirPorDiaRegistro(DateTime.Now);
            while (true)
            {
                BuscarEhInserirPorUltimoRegistro();
                Thread.Sleep(quantidadeSegundos * 1000);
            }

        }
        public void BuscarEhInserirPorUltimoRegistro()
        {
            var registrosBuscados = _processoEntradaBancoEM.BuscarPorUltimosRegistros(_mapeadorDadosSql);
            _processoEntradaBancoEM.InserirRegistro(registrosBuscados, _mapeadorDadosEM);

            if (registrosBuscados.Count() > 0)
                _processoEntradaBancoEM.RegistraUltimoRegistro(registrosBuscados[registrosBuscados.Count - 1]);

        }
        public void BuscarEhInserirPorDiaRegistro(DateTime dateTime)
        {
            var registrosBuscados = _processoEntradaBancoEM.BuscarPorDia(_mapeadorDadosSql, dateTime);
            _processoEntradaBancoEM.InserirRegistro(registrosBuscados, _mapeadorDadosEM);
            Console.WriteLine($"Valor a ser puchado :");
        }
        private static ConfiguracaoServidores StringDeConfiguracoes(NameValueCollection appSettings)
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
