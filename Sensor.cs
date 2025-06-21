using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using investigationChagay.DB.Models;

namespace investigationChagay
{



    public class Sensor
    {
        public string Name;
        public int Battery;

        public Sensor(string name, int battary)
        {
            Name = name;
            Battery = battary;

        }

        public virtual bool active(IranianAgent agent, string gess)
        {

            if (agent.gessList.Contains(gess))
            {
                return true;
            }
            return false;




        }

    }
    public class SensorMoving : Sensor
    {
        public SensorMoving(string name, int battery) : base(name, battery)
        {

        }


    }
    public class cellPhone : Sensor
    {
        public cellPhone(string name, int battery) : base(name, battery)
        {

        }


    }
    public class PulseSensor : Sensor
    {
        public int numberGessAfterPLusfind = 0;
        public PulseSensor(string name, int battery) : base(name, battery)
        {

        }

        public override bool active(IranianAgent agent, string gess)
        {

            if (agent.TrueGessList.Contains("PulseSensor"))
            {
                numberGessAfterPLusfind += 1;
            }
            if (numberGessAfterPLusfind >= 3 && agent.TrueGessList.Contains("PulseSensor"))
            {
                agent.TrueGessList.Remove("PulseSensor");//מוריד ממה שנחש נכון
                agent.gessList.Add("PulseSensor");//נשאר לו לנחש את זה עוד פעם
                numberGessAfterPLusfind = 0;
            }

            if (agent.gessList.Contains(gess))
            {
                return true;
            }
            return false;




        }
    }
    public class SignalSensor : Sensor
    {
        public SignalSensor(string name, int battery) : base(name, battery)
        {

        }

        public override bool active(IranianAgent agent, string gess)
        {


            ConsoleHelper.PrintRed(agent.Name);

            if (agent.gessList.Contains(gess))
            {
                return true;
            }
            return false;




        }



    }
}



