using System;
using System.Collections.Generic;

namespace PokemonShowdown
{
    public class MoveDatabase
    {
        public static Dictionary<string, Move> GetAllMoves()
        {
            return new Dictionary<string, Move>()
            {
                    { "Scratch", new Move("Scratch", "Normal", 40, 100, 35) },
                    { "Tackle", new Move("Tackle", "Normal", 40, 100, 35) },
                    { "Water Gun", new Move("Water Gun", "Water", 40, 100, 25) },
                    { "Ember", new Move("Ember", "Fire", 40, 100, 25) },
                    { "Vine Whip", new Move("Vine Whip", "Grass", 45, 100, 25) },
                    { "Quick Attack", new Move("Quick Attack", "Normal", 40, 100, 30) },
                    { "Bite", new Move("Bite", "Dark", 60, 100, 25) },
                    { "Thunder Shock", new Move("Thunder Shock", "Electric", 40, 100, 30) },
                    { "Confusion", new Move("Confusion", "Psychic", 50, 100, 25) },
                    { "Acid", new Move("Acid", "Poison", 40, 100, 30) },
                    { "Flamethrower", new Move("Flamethrower", "Fire", 90, 100, 15) },
                    { "Hydro Pump", new Move("Hydro Pump", "Water", 110, 80, 5) },
                    { "Solar Beam", new Move("Solar Beam", "Grass", 120, 100, 10) },
                    { "Thunderbolt", new Move("Thunderbolt", "Electric", 90, 100, 15) },
                    { "Growl", new Move("Growl", "Normal", 0, 100, 40) },
                    { "Tail Whip", new Move("Tail Whip", "Normal", 0, 100, 30) },
                    { "Harden", new Move("Harden", "Normal", 0, -1, 30) }
            };
        }
    }
}