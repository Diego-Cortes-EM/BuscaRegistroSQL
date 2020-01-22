using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace IntegracaoBancos
{
    public class MapeadorDadosSql
    {
        public List<RegistroEntrada> BuscaRegistroDoDia(int ultimoAluno)
        {
            var registroEntradas = new List<RegistroEntrada>();
            using (SqlConnection sqlConn = SqlConecao())
            {

                var cmd = new SqlCommand("SELECT [CD_LOG_ACESSO] ,[NU_MATRICULA] ,[NU_DATA_REQUISICAO] ,[TP_SENTIDO_CONSULTA] FROM [dbo].[LOG_ACESSO] " +
                                          $"WHERE [CD_LOG_ACESSO] > {ultimoAluno} ORDER by [CD_LOG_ACESSO]", sqlConn);
                using (var dr = cmd.ExecuteReader())
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

                sqlConn.Close();
            }
            return registroEntradas;
        }

        private SqlConnection SqlConecao()
        {

            var configuracao = new LeituraConfiguração().LerConfiguracao();
            var stringdeConecao = new SqlConnectionStringBuilder
            {
                DataSource = $"{configuracao.nomeServidor}",
                InitialCatalog = $"{configuracao.nomeBanco}",
                UserID = $"{configuracao.usuario}",
                Password = $"{configuracao.senha}",
                IntegratedSecurity = false
            }; 

            var cn = new SqlConnection(stringdeConecao.ConnectionString);
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

        public void InserirRegistros(RegistroEntrada registroEntrada)
        {
            try
            {
                var sqlConn = SqlConecao();
                string sql = $"INSERT INTO [dbo].[LOG_ACESSO](CD_LOG_ACESSO, NU_MATRICULA, NU_DATA_REQUISICAO, TP_SENTIDO_CONSULTA) VALUES({registroEntrada.Id}, {registroEntrada.Matricula}, '{registroEntrada.Horario.ToString("yyyy/MM/dd hh:mm:ss")}', {registroEntrada.Sentido})";
                var cmd = new SqlCommand(sql, sqlConn);
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        public int BuscaUltimoRegistro()
        {
            var registroEntradas = new List<RegistroEntrada>();
            using (SqlConnection sqlConn = SqlConecao())
            {
                var cmd = new SqlCommand("SELECT [CD_LOG_ACESSO] ,[NU_MATRICULA] ,[NU_DATA_REQUISICAO] ,[TP_SENTIDO_CONSULTA] FROM [dbo].[LOG_ACESSO] ORDER by [CD_LOG_ACESSO]", sqlConn);
                using (var dr = cmd.ExecuteReader())
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

                sqlConn.Close();
            }
            var registro = new RegistroEntrada();

            if (registroEntradas.Count > 1)
            {
                registro = registroEntradas[registroEntradas.Count - 1];
                return registro.Id + 1;
            }

            return registro.Id;
        }
    }
}
