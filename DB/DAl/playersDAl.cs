using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using investigationChagay.DB.Connection;
using investigationChagay.DB.DAl;
using investigationChagay.DB.Models;
using MySql.Data.MySqlClient;

namespace investigationChagay.DB.DAl
{

    public class playersDAL
    {
        MySqlConnection Connect = ConnectioN.InitConnection();



        public Player getPLyar(string name, int id)
        {
            MySqlDataReader reader;
            Player person;
            try
            {
                ConnectioN.Open(Connect);
                var conn = Connect;
                var quary = $"select * from players where id={id}";
                var cmd = new MySqlCommand(quary, conn);

                reader = cmd.ExecuteReader();
                Console.WriteLine();
                if (reader.Read())
                {
                  
                    person = Player.creatPlayer(reader);

                   
                }
                else
                {
                  
                    reader.Close();
                   
                    conn = Connect;

                    person = new Player(name);
                   
                    quary = $"insert into players (name) values ('{person.name}')";
                    new MySqlCommand(quary, conn).ExecuteNonQuery();

                   
                    
                }
               
                return person;
            }
            catch (Exception ex)
            {
                Console.WriteLine("שגיאה בקריאה מהמסד: " + ex.Message);
                return null;
            }
           
            
            finally
            {
                ConnectioN.Close(Connect);
            }
           
        }

        public void UpdatePlayer(Player player)
        {
           
           
              ConnectioN.Open(Connect);
            try
            {
              
                var conn = Connect;
                string query = $"UPDATE players SET num_exposed = {player.num_exposed} WHERE name = '{player.name}'";


                new MySqlCommand(query, conn).ExecuteNonQuery();
               


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                ConnectioN.Close(Connect);
            }
        }
    }






}
