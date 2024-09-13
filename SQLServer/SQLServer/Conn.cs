using System;
using System.Data.SqlClient;

namespace SQLServer
{
    class Conn
    {
        private static string server = "DESKTOP-5KFUEIF\\SQLEXP";
        private static string database = "Loja";
        private static string user = "luis";
        private static string password = "luis123";
        private static Conn Con = null;

        public SqlConnection StrCon
        {
            get
            {

                string connectionString = $"Server={server};Database={database};User Id={user};Password={password};";
                SqlConnection conec = new SqlConnection(connectionString);

                try
                {
                    conec.Open();
                    Console.WriteLine("Conexão bem-sucedida!");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
                }
                finally
                {
                    if (conec.State == System.Data.ConnectionState.Open)
                    {
                        conec.Close();
                    }
                }

                return conec;
            }
        }


        public void TestarConexao()
        {
            using (SqlConnection conec = StrCon)
            {
                try
                {
                    conec.Open();
                    Console.WriteLine("Conexão testada com sucesso!");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Erro ao testar a conexão: " + ex.Message);
                }
                finally
                {
                    if (conec.State == System.Data.ConnectionState.Open)
                    {
                        conec.Close();
                    }
                }
            }
        }
    }
}
