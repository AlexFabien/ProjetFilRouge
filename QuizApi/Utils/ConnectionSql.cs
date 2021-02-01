using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApi.Utils
{
    sealed class ConnectionSql
    {
        private static readonly string server = "localhost";
        private static readonly string user = "root";
        private static readonly string password = "root";
        private static readonly string db = "quiz";
        private static readonly string port = "3306";

        private ConnectionSql() { }
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(GetConnStr());
        }

        private static string GetConnStr()
        {
            StringBuilder connStr = new StringBuilder();
            connStr.Append($"server={server};");
            connStr.Append($"user={user};");
            connStr.Append($"database={db};");
            connStr.Append($"port={port};");
            connStr.Append($"password={password}");
            return connStr.ToString();
        }
    }
}
