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
        private static Manager instance; // שדה סטטי ששומר את האובייקט היחיד
        private Manager() { } // בנאי פרטי – אף אחד לא יכול לעשות new מבחוץ

        public static Manager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Manager(); // יצירה ראשונה
                }
                return instance; // תמיד מחזיר את אותו מופע
            }
        }
        IranianAgent iranian;

        public void startGame()
        {
            Console.WriteLine( "chose a level do u want 1 or 2");
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
                        startGame();
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
            Console.WriteLine("all the agent sensores");
            Console.WriteLine( "");
            while (true)

            {

                Console.WriteLine("please enter your gess");

                gess = Console.ReadLine();

                iranian.countGessTrueFalse += 1;

                checkSensorGess(gess, iranian);

                foreach (var sensor in iranian.gessList)
                {
                    Console.Write(sensor + "   ");
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

                if((sensor.Name==gess) && (sensor.active(iranian, gess)))
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
                    iranian.countFalse=0 ;//מאפס אותו שיהיה לו עוד פעם שלוש אופציות
                    temrery = iranian.TrueGessList[iranian.TrueGessList.Count - 1];//מקבל את הארחון שהונכס

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
            List<string> sensorTypes = new List<string>() {"cellPhone","SensorMoving","PulseSensor", "SignalSensor" }; 
            List<Sensor> sensorList = new List<Sensor>();
            Random rnd = new Random();

            for (int i = 0; i < numberLevel * 2; i++)
            {
                string randomSensor = sensorTypes[rnd.Next(sensorTypes.Count)];
                Sensor sensor = SensorFactory.CreateSensor(randomSensor);

                if (sensor != null)
                {
                    sensorList.Add(sensor);
                }
            }

            IranianAgent person = new IranianAgent("mohmad", 3, sensorList, numberLevel);
            return person;
        }

      
    }
}
