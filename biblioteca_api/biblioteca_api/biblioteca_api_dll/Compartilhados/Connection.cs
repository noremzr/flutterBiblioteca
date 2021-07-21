using System;
using System.Data.SqlClient;

namespace biblioteca_api_dll.Compartilhados
{
    public static class Connection
    {

         private static string _connectionString = @"Server=DESKTOP-UKBKS41\SQLEXPRESS;Database=Biblioteca;Uid=sa;Pwd=sa1234;";

        private static SqlConnection conexao =  null;

        public static SqlConnection GetConnection() {
            if (conexao==null) {
                conexao = new SqlConnection(_connectionString);
            }
            conexao.Open();
            return conexao;
        }
    }
}
