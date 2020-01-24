using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace IntegracaoBancos
{
    public class MapeadorDadosSql
    {
        string _conexao;
        public MapeadorDadosSql(string conexao)
        {
            _conexao = conexao;
        }
        public List<RegistroEntrada> BuscaRegistroPeloUltimo(int ultimoAluno)
        {

            var registroEntradas = new List<RegistroEntrada>();
            using (SqlConnection sqlConn = new SqlConnection(_conexao))
            {

                sqlConn.Open();
                var cmd = new SqlCommand("SELECT CD_LOG_ACESSO , NU_CREDENCIAL ,DT_REQUISICAO ,TP_SENTIDO_CONSULTA FROM [dbo].[LOG_ACESSO]" +
                                          $"WHERE [CD_LOG_ACESSO] > {ultimoAluno} ORDER by [CD_LOG_ACESSO]", sqlConn);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        try
                        {
                            var id = dr.GetDecimal(0);
                            decimal? matricula = dr.GetDecimal(1);
                            var Horario = dr.GetDateTime(2);
                            decimal? sentido = dr.GetDecimal(3);
                            registroEntradas.Add(new RegistroEntrada
                            {
                                Id = Convert.ToInt32(id),
                                Matricula = Convert.ToInt32(matricula),
                                Horario = Horario,
                                Sentido = Convert.ToInt32(sentido)
                            });
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

                sqlConn.Close();
            }
            return registroEntradas;

        }

        public List<RegistroEntrada> BuscaRegistroPorDia()
        {
            var dataHoje = DateTime.Now;
            var registroEntradas = new List<RegistroEntrada>();
            using (SqlConnection sqlConn = SqlConecao())
            {

                sqlConn.Open();
                var cmd = new SqlCommand("SELECT CD_LOG_ACESSO , NU_CREDENCIAL ,DT_REQUISICAO ,TP_SENTIDO_CONSULTA FROM [dbo].[LOG_ACESSO]" +
                                          $"WHERE  DT_REQUISICAO > '{dataHoje.ToString("yyyy/MM/dd")}' ORDER by [CD_LOG_ACESSO]", sqlConn);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        try
                        {
                            var id = dr.GetDecimal(0);
                            decimal? matricula = dr.GetDecimal(1);
                            var Horario = dr.GetDateTime(2);
                            decimal? sentido = dr.GetDecimal(3);
                            registroEntradas.Add(new RegistroEntrada
                            {
                                Id = Convert.ToInt32(id),
                                Matricula = Convert.ToInt32(matricula),
                                Horario = Horario,
                                Sentido = Convert.ToInt32(sentido)
                            });
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

                sqlConn.Close();
            }
            return registroEntradas;
        }
        public void InserirRegistros(RegistroEntrada registroEntrada)
        {
            try
            {
                var sqlConn = SqlConecao();
                sqlConn.Open();
                string sql = $"INSERT INTO [dbo].[LOG_ACESSO](NU_CREDENCIAL ,DT_REQUISICAO ,TP_SENTIDO_CONSULTA,NU_DATA_REQUISICAO,NU_HORA_REQUISICAO,DT_PERSISTENCIA,NU_FUNCAO) " +
                    $"VALUES({registroEntrada.Matricula}, '{registroEntrada.Horario.ToString("yyyy/MM/dd hh:mm:ss")}', {registroEntrada.Sentido}," +
                    $"{registroEntrada.Horario.Year}{registroEntrada.Horario.Month}{registroEntrada.Horario.Day},{registroEntrada.Horario.Hour}{registroEntrada.Horario.Minute}," +
                    $"'{registroEntrada.Horario.ToString("yyyy/MM/dd hh:mm:ss")}',0)";
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
                sqlConn.Open();
                var cmd = new SqlCommand("SELECT CD_LOG_ACESSO , NU_CREDENCIAL ,DT_REQUISICAO ,TP_SENTIDO_CONSULTA FROM [dbo].[LOG_ACESSO] ORDER by [CD_LOG_ACESSO]", sqlConn);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        try
                        {
                            var id = dr.GetDecimal(0);
                            decimal? matricula = dr.GetDecimal(1);
                            var Horario = dr.GetDateTime(2);
                            decimal? sentido = dr.GetDecimal(3);
                            registroEntradas.Add(new RegistroEntrada
                            {
                                Id = Convert.ToInt32(id),
                                Matricula = Convert.ToInt32(matricula),
                                Horario = Horario,
                                Sentido = Convert.ToInt32(sentido)
                            });
                        }
                        catch (Exception ex)
                        {
                        }
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
