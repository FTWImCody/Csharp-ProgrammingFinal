/*
 * Programmer: Cody McNealy
 * Program: Die Roller
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkariaGame
{
    class DieRoller
    {
        public static int Roll()//defualt roll method. Roll 1d6
        {
            return StaticRandom.Instance.Next(1, 7);
        }
        public static int Roll(int times)//uses the input times to roll a d6 any number of times the user would like to roll, returns total of rolls
        {
            int total = 0;
            while (times > 0)
            {
                int roll = StaticRandom.Instance.Next(1, 7);
                total += roll;
                times--;
            }
            return total;
        }
        public static int Roll(int times,int sides)//uses the inputs sides and times to roll any number of sided die and any number of times the user would like to roll, returns total of all rolls
        {
            int total = 0;
            while (times > 0)
            {
                int roll = StaticRandom.Instance.Next(1, sides+1);
                total += roll;
                times--;
            }
            return total;
        }
        public static int Roll(int times, int sides, int target)/*uses the inputs sides and times to roll any number of sided die and any number of times the user would like to roll
                                                                * then compares the die total to the user's target and prints whether or not they reached their target. */
        {
            int total = 0;
            while (times > 0)
            {
                int roll = StaticRandom.Instance.Next(1, sides+1);
                if (roll > target)
                {
                    total++;
                }
                times--;
            }
            return total;
        }
    }
}