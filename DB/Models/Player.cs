using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace investigationChagay.DB.Models
{
    public class Player
    {
        public string name;
        public int id, num_exposed;
        public Player(string Name)
        {
            this.name = Name;
        }
        public Player() { }

        public static Player creatPlayer(MySqlDataReader reader)
        {
            Player player = new Player
            {
                name = reader.GetString("name"),
                id = reader.GetInt32("id"),
                num_exposed = reader.GetInt32("num_exposed")

            };
            return player;


        }
        public void print()
        {
            Console.WriteLine(this.name + " " + this.num_exposed);
        }
    }
}
