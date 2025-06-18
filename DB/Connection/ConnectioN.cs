using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace investigationChagay.DB.Connection
{
    public static class ConnectioN
    {

        public static MySqlConnection InitConnection()
        {
            string connStr = "Server=localhost;Database=investigation;User=root;Password=;Port=3306;";
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(connStr);
                Console.WriteLine("wkwkwkkwkw");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }




            return conn;
        }
        public static void Open(MySqlConnection conn)
        {
            conn.Open();
        }
        public static void Close(MySqlConnection conn)
        {
            conn.Close();
        }
    }
}
