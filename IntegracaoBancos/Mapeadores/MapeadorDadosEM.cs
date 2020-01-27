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
        private string _stringDeConexao;
        private Func<string> stringBancoFBC;

        public MapeadorDadosEM(string stringconexao)
        {
            _stringDeConexao = stringconexao.ToString();
        }

        public bool ConsultaAluno(int matricula)
        {
            string SqlConsulta = $"SELECT ALUNMATRICULA FROM TBALUNO WHERE ALUNMATRICULA = {matricula};";
            using (var conn = new FbConnection(_stringDeConexao))
            {

                var cmd = new FbCommand(SqlConsulta, conn);
                using (var dr = cmd.ExecuteReader())
                {
                    return dr.HasRows;
                }
            }
        }

        public void RegistraEntrada(RegistroEntrada registroEntrada)
        {
            char? sentido = null;
            switch (registroEntrada.Sentido)
            {
                case 1:
                    sentido = 'E';
                    break;
                case 2:
                    sentido = 'S';
                    break;
            }
            string comando = $"UPDATE TBREGISTROACESSO SET REGACGIRO = '{sentido}'" +
                        $"WHERE REGACMATRICULA = {registroEntrada.Matricula} AND REGACTIPOPESSOA = 1 AND " +
                        $"REGACDIA = {registroEntrada.Horario.ToString("yyyyMMdd")} AND REGACHORA = '{registroEntrada.Horario.ToString("HH:mm:ss")}'";
            using (var conn = new FbConnection(_stringDeConexao))
            {
                var cmd = new FbCommand(comando, conn);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    cmd.CommandText = "INSERT INTO TBREGISTROACESSO (REGACMATRICULA, REGACTIPOPESSOA, REGACDIA, REGACHORA, REGACGIRO, REGACAUTOMATICO)" +
                            $"VALUES({registroEntrada.Matricula}, 1, {registroEntrada.Horario.ToString("yyyyMMdd")}, " +
                            $"'{registroEntrada.Horario.ToString("HH:mm:ss")}','{sentido}','S'); ";

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }

        }
    }
}
