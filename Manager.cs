using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigationChagay
{
    internal class Manager
    {
        IranianAgent iranian;

        public void Game()
        {
            string gess;
            iranian = initGame();
            foreach (var item in iranian.listSensor)
            {
                Console.Write(item.Name + "   ");
            }
            while (true)
            {

                Console.WriteLine("please enter your gess");

                gess = Console.ReadLine();
                checkSensorGess(gess, iranian);
                foreach (var item in iranian.gessList)
                {
                    Console.Write(item + "   ");
                }

            }






        }


        public void checkSensorGess(string gess, IranianAgent iranian)
        {




            if (Sensor.active(iranian, gess))//אם יש לו את הסנסורים האלה אז הוא מחזיר True 
            {

                iranian.gessList.Remove(gess);
                iranian.countTrueGess += 1;
                Console.WriteLine($"you find until now   {iranian.countTrueGess} to complit the mision you need to find {iranian.listSensor.Count - iranian.countTrueGess} more ");
                if (iranian.gessList.Count == 0)
                {
                    Console.WriteLine("!@#$%^&*()(^%$#@#$%^%$#");
                }


            }
            else
            {
                Console.WriteLine("=================");
                Console.WriteLine("you mising the gess");
            }





        }
        public IranianAgent initGame()
        {

            IranianAgent person = creatAgent();
            return person;
        }


        public IranianAgent creatAgent()
        {
            IranianAgent person = RandomIranianAgent();
            return person;
        }
        public IranianAgent RandomIranianAgent()
        {
            List<string> anmeSensor = new List<string>() { "cellPhone", "SensorMoving" };

            List<Sensor> sensorList = new List<Sensor>();

            Random rnd = new Random();

            for (int i = 0; i < 2; i++)//יצירת 2 סנסורים
            {
                sensorList.Add(creatSensor(anmeSensor[rnd.Next(0, anmeSensor.Count)]));
            }
            IranianAgent person = new IranianAgent("mohmad", 3, sensorList);


            return person;






        }
        public Sensor creatSensor(string nameSensor)
        {
            Sensor sensor;
            switch (nameSensor)
            {
                case "cellPhone":

                    sensor = new Sensor("cellPhone", 100);

                    break;
                case "SensorMoving":
                    sensor = new Sensor("SensorMoving", 100);
                    break;
                default:
                    return null;
                    break;


            }
            return sensor;

        }
    }
}
