using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    class SuperHero
    {
        private string name;
        private int hitPoints;
        private bool stillStanding;
        private byte highestDefence;
        private byte lowestDefence;
        private int highestAttack;
        private int lowestAttack;

        public string Name
        {
            get { return this.name; }
        }
        public int HitPoints
        {
            get { return this.hitPoints; }
            set 
            { 
                this.hitPoints = value;
                if(this.hitPoints <= 0)
                {
                    this.stillStanding = false;
                }
            }
        }
        public bool StillStanding
        {
            get { return this.stillStanding; }
        }

        public SuperHero(string Name, byte HitPoints, byte LowestDefence, byte HighestDefence, int HighestAttack, int LowestAttack)
        {
            name = Name;
            hitPoints = HitPoints;
            highestDefence = HighestDefence;
            lowestDefence = LowestDefence;
            highestAttack = HighestAttack;
            lowestAttack = LowestAttack;
            stillStanding = true;
        }

        public virtual int Attack()
        {
            return Logic.random(this.lowestAttack, this.highestAttack);
        }
        public virtual void GetAttacked(int damage)
        {
            // Needs to be int or similar, for bytes don't go below 0.
            int postDefence = damage - Logic.random(this.lowestDefence, this.highestDefence);
            if(postDefence > 0)
            {
                this.HitPoints -= damage;
            }
        }

    }
    class SpeedyKarl : SuperHero
    {
        private bool rightHook;
        public SpeedyKarl():base("Speedy Karl", 90, 3, 3, 5, 2)
        {
            rightHook = true;
        }
        public override int Attack()
        {
            if (this.rightHook)
            {
                this.rightHook = false;
                return 5;
            }
            else
            {
                this.rightHook = true;
                return 2;
            }
        }
    }

    class TigerTheCat : SuperHero
    {
        private byte lives;
        public TigerTheCat() : base("Tiger The Cat", 35, 4, 4, 6, 3)
        {
            lives = 9;
        }
        public override void GetAttacked(int damage)
        {
            // It wouldn't be 9 lives if they didn't save it from getting knocked out in the first place.
            if (lives > 0)
            {
                lives--;
                this.HitPoints += 3;
            }
            base.GetAttacked(damage);
        }
    }
}
