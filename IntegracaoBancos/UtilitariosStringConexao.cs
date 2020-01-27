using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoBancos
{
    public class UltilitariosStringConexao
    {
        ConfiguracaoServidores _configuracaoServidores;

        public UltilitariosStringConexao(ConfiguracaoServidores configuracaoServidores)
        {
            _configuracaoServidores = configuracaoServidores;
        }

        public string StringBancoSQL()
        {
            var stringSql = new SqlConnectionStringBuilder
            {
                DataSource = $"{_configuracaoServidores.nomeServidor}",
                InitialCatalog = $"{_configuracaoServidores.nomeBanco}",
                UserID = $"{_configuracaoServidores.usuario}",
                Password = $"{_configuracaoServidores.senha}",
                IntegratedSecurity = false
            };
            return stringSql.ToString();
        }
        public string StringBancoFBC()
        {
            return $@"DataSource=localhost; Database={_configuracaoServidores.localizacaoEM}; username=sysdba; password =masterkey";
        }
    }
}
