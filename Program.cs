using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    class Program
    {
        static void Main(string[] args)
        {
            // Adding all the contestants to the competition.
            List<SuperHero> contestants = new List<SuperHero>
            {
                new SuperHero("Kong-Fu Harry", 120, 5, 5, 2, 2),
                new SuperHero("Dino the Super-Dog", 70, 2, 8, 8, 6),
                new SuperHero("Poison Punner", 90, 5, 5, 13, 1),
                new SuperHero("Mikkel the Minimouse", 40, 9, 9, 9, 9),
                new SuperHero("Ivan the Rubbergoat", 70, 8, 8, 6, 6),
                new SuperHero("Egon the Elk", 90, 4, 4, 11, 5)
            };
            contestants.Add(new SpeedyKarl());
            contestants.Add(new TigerTheCat());

            // Putting all the contestants into pairs. If there is an uneven number of contestants, then one will be randomly left out. Too bad.
            List<FightingPair> fightingPairs = new List<FightingPair>();
            while(contestants.Count > 0 && contestants.Count / 2 >= 1)
            {
                int H1 = 0;
                int H2 = 0;
                while(H1 == H2)
                {
                    H1 = Logic.random(0, contestants.Count - 1);
                    H2 = Logic.random(0, contestants.Count - 1);
                }
                
                fightingPairs.Add(new FightingPair(contestants[H1], contestants[H2]));
                contestants.RemoveAt(H1);
                if(H1 < H2)
                {
                    H2--;
                }
                contestants.RemoveAt(H2);
            }
            Console.WriteLine("Contestants: " + contestants.Count() + " | Fighting pairs: " + fightingPairs.Count());
            Console.ReadKey();

            // Kicking out the last uneven contestant, if any
            contestants.Clear();

            // Now the fighting!
            Console.WriteLine("Welcome to the Quarter Finals!");
            foreach(FightingPair pair in fightingPairs)
            {
                Console.WriteLine(pair.FirstFighter.Name + " Vs. " + pair.SecondFighter.Name);
                Console.ReadKey();
                contestants.Add(pair.Fight());
                Console.Clear();
            }
            fightingPairs.Clear();

            // Semi FInals
            // randomly distributing the remaining contestants
            while (contestants.Count > 0 && contestants.Count / 2 >= 1)
            {
                int H1 = 0;
                int H2 = 0;
                while (H1 == H2)
                {
                    H1 = Logic.random(0, contestants.Count - 1);
                    H2 = Logic.random(0, contestants.Count - 1);
                }

                fightingPairs.Add(new FightingPair(contestants[H1], contestants[H2]));
                contestants.RemoveAt(H1);
                if (H1 < H2)
                {
                    H2--;
                }
                contestants.RemoveAt(H2);
            }

            // Now the fighting!
            Console.WriteLine("Welcome to the Semi Finals!");
            foreach (FightingPair pair in fightingPairs)
            {
                Console.WriteLine(pair.FirstFighter.Name + " Vs. " + pair.SecondFighter.Name);
                Console.ReadKey();
                contestants.Add(pair.Fight());
                Console.Clear();
            }
            fightingPairs.Clear();

            // Now the final round.
            Console.WriteLine("Welcome to the Final combat!");
            FightingPair finalPair = new FightingPair(contestants[0], contestants[1]);

            SuperHero AbsoluteWInner = finalPair.Fight();

            Console.WriteLine(AbsoluteWInner.Name + " is the winner of the final round! All hail " + AbsoluteWInner + "!!!");
            Console.ReadKey();
        }
    }
}
