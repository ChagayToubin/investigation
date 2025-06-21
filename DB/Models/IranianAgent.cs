using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace investigationChagay.DB.Models
{
    public class IranianAgent
    {
        public string Name;
        public string Rank;
        public int countFalse = 0;
        public int countGessTrueFalse = 0;//סןפר את כל התשובות נכון ולא נכון
        public List<Sensor> listSensor;//רשימה מקורית לא נוגיעם בבה
        public List<string> gessList;//מה נשאר לו לנחש /להדליק
        public int countTrueGess = 0;
        public List<string> TrueGessList;//פן מופיע כל מה שניחש ודלוק
        ///-------------------------------------------------------ל-//
        public int id;
        public string location;
        public string favorite_weapon;
        public string contact_number;
        public string secret_phrase;
        public string affiliation;
        public int is_exposed;
        public IranianAgent(string name, string rank, List<Sensor> list)
        {
            Name = name;
            Rank = rank;
            listSensor = list;




            TrueGessList = new List<string>();//מה נחשו נכון ומתאים לרישמה

            gessList = CopySensorNamesToList();//נשאר לננחש


        }
        public List<string> CopySensorNamesToList()
        {
            List<string> result = new List<string>();

            for (int i = 0; i < listSensor.Count; i++)
            {
                string name = listSensor[i].Name;
                result.Add(name);
            }

            return result;
        }
        public void printInfo()
        {
            Console.WriteLine(Name + " " + Rank);
        }
        public IranianAgent (){}
        public IranianAgent creatAgentFromDB(MySqlDataReader reader)//צריך להוסיף את הלסט של הרנדום סנסור ואת ההכםלה של הליסט
        {
            IranianAgent I = new IranianAgent
            {

                id = reader.GetInt32("id"),
                Name = reader.GetString("full_name"),
                location = reader.GetString("location"),
                favorite_weapon = reader.GetString("favorite_weapon"),
                contact_number = reader.GetString("contact_number"),
                secret_phrase = reader.GetString("secret_phrase"),
                affiliation = reader.GetString("affiliation"),
                is_exposed = reader.GetInt32("is_exposed")


            };
            return I;
        }

    }
    public class SquadLeader: IranianAgent
    {

        public SquadLeader(string name, string rank, List<Sensor> list,int levelRank) : base(name,rank,list)
        {


        }

    }
}
