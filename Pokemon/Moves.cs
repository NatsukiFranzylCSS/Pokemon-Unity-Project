// added on May 25, 2025
// move structure
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;

namespace PokemonShowdown
{
    public class Move
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Power { get; set; }
        public int Accuracy { get; set; }
        public int PP { get; set; }

        public Move(string name, string type, int power, int accuracy, int pp)
        {
            Name = name;
            Type = type;
            Power = power;
            Accuracy = accuracy;
            PP = pp;
        }
    }
}