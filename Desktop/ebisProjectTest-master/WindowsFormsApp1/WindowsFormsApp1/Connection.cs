using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp1
{
    class Connection
    {
        private String connString;
        private MySqlConnection con;
        public Connection()
        {
            connString = "Server = ; Uid = ; Pwd = ; Database = ";
            con = new MySqlConnection(connString);
        }

        public MySqlConnection GetConnection()
        {
            return con;
        }
    }
}
