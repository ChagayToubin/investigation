using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigationChagay
{
    public class Sensor
    {
        public string  Name;
        public int Battery;
       
        public Sensor(string name,int battary )
        {
            Name = name;
            Battery = battary;

        }
          
        public static bool active(IranianAgent agent,string gess)
        {

            for (int i = 0; i < agent.gessList.Count; i++)
            {
                if (agent.gessList[i] == gess)
                {
                 
                    return true;
                }
            }
           
            return false;


        }
          
            
           

        
        
    }
    public class SensorMoving:Sensor
    {
        public SensorMoving(string name,int battery) : base(name,battery)
        {
            
        }


    }
    public class cellPhone : Sensor
    {
        public cellPhone(string name, int battery) : base(name, battery)
        {

        }


    }


}
