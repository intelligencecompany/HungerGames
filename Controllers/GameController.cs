using HungerGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungerGames.Controllers
{
    public class GameController
    {
        public Random Random = new Random();
        public List<CareerContestant> CareerContestants;
        public List<DistrictContestant> DistrictContestants;

        public List<Contestant> Contestants { 
            get
            {
                List <Contestant> result = new List<Contestant>();
                foreach (CareerContestant c in CareerContestants)
                {
                    c.Attack = c.AttackLevel;
                    result.Add(c);
                }

                foreach (DistrictContestant c in DistrictContestants)
                {
                    c.Defence = c.DefenceLevel;
                    result.Add(c);
                }
                return result;
            }
        }           

        public void InitGame()
        {
            int PlayerId = 1;

            CareerContestants = new List<CareerContestant>();
            for (int i = 0; i < 24 / 4; i++)
            {
                //Create Career Male
                if (i < 24 / 4 / 2)
                {
                    CareerContestants.Add(new CareerContestant()
                    {
                        PlayerId = PlayerId,
                        Attack = GetRandomNumber(),
                        BonusAttack = GetRandomNumber(),
                        Defence = GetRandomNumber(),
                        Health = GetRandomNumber(),
                        IsCareer = true,
                        IsDistrict = false,
                        IsMale = true
                    });
                    PlayerId++;
                };

                if (i >= 24 / 4 / 2)
                {
                    CareerContestants.Add(new CareerContestant()
                    {
                        PlayerId = PlayerId,
                        Attack = GetRandomNumber(),
                        BonusAttack = GetRandomNumber(),
                        Defence = GetRandomNumber(),
                        Health = GetRandomNumber(),
                        IsCareer = true,
                        IsDistrict = false,
                        IsMale = false
                    });
                    PlayerId++;
                };
            }

            DistrictContestants = new List<DistrictContestant>();
            for (int i = 0; i < 24 / 4 * 3; i++)
            {
                //Create Career Male
                if (i < (24 / 4  * 3) / 2)
                {
                    DistrictContestants.Add(new DistrictContestant()
                    {
                        PlayerId = PlayerId,
                        Attack = GetRandomNumber(),
                        BonusDefence = GetRandomNumber(),
                        Defence = GetRandomNumber(),
                        Health = GetRandomNumber(),
                        IsCareer = false,
                        IsDistrict = true,
                        IsMale = true
                    });
                    PlayerId++;
                };

                if (i >= (24 / 4 * 3) / 2)
                {
                    DistrictContestants.Add(new DistrictContestant()
                    {
                        PlayerId = PlayerId,
                        Attack = GetRandomNumber(),
                        BonusDefence = GetRandomNumber(),
                        Defence = GetRandomNumber(),
                        Health = GetRandomNumber(),
                        IsCareer = false,
                        IsDistrict = true,
                        IsMale = false
                    });
                    PlayerId++;
                };
            }
        }

        public void StartGame()
        {
            List<Contestant> GameContestants = Contestants;

            while(GameContestants.Count() > 1)
            {
                List<int> PlayersAlive = GameContestants.Select(c => c.PlayerId).ToList();
                int random = GetRandomNumber(PlayersAlive.Count);

                int attackerId = PlayersAlive[random];

                PlayersAlive = PlayersAlive.Where(c => c != attackerId).ToList();

                random = GetRandomNumber(PlayersAlive.Count);

                int defenderId = PlayersAlive[random];

                int loser = ArenaController.StartBattle(GameContestants.FirstOrDefault(c => c.PlayerId == attackerId), GameContestants.FirstOrDefault(c => c.PlayerId == defenderId));

                if (loser >= 0)
                    GameContestants.Remove(GameContestants.FirstOrDefault(c => c.PlayerId == loser));
            }

            Contestant winner = GameContestants.FirstOrDefault();
            Console.WriteLine(string.Format("Winner: {0}", winner.PlayerId));
        }


        private int GetRandomNumber(int length = 100)
        {
            return Random.Next(0, length);
        }

    }
}
