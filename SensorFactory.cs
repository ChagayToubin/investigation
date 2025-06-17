using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static investigationChagay.PulseSensor;

namespace investigationChagay
{
    public static class SensorFactory
    {
        public static Sensor CreateSensor(string name)
        {
            Sensor sensor;

            switch (name)
            {
                case "cellPhone":
                    sensor = new cellPhone("cellPhone", 100);
                    break;

                case "SensorMoving":
                    sensor = new SensorMoving("SensorMoving", 100);
                    break;

                case "PulseSensor":
                    sensor = new PulseSensor("PulseSensor", 100);
                    break;

                case "SignalSensor":
                    sensor = new SignalSensor("SignalSensor", 100);
                    break;

                default:
                    sensor = null;
                    break;
            }

            return sensor;
        }

        public static List<string> GetSensorTypes()
        {
            return new List<string>
            {
                "cellPhone",
                "SensorMoving",
                "PulseSensor",
                "SignalSensor"
            };
        }
    }
}
