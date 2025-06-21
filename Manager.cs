using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using investigationChagay.DB.Connection;
using investigationChagay.DB.DAl;
using investigationChagay.DB.Models;
using static investigationChagay.PulseSensor;

namespace investigationChagay
{
    public class Manager
    {
        private static Manager instance;

        GameEngine gameEngine = new GameEngine();

        playersDAL PlayersDAL = new playersDAL();
        private Manager() { }

        public static Manager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Manager();
                }
                return instance;
            }
        }
        public void gameControl()
        {
            Player player = gameEngine.getplayer();
            gameEngine.Game(player);
            Console.WriteLine(player.name);
        }
    }
}
