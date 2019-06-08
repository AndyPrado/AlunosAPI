using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosAPI.Util
{
    public class DAL
    {
        public MySqlConnection Connection { get; set; }

        public static string server = "localhost";
        public static string database = "persondb";
        public static string uid = "root";
        public static string pwd = "";

        public static string connectionString = $"Server={server};Database={database};Uid={uid};Pwd={pwd};Sslmode=none;charset=utf8";

        public DAL()
        {
            Connection = new MySqlConnection(connectionString);
            Connection.Open();
        }

        //Executa comandos no banco de dados de Insert, Delete e Update
        public void ExecuteCommand(string command)
        {
            var sqlCommand = new MySqlCommand(command, Connection);
            sqlCommand.ExecuteNonQuery();
        }        

        //Executa comandos no banco de dados de Get
        public DataTable GetTable(string command)
        {
            var sqlCommand = new MySqlCommand(command, Connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
