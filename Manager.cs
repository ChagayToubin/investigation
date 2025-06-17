using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static investigationChagay.PulseSensor;

namespace investigationChagay
{
    internal class Manager
    {
        IranianAgent iranian;

        public void Game()
        {
            Console.WriteLine(  "chose a level do u want 1 or 2");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        iranian = initIranian(1);
                        gameLevel(iranian);
                    }
                    break;
                case "2":

                    {
                        iranian = initIranian(2);

                        gameLevel(iranian);
                    }
                    break;
                default:

                    {
                        Console.WriteLine("!@#$%^&*()");
                        Game();
                    }
                    break;

            }





        }
        public void gameLevel(IranianAgent iranian)
        {
            string gess;

            foreach (var sensor in iranian.listSensor)
            {
                Console.Write(sensor.Name + "   ");
            }
            while (true)

            {

                Console.WriteLine("please enter your gess");

                gess = Console.ReadLine();

                iranian.countGessTrueFalse += 1;

                checkSensorGess(gess, iranian);

                foreach (var sensor in iranian.listSensor)
                {
                    Console.Write(sensor.Name + "   ");
                }
                Console.WriteLine(" ");



            }
        }
        public void checkSensorGess(string gess, IranianAgent iranian)
        {
            bool found = false;
            string temrery;



            foreach (var sensor in iranian.listSensor)
            {
               
                if (sensor.active(iranian, gess))
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                iranian.TrueGessList.Add(gess);


                iranian.gessList.Remove(gess);

                iranian.countTrueGess += 1;
                iranian.countFalse = 0;//מתאפס כל פעם שיש לו ניחוש נכון



                Console.WriteLine($"you find until now   {iranian.TrueGessList.Count} to complit the mision you need to find " +
                    $"{iranian.listSensor.Count - iranian.TrueGessList.Count} more ");
                Console.WriteLine(" ");
                if (iranian.gessList.Count == 0)
                {

                    Console.WriteLine("you finish level{nu@#$%^&*)*&^%$#@}");
                }
            }
            else
            {
                Console.WriteLine("");


                Console.WriteLine("=================");

                Console.WriteLine("you mising the gess");

                iranian.countFalse += 1;


                if ((iranian.LevelRank == 2) && (iranian.countFalse >= 3) && (iranian.TrueGessList.Count > 0))//תנאי לסוכן המיוחד
                {
                    temrery = iranian.TrueGessList[iranian.TrueGessList.Count - 1];//מקבל את הארחון שהונכס

                    iranian.TrueGessList.Remove(temrery);
                    iranian.gessList.Add(temrery);

                }

                Console.WriteLine("");
            }
        }



        public IranianAgent initIranian(int numberLevel)
        {

            IranianAgent person = creatAgent(numberLevel);
            return person;
        }


        public IranianAgent creatAgent(int numberLevel)
        {
            IranianAgent person = RandomIranianAgent(numberLevel);
            return person;
        }
        public IranianAgent RandomIranianAgent(int numberLevel)
        {
            List<string> anmeSensor = new List<string>() { "cellPhone", "SensorMoving", "PulseSensor", "SignalSensor" };

            List<Sensor> sensorList = new List<Sensor>();

            Random rnd = new Random();

            for (int i = 0; i < numberLevel * 2; i++)
            {
                sensorList.Add(creatSensor(anmeSensor[rnd.Next(0, anmeSensor.Count)]));
            }
            IranianAgent person = new IranianAgent("mohmad", 3, sensorList, numberLevel);


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
                case "PulseSensor":
                    sensor = new PulseSensor("PulseSensor", 100);
                    break;
                case "SignalSensor":
                    sensor = new SignalSensor("SignalSensor", 100);
                    break;
                default:
                    return null;
                    break;


            }
            return sensor;

        }
    }
}
