using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigationChagay
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
        public IranianAgent(string name,string rank,List<Sensor>list )
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
            Console.WriteLine( this.Name +" "+this.Rank );
        }

    }
    public class SquadLeader: IranianAgent
    {

        public SquadLeader(string name, string rank, List<Sensor> list,int levelRank) : base(name,rank,list)
        {


        }

    }
}
