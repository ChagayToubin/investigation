using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using investigationChagay.DB.Connection;
using investigationChagay.DB.Models;
using MySql.Data.MySqlClient;

namespace investigationChagay.DB.DAl
{
    public  class terroristDAL
    {
      
        MySqlConnection Connect = ConnectioN.InitConnection();
        public IranianAgent getRandomTerrroistDB()
        {
            MySqlDataReader reader;
            Random rnd = new Random();
            try
            {
                ConnectioN.Open(Connect);
                var conn = Connect;
                var quary = $"select * from players where id={rnd.Next(0, 200)}";
                var cmd = new MySqlCommand(quary, conn);

                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);




                return null;
            }
            catch
            {
                return null;
                Console.WriteLine("");
            }
        }

    }
}
