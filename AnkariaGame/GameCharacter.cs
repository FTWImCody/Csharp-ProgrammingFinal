using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkariaGame
{
    abstract class GameCharacter
    {
        protected string _ID { get; } = Guid.NewGuid().ToString("N");
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public override string ToString() //overrides the ToString method to give better information if used
        {
            string returnString = "";
            returnString += "Name: " + Name + Environment.NewLine;
            returnString += "Health: " + Health + Environment.NewLine;
            returnString += "Attack: " + Attack + Environment.NewLine;
            returnString += "Defense: " + Defense + Environment.NewLine;


            return returnString;
        }
        public static string NameGen() //picks from a list of names and suffiixes to name your character/monster
        {
            string[] names = { "Aemad", "Aggie", "Agnar", "Ahab", "Ahrim", "Akrisae", "Amaranth", "Barnabus", "Bartak", "Awowogei", "Ariannwn", "Dawn", "Edward", "Eoin", "Flo", "Fossegrimen", "Gamfred" };
            string[] suffixes = { " of the Amlodd", " the Annihilator", " the Araxyte", " of the Arc", " of Armadyl", " ate Dirt", " of Bandos", " the Beachbum", " the Beast Slayer", " the Betrayed", " Blackbeard", " the Blazing", " the Bloodchiller", " the Boundless", " the Brave", " of the Cadarn", " the Castaway", " the Charitable", " the Completionist" };

            string name = names[StaticRandom.Instance.Next(0, names.Length)] + suffixes[StaticRandom.Instance.Next(0, suffixes.Length)];
            return name;
        }
        public static int StatGen(int times, int modifier) //input # of times and modifier to generate stats for player/monster
        {
            int result = DieRoller.Roll(times, 6) + DieRoller.Roll(modifier, 6);
            return result;
        }
    }
}
