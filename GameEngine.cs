using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using investigationChagay.DB.DAl; 

using investigationChagay.DB.Models;

namespace investigationChagay
{
    public class GameEngine
    {
        public playersDAL PLYAR=new playersDAL();
        public Player getplayer()
        {
            Console.WriteLine("hello please enter your name");
            string namePlayer = Console.ReadLine();
            Console.WriteLine("please enter your id");
            int idplayer =int.Parse(Console.ReadLine());

            var P = PLYAR.getPLyar(namePlayer,idplayer);
            return P;

        }





        public void initGame()
        {
            string FullName;

            Console.WriteLine("To start the game please enter your full name");
            FullName = Console.ReadLine();
            IranianAgent iranian;


            iranian = initIranian("Foot Soldier");
            Start(iranian, FullName);

            Console.WriteLine("you finish the first level lets go to secound levl ");

            iranian = initIranian("Squad Leader");

            Start(iranian, FullName);

          

        }
        public void Start(IranianAgent iranian,string name)
        {
            string gess;


     

            Console.WriteLine("");
            
            while (true)
            {
                foreach (var sensor in iranian.gessList)
                {
                    Console.Write(sensor + "   ");
                }
                Console.WriteLine("");
                if (checkEndTheGame(iranian))
                {
                   
                    finishGame(iranian, name);
                    break;
                }

                Console.WriteLine($"you find until now   {iranian.TrueGessList.Count} to complit the mision you need to find " +
                  $"{iranian.listSensor.Count - iranian.TrueGessList.Count} more ");
               
                Console.WriteLine("please enter your gess");

                gess = Console.ReadLine();

                checkSensorGess(gess, iranian);
               
                Console.WriteLine(" ");

            }
        }



        public void checkSensorGess(string gess, IranianAgent iranian)
        {
            bool found = false;
           
            iranian.countGessTrueFalse += 1;
            foreach (var sensor in iranian.listSensor)
            {
                if ((sensor.Name == gess) && (sensor.active(iranian, gess)))
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

                Console.WriteLine(" ");              
            }
            else
            {
                Console.WriteLine("");

                Console.WriteLine("=================you mising the gess=================");

                iranian.countFalse += 1;

                Console.WriteLine("");
                foreach (var sensor in iranian.gessList)
                {
                    Console.Write(sensor + "   ");
                }
                Console.WriteLine(" ");              
            }
            checkIfRemoveSensor(iranian);
        }
        public void checkIfRemoveSensor(IranianAgent iranian)
        {
           
            string temrery;

            if ((iranian.Rank == "Squad Leader"||(iranian.Rank == "Organization Leader")) && (iranian.countFalse >= 3) && (iranian.TrueGessList.Count > 0))//תנאי לסוכן המיוחד
            {
                iranian.countFalse = 0;//מאפס אותו שיהיה לו עוד פעם שלוש אופציות
                temrery = iranian.TrueGessList[iranian.TrueGessList.Count - 1];//מקבל את הארחון שהונכס

                iranian.TrueGessList.Remove(temrery);
                iranian.gessList.Add(temrery);
            }
           //לא טיפלתי בשלב 3
        }



        public IranianAgent initIranian(string numberLevel)
        {

            IranianAgent person = creatAgent(numberLevel);
            return person;
        }


        public IranianAgent creatAgent(string numberLevel)
        {
            IranianAgent person = RandomIranianAgent(numberLevel);
            return person;
        }
        public IranianAgent RandomIranianAgent(string numberLevel)
        {
            List<string> sensorTypes = new List<string>() { "cellPhone", "SensorMoving", "PulseSensor", "SignalSensor" };
            List<Sensor> sensorList = new List<Sensor>();
            Random rnd = new Random();

            int numberSensor = GetnumberSensorByKind(numberLevel);

            for (int i = 0; i < numberSensor ; i++)
            {
                string randomSensor = sensorTypes[rnd.Next(sensorTypes.Count)];
                Sensor sensor = SensorFactory.CreateSensor(randomSensor);

                if (sensor != null)
                {
                    sensorList.Add(sensor);
                }
            }

            IranianAgent person = new IranianAgent("mohmad", numberLevel, sensorList);
            return person;
        }
        public  int GetnumberSensorByKind(string rank)
        {
            switch (rank)
            {
                case "Foot Soldier":
                    return 2;
                case "Squad Leader":
                    return 4;
                case "Senior Commander":
                    return 6;
                case "Organization Leader":
                    return 8;
                default:
                    return 0;
            }
        }

        public bool checkEndTheGame(IranianAgent iranian)
        {
            return (iranian.gessList.Count == 0 )||( iranian.countGessTrueFalse > 10);//בדיקה אם לסיים את המשחק
           
        }



        public void finishGame(IranianAgent iranian,string PlayreName)
        {
            Console.WriteLine("You have finished scrolling all the sensors forward to the next step.");//לחבר לדאטה ביסס
           
        }
    }
}

