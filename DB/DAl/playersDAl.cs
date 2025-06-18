using System;
using System.Collections.Generic;
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




        //var quary = $"INSERT INTO intelreports ( reporter_id,target_id,text )" +
        //       $"VALUES ('{reporter.Id}', '{target.Id}', '{text}')";
        //new MySqlCommand(quary, conn).ExecuteNonQuery();



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

                reader=cmd.ExecuteReader();

                if (reader.Read())
                {
                    person = Player.creatPlayer(reader);
                }
                else
                {
                    person = new Player(name, id);
                }

                    return person;
            }
            catch
            {
                return null;
            }
            finally
            {
                ConnectioN.Close(Connect);
            }
            return null;
        }
    }






}
