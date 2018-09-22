using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungerGames.Models
{
    public class DistrictContestant : Contestant
    {
        public int DefenceLevel
        {
            get
            {
                return this.Defence + this.BonusDefence;
            }
        }
        public int AttackLevel {
            get
            {
                return this.Attack;
            }
        }
        public int BonusDefence { get; set; }
    }
}
