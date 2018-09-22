using HungerGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungerGames.Controllers
{
    public static class ArenaController
    {
        public static int StartBattle(Contestant attacker, Contestant defender)
        {
            Console.WriteLine(string.Format("Battle between Player {0} and Player {1}", attacker.PlayerId, defender.PlayerId));
            int loser = -1;
            int winner = -1;

            if(attacker.Attack > defender.Defence)
            {
                winner = attacker.PlayerId;
                loser = defender.PlayerId;
            }

            if (attacker.Attack < defender.Defence)
            {
                winner = defender.PlayerId;
                loser = attacker.PlayerId;
            }

            if (loser >= 0 && winner >= 0)
            {
                Console.WriteLine(string.Format("Player {0} wins", winner));
            } else
            {
                Console.WriteLine(string.Format("It's a draw"));
            }
            return loser;
        }
    }
}
