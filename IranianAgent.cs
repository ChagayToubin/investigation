using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigationChagay
{
    public class IranianAgent
    {
        public List<Sensor> listSensor;
        public string Name;
        public int Rank;

        public List<string> gessList;
        public int countTrueGess = 0;
        public IranianAgent(string name,int rank,List<Sensor>list)
        {
            Name = name;
            Rank = rank;
            listSensor = list;
            gessList = CopySensorNamesToList();


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

    }
}
