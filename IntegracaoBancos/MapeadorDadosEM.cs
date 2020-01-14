using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoBancos
{
    class MapeadorDadosEM
    {
        public bool ConsultaAluno(int matricula)
        {
            string SqlConsulta = $"SELECT ALUNMATRICULA FROM TBALUNO WHERE ALUNMATRICULA = {matricula};";
            var cmd = SqlCommand(SqlConsulta);

            using (var dr = SqlConsulta.ExecuteReader())
            {
                while (dr.Read())
                {
                    registroEntradas.Add(new RegistroEntrada
                    {
                        Id = dr.GetInt32(0),
                        Matricula = dr.GetInt32(1),
                        Horario = dr.GetDateTime(2),
                        Sentido = dr.GetInt32(3)
                    });
                }
            }
            return false;
        }
        private FbConnection SqlConecao()
        {
            var configuracao = new LeituraConfiguração().lerConfiguracao();
            string stringdeConecao = $@"DataSource=localhost; Database={configuracao.localizacaoEM}; username=sysdba; password =masterkey";
            string connectionString = stringdeConecao;
            return new FbConnection(connectionString);
        }
    }
}
