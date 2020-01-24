using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoBancos
{
    public class MapeadorDadosEM
    {
        private FbConnection SqlConecao()
        {
            var configuracao = new LeituraConfiguração().LerConfiguracao();
            string stringdeConecao = $@"DataSource=localhost; Database={configuracao.localizacaoEM}; username=sysdba; password =masterkey";
            string connectionString = stringdeConecao;
            var cn = new FbConnection(connectionString);
            try
            {
                cn.Open();
            }
            catch (Exception ex)
            {

                throw;
            }

            return cn;
        }

        public bool ConsultaAluno(int matricula)
        {
            string SqlConsulta = $"SELECT ALUNMATRICULA FROM TBALUNO WHERE ALUNMATRICULA = {matricula};";
            using (var conn = SqlConecao())
            {

                var cmd = new FbCommand(SqlConsulta, conn);
                using (var dr = cmd.ExecuteReader())
                {
                    return dr.HasRows;
                }
                conn.Close();
            }
        }
        public void RegistraEntrada(RegistroEntrada registroEntrada)
        {
            char? sentido;
            if (registroEntrada.Sentido == 1)
            {
                sentido = 'E';
            }
            else
            {
                if (registroEntrada.Sentido == 2)
                {
                    sentido = 'S';
                }
                else
                {
                    sentido = null;
                }
            }

            string comando = $"UPDATE TBREGISTROACESSO SET REGACGIRO = '{sentido}'" +
                        $"WHERE REGACMATRICULA = {registroEntrada.Matricula} AND REGACTIPOPESSOA = 1 AND " +
                        $"REGACDIA = {tranformaData(registroEntrada.Horario)} AND REGACHORA = '{tranformahora(registroEntrada.Horario)}'";
            using (var conn = SqlConecao())
            {
                var cmd = new FbCommand(comando, conn);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    cmd.CommandText = "INSERT INTO TBREGISTROACESSO (REGACMATRICULA, REGACTIPOPESSOA, REGACDIA, REGACHORA, REGACGIRO, REGACAUTOMATICO)" +
                            $"VALUES({registroEntrada.Matricula}, 1, {tranformaData(registroEntrada.Horario)}, " +
                            $"'{tranformahora(registroEntrada.Horario)}','{sentido}','S'); ";

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }

        }

        private string tranformahora(DateTime horario)
        {
            var aux = horario.ToString("HH:mm:ss");
            return horario.ToString("HH:mm:ss");
        }

        private string tranformaData(DateTime horario)
        {
            var aux = horario.ToString("yyyyMMdd");
            return horario.ToString("yyyyMMdd");
        }
    }
}
