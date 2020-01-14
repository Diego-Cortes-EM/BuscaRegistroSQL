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
        private FbConnection SqlConecao()
        {
            var configuracao = new LeituraConfiguração().lerConfiguracao();
            string stringdeConecao = $@"DataSource=localhost; Database={configuracao.localizacaoEM}; username=sysdba; password =masterkey";
            string connectionString = stringdeConecao;
            return new FbConnection(connectionString);
        }

        public bool ConsultaAluno(int matricula)
        {
            string SqlConsulta = $"SELECT ALUNMATRICULA FROM TBALUNO WHERE ALUNMATRICULA = {matricula};";
            using (var conn = SqlConecao())
            {
                conn.Open();
                var cmd = new FbCommand(SqlConsulta, conn);
                using (var dr = cmd.ExecuteReader())
                {
                    return dr.HasRows;
                }
            }
        }
        public void RegistraEntrada(RegistroEntrada registroEntrada)
        {
            var sentido = registroEntrada.Sentido == 1 ? 'E' : 'S';

            string comando = "UPDATE INTO TBREGISTROACESSO (REGACMATRICULA, REGACTIPOPESSOA, REGACDIA, REGACHORA, REGACGIRO)" +
                            $"VALUES({registroEntrada.Matricula}, 1, {tranformaData(registroEntrada.Horario)}, '{tranformahora(registroEntrada.Horario)}','{sentido}'); ";
            using (var conn = SqlConecao())
            {
                conn.Open();
                var cmd = new FbCommand(comando, conn);

                if(cmd.ExecuteNonQuery() == 0)
                {
                    cmd.CommandText = "UPDATE INTO TBREGISTROACESSO (REGACMATRICULA, REGACTIPOPESSOA, REGACDIA, REGACHORA, REGACGIRO)" +
                            $"VALUES({registroEntrada.Matricula}, 1, {tranformaData(registroEntrada.Horario)}, '{tranformahora(registroEntrada.Horario)}','{sentido}'); ";
                    
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }

        }

        private string tranformahora(DateTime horario)
        {
            return $"{horario.Hour}:{horario.Minute}:{horario.Second}";
        }

        private string tranformaData(DateTime horario)
        {
            var aux = $"{horario.Year}{horario.Month}{horario.Day}";
            return $"{horario.Year}{horario.Month}{horario.Day}";
        }
    }
}
