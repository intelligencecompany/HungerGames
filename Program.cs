using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HungerGames.Controllers;
using HungerGames.Models;

namespace HungerGames
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController game = new GameController();
            game.InitGame();

            foreach(Contestant c in game.Contestants)
            {
                Console.WriteLine(string.Format("Player {0} | IsCareer {1}, IsDistrict {2}, IsMale {3}", c.PlayerId, c.IsCareer, c.IsDistrict, c.IsMale));
            }

            game.StartGame();

            Console.ReadKey();
        }

    }
}
