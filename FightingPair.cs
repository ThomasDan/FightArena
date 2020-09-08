using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    class FightingPair
    {
        private SuperHero firstFighter;
        private SuperHero secondFighter;
        private bool fightOver;

        public FightingPair(SuperHero FirstFighter, SuperHero SecondFighter)
        {
            firstFighter = FirstFighter;
            secondFighter = SecondFighter;
            fightOver = false;
        }
        public SuperHero FirstFighter
        {
            get { return this.firstFighter; }
        }
        public SuperHero SecondFighter
        {
            get { return this.secondFighter; }
        }

        public SuperHero Fight()
        {
            //Console.Clear();
            int round = 0;
            byte dmg = 0;
            SuperHero winner = firstFighter; // Initializing value, to hopefully be overwritten.
            while (!fightOver)
            {
                round++;
                Console.WriteLine("\nROUND " + round);

                // First fighter goes first, because he's first.
                dmg = (byte)this.firstFighter.Attack();
                Console.WriteLine(this.firstFighter.Name + " attacks for " + dmg + " damage!");
                this.secondFighter.GetAttacked(dmg);


                if (!this.secondFighter.StillStanding)
                {
                    // The second fighter has been knocked out!
                    Console.WriteLine(this.secondFighter.Name + " has been knocked out!\n" + this.firstFighter.Name + " is the winner!");
                    this.fightOver = true;
                    winner = this.firstFighter;
                }
                else
                {
                    Console.WriteLine(this.secondFighter.Name + " is still standing! " + this.secondFighter.HitPoints + "HP remaining!");
                    dmg = (byte)this.secondFighter.Attack();
                    Console.WriteLine(this.secondFighter.Name + " attacks for " + dmg + " damage!");

                    this.firstFighter.GetAttacked(dmg);
                    if (!this.firstFighter.StillStanding)
                    {
                        // THe first fighter has been knocked out!
                        Console.WriteLine(this.firstFighter.Name + " has been knocked out!\n" + this.secondFighter.Name + " is the winner!");
                        this.fightOver = true;
                        winner = this.secondFighter;
                    }
                    else
                    {
                        Console.WriteLine(this.firstFighter.Name + " is still standing! " + this.firstFighter.HitPoints + "HP remaining!");
                    }
                }
                Console.ReadKey();
            }
            return winner;
        }
    }
}
