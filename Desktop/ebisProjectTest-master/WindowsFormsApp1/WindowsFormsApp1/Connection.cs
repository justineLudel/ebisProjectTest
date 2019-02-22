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
            connString = "Server = dtiro-system; Uid = itguy; Pwd = itguy; Database = wolfire_ebis_marinduque_2016";
            con = new MySqlConnection(connString);
        }

        public MySqlConnection GetConnection()
        {
            return con;
        }
    }
}
