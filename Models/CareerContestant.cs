using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungerGames.Models
{
    public class CareerContestant : Contestant
    {
        public int AttackLevel
        {
            get
            {
                return this.Attack + this.BonusAttack;
            }
        }
        public int DefenceLevel
        {
            get
            {
                return this.Defence;
            }
        }
        public int BonusAttack { get; set; }
    }
}
