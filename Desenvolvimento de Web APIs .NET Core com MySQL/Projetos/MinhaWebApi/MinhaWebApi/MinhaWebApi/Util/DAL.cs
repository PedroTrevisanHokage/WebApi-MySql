using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace MinhaWebApi.Util
{
    public class DAL
    {
        private static string Server = "localhost";
        private static string DataBase = "dbcliente";
        private static string User = "root";
        private static string Password = "";
        private MySqlConnection Connection;

        private string connectionString = $"Server={Server};DataBase={DataBase};Uid={User};Password={Password};Sslmode=none";

        public DAL()
        {
            Connection = new MySqlConnection(connectionString);
            Connection.Open();
        }

        /// <summary>
        /// Executa um omando do tip INSERT, UPDATE E DELETE
        /// </summary>
        /// <param name="qry"></param>
        public void ExecutarComandoSql(string qry)
        {
            var comando = new MySqlCommand(qry, Connection);
            comando.ExecuteNonQuery();
        }

        public DataTable RetornarDataTable(string qry)
        {
            var comando = new MySqlCommand(qry, Connection);
            var dataAdapter = new MySqlDataAdapter(comando);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
    }
}
