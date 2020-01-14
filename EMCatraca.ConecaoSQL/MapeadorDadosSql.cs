using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ControleEntreDoisBanco
{
    class MapeadorDadosSql
    {
        public List<RegistroEntrada> BuscaRegistroDoDia(DateTime dia)
        {
            var registroEntradas = new List<RegistroEntrada>();
            SqlConnection sqlConn = SqlConecao();

            sqlConn.Open();
            var cmd = new SqlCommand("USE [MDACESSO] GO SELECT [CD_LOG_ACESSO] ,[NU_MATRICULA] ,[NU_DATA_REQUISICAO] ,[TP_SENTIDO_CONSULTA] FROM [dbo].[LOG_ACESSO] GO", sqlConn);
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var registroEntrada = new RegistroEntrada();
                registroEntrada.Id = dr.GetInt32(1);
                registroEntrada.Matricula = dr.GetInt32(2);
                registroEntrada.Horario = dr.GetDateTime(3);
                registroEntrada.Sentido = dr.GetInt32(4);
                registroEntradas.Add(registroEntrada);

            }
            sqlConn.Close();

            return registroEntradas;
        }

        private SqlConnection SqlConecao()
        {
            //const string stringdeConecao = "Server=;Database=MDACESSO;User Id=acesso;Password=Simbios@2020";
            const string stringdeConecao = "server=DEV-CORTES\\SQLEXPRESS;database=MDACESSO;Integrated Security=SSPI;User Id=acesso;Password=Simbios@2020;";
            string connectionString = stringdeConecao;
            return new SqlConnection(connectionString);
        }

        public void InserirRegistros(RegistroEntrada registroEntrada)
        {
            try
            {
                var sqlConn = SqlConecao();
                sqlConn.Open();
                string sql = $"INSERT INTO [dbo].[LOG_ACESSO]([CD_LOG_ACESSO], [NU_MATRICULA], [NU_DATA_REQUISICAO], [TP_SENTIDO_CONSULTA]) VALUES({registroEntrada.Id}, {registroEntrada.Matricula}, '{registroEntrada.Horario}', {registroEntrada.Sentido})";
                var cmd = new SqlCommand(sql, sqlConn);
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
            catch (Exception)
            {
                
                throw;
            }


        }
    }
}
