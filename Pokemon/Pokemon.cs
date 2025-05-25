// added on May 25, 2025

using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;

namespace PokemonShowdown
{
    public class Pokemon
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }

        public int BaseHP { get; set; }
        public int BaseAttack { get; set; }
        public int BaseDefense { get; set; }
        public int BaseSpAttack { get; set; }
        public int BaseSpDefense { get; set; }
        public int BaseSpeed { get; set; }

        public int HP { get; set; }
        public int CurrentHP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAttack { get; set; }
        public int SpDefense { get; set; }
        public int Speed { get; set; }
        public List<Move> Move { get; set; }

        public Pokemon(string name, string type1, string type2, int level, int baseHP, int baseAttack, int baseDefense, int baseSpAttack, int baseSpDefense, int baseSpeed)
        {
            Name = name;
            Level = level;
            Type1 = type1;
            Type2 = type2;
            BaseHP = baseHP;
            BaseAttack = baseAttack;
            BaseDefense = baseDefense;
            BaseSpAttack = baseSpAttack;
            BaseSpDefense = baseSpDefense;
            BaseSpeed = baseSpeed;

            HP = ((2 * BaseHP) * Level) / 100 + Level + 10;
            CurrentHP = HP;
            Attack = (((2 * BaseAttack) * Level) / 100) + 5;
            Defense = (((2 * BaseDefense) * Level) / 100) + 5;
            SpAttack = (((2 * BaseSpAttack) * Level) / 100) + 5;
            SpDefense = (((2 * BaseSpDefense) * Level) / 100) + 5;
            Speed = (((2 * BaseSpeed) * Level) / 100) + 5;
        }
    }
}