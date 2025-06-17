using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace investigationChagay
{
    public class GameEngine
    {
        private IranianAgent iranian;

        public GameEngine(IranianAgent agent)
        {
            this.iranian = agent;
        }

        public void Start()
        {
            string gess;

            foreach (var sensor in iranian.listSensor)
            {
                Console.Write(sensor.Name + "   ");
            }
            Console.WriteLine("all the agent sensores");
            Console.WriteLine("");

            while (true)
            {
                Console.WriteLine("please enter your gess");
                gess = Console.ReadLine();
                iranian.countGessTrueFalse += 1;

                checkSensorGess(gess);

                foreach (var sensor in iranian.gessList)
                {
                    Console.Write(sensor + "   ");
                }
                Console.WriteLine(" ");
            }
        }

        private void checkSensorGess(string gess)
        {
            bool found = false;
            string temrery;

            foreach (var sensor in iranian.listSensor)
            {
                if ((sensor.Name == gess) && (sensor.active(iranian, gess)))
                {
                    Console.WriteLine(sensor.Name);
                    found = true;
                    break;
                }
            }

            if (found)
            {
                iranian.TrueGessList.Add(gess);
                iranian.gessList.Remove(gess);
                iranian.countTrueGess += 1;
                iranian.countFalse = 0;

                Console.WriteLine($"you find until now   {iranian.TrueGessList.Count} to complit the mision you need to find {iranian.listSensor.Count - iranian.TrueGessList.Count} more ");
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

                if ((iranian.LevelRank == 2) && (iranian.countFalse >= 3) && (iranian.TrueGessList.Count > 0))
                {
                    iranian.countFalse = 0;
                    temrery = iranian.TrueGessList[iranian.TrueGessList.Count - 1];
                    iranian.TrueGessList.Remove(temrery);
                    iranian.gessList.Add(temrery);
                }

                Console.WriteLine("");
                foreach (var sensor in iranian.gessList)
                {
                    Console.Write(sensor + "   ");
                }
                Console.WriteLine(" ");
            }
        }
    }
}