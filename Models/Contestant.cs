using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungerGames.Models
{
    public class Contestant
    {
        public int PlayerId { get; set; }
        public int Attack { get; set; }        
        public int Defence { get; set; }
        public int Health { get; set; }
        public int Chance { get; set; }
        public bool IsCareer { get; set; }
        public bool IsDistrict { get; set; }
        public bool IsMale { get; set; }
    }
}
