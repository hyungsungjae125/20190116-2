using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class DataBase
    {
        private string strConnection1 = string.Format("server={0};user={1};password={2};database={3}", "192.168.3.142", "root", "1234", "test");
        private string strConnection2 = string.Format("server={0};user={1};password={2};database={3}", "192.168.3.155", "root", "1234", "test");

        public MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = strConnection1;

                conn.Open();
                return conn;
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
