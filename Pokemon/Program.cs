<<<<<<< HEAD
// added on May 25, 2025

using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
// git test
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;

>>>>>>> 1618b2485e1e39baef421e09aa69a515bcd81a41
namespace PokemonShowdown
{
    class Program
    {
<<<<<<< HEAD
        static Random rng = new Random();
        static void Main(string[] args)
        {
            Console.Clear();

=======
        static void Main(string[] args)
        {
            Console.Clear();
            
>>>>>>> 1618b2485e1e39baef421e09aa69a515bcd81a41
            Pokemon playerPokemon = null;
            Pokemon enemyPokemon = null;

            Console.WriteLine("Welcome to Pokemon Showdown");

            Console.WriteLine("Please select your pokemon:");
            playerPokemon = Menu();

            Console.WriteLine("Please select enemy pokemon:");
            enemyPokemon = Menu();

            Console.Clear();
            Console.WriteLine("Battle Begin!");

            Battle(playerPokemon, enemyPokemon);
        }

        static void Battle(Pokemon playerPokemon, Pokemon enemyPokemon)
        {
            Pokemon firstAttacker, secondAttacker;

            bool isOver = false;
<<<<<<< HEAD
            bool winner = false;
=======
            bool winner;
>>>>>>> 1618b2485e1e39baef421e09aa69a515bcd81a41

            if (playerPokemon.Speed >= enemyPokemon.Speed)
            {
                firstAttacker = playerPokemon;
                secondAttacker = enemyPokemon;
            }
            else
            {
                firstAttacker = enemyPokemon;
                secondAttacker = playerPokemon;
            }

            while (!isOver)
            {
<<<<<<< HEAD
                Console.WriteLine("Level " + firstAttacker.Level + ": " + firstAttacker.Name + "'s turn:");
=======
                Console.WriteLine(firstAttacker.Name + "'s turn:");
>>>>>>> 1618b2485e1e39baef421e09aa69a515bcd81a41
                Console.WriteLine("HP:" + firstAttacker.CurrentHP);
                pokemonMove(firstAttacker, secondAttacker);
                Console.ReadLine();
                Console.Clear();

<<<<<<< HEAD
                if (secondAttacker.CurrentHP <= 0)
                {
                    Console.WriteLine("Level " + secondAttacker.Level + ": " + secondAttacker.Name + " has fainted!");
                    winner = firstAttacker == playerPokemon;
                    isOver = true;
                    Console.ReadLine();
=======
                if (enemyPokemon.CurrentHP <= 0)
                {
                    Console.WriteLine(enemyPokemon.Name + " has fainted!");
                    winner = true;
                    isOver = true;
>>>>>>> 1618b2485e1e39baef421e09aa69a515bcd81a41
                    break;
                }

                Console.WriteLine(secondAttacker.Name + "'s turn:");
                Console.WriteLine("HP:" + secondAttacker.CurrentHP);
                pokemonMove(secondAttacker, firstAttacker);
                Console.ReadLine();
                Console.Clear();

<<<<<<< HEAD
                if (firstAttacker.CurrentHP <= 0)
                {
                    Console.WriteLine(firstAttacker.Name + " has fainted!");
                    winner = secondAttacker == playerPokemon;
                    isOver = true;
                    Console.ReadLine();
=======
                if (playerPokemon.CurrentHP <= 0)
                {
                    Console.WriteLine(playerPokemon.Name + " has fainted!");
                    winner = false;
                    isOver = true;
>>>>>>> 1618b2485e1e39baef421e09aa69a515bcd81a41
                    break;
                }
            }
            return;
        }

        static void pokemonMove(Pokemon attacker, Pokemon target)
        {
<<<<<<< HEAD
            double CriticalRate = 1;
            bool isCritical = rng.Next(0, 100) < 5;
            int movechoice = -1;
            Move currentMove = attacker.Move[0];
            Console.WriteLine("Available Moves:");
            Console.WriteLine("1: " + attacker.Move[0].Name);
            Console.WriteLine("2: " + attacker.Move[1].Name);
            Console.WriteLine("3: " + attacker.Move[2].Name);
            Console.WriteLine("4: " + attacker.Move[3].Name);

            while (movechoice < 0 || movechoice > 3)
            {
                Console.WriteLine("Select?");
                string input = Console.ReadLine();

                if (int.TryParse(input, out movechoice) && movechoice >= 1 && movechoice <= attacker.Move.Count)
                {
                    currentMove = attacker.Move[movechoice - 1]; // Adjust for 0-based index
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                }
            }

            if (isCritical == true)
            {
                CriticalRate = 1.5;
            }

            Console.WriteLine(attacker.Name + " used " + currentMove.Name);

            int Damage = ((((2 * attacker.Level) / 5) * currentMove.Power * (attacker.Attack / target.Defense) / 50) + 2);
            int FinalDamage = (int)Math.Round(Damage * CriticalRate);
=======
            int movechoice;
            Move currentMove = attacker.Move[0];
            Console.WriteLine("Available Moves:");
            Console.WriteLine(attacker.Move[0].Name);
            Console.WriteLine(attacker.Move[1].Name);

            Console.WriteLine("Select?");
            movechoice = int.Parse(Console.ReadLine());

            switch (movechoice)
            {
                case 1:
                    currentMove = attacker.Move[0];
                    break;
                case 2:
                    currentMove = attacker.Move[1];
                    break;
                default:
                    break;
            }

            Console.WriteLine(attacker.Name + " used " + currentMove.Name);
            // 100 = Power but i'll fix that soon
            int Damage = ((((2 * attacker.Level) / 5) * currentMove.Power * (attacker.Attack / target.Defense) / 50) + 2);
            int FinalDamage = Damage * 1;
            // 1 is a placeholder for multipliers
>>>>>>> 1618b2485e1e39baef421e09aa69a515bcd81a41
            target.CurrentHP -= FinalDamage;
        }

        static Pokemon Menu()
        {
            bool choiceMade = false;
<<<<<<< HEAD
            int level = 10;

            while (true)
            {
                var allMoves = MoveDatabase.GetAllMoves();
=======

            while (true)
            {
                var allMoves = GetAllMoves();
>>>>>>> 1618b2485e1e39baef421e09aa69a515bcd81a41
                Console.WriteLine("1: Charmander");
                Console.WriteLine("2: Squirtle");
                Console.WriteLine("3: Bulbasaur");

                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
<<<<<<< HEAD
                        Console.WriteLine("Select Level: (0 - 100)");
                        level = int.Parse(Console.ReadLine());
                        Pokemon charmander = new Pokemon("Charmander", "Fire", null, level, 39, 52, 43, 60, 50, 65);
                        charmander.Move = new List<Move> { allMoves["Scratch"], allMoves["Ember"], allMoves["Bite"], allMoves["Flamethrower"] };
                        return charmander;
                    case 2:
                        Console.WriteLine("Select Level: (0 - 100)");
                        level = int.Parse(Console.ReadLine());
                        Pokemon squirtle = new Pokemon("Squirtle", "Water", null, level, 44, 48, 65, 50, 64, 43);
                        squirtle.Move = new List<Move> { allMoves["Tackle"], allMoves["Water Gun"], allMoves["Hydro Pump"], allMoves["Tail Whip"] };
                        return squirtle;
                    case 3:
                        Console.WriteLine("Select Level: (0 - 100)");
                        level = int.Parse(Console.ReadLine());
                        Pokemon bulbasaur = new Pokemon("Bulbasaur", "Grass", "Poision", level, 45, 49, 49, 65, 65, 45);
                        bulbasaur.Move = new List<Move> { allMoves["Tackle"], allMoves["Vine Whip"], allMoves["Acid"], allMoves["Solar Beam"] };
=======
                        Pokemon charmander = new Pokemon("Charmander", "Fire", null, 50, 39, 52, 43, 60, 50, 65);
                        charmander.Move = new List<Move> { allMoves["Scratch"], allMoves["Ember"] };
                        return charmander;
                    case 2:
                        Pokemon squirtle = new Pokemon("Squirtle", "Water", null, 70, 44, 48, 65, 50, 64, 43);
                        squirtle.Move = new List<Move> { allMoves["Tackle"], allMoves["Water Gun"] };
                        return squirtle;
                    case 3:
                        Pokemon bulbasaur = new Pokemon("Bulbasaur", "Grass", "Poision", 50, 45, 49, 49, 65, 65, 45);
                        bulbasaur.Move = new List<Move> { allMoves["Tackle"], allMoves["Vine Whip"] };
>>>>>>> 1618b2485e1e39baef421e09aa69a515bcd81a41
                        return bulbasaur;
                    default:
                        Console.WriteLine("Choice Failed, press again to retry!");
                        break;
                }
            }
        }
<<<<<<< HEAD
    }
=======
        
        static Dictionary<string, Move> GetAllMoves()
        {
            return new Dictionary<string, Move>()
            {
                { "Scratch", new Move("Scratch", "Normal", 40, 100, 35) },
                { "Tackle", new Move("Scratch", "Normal", 40, 100, 35) },
                { "Water Gun", new Move("Water Gun", "Water", 40, 100, 25) },
                { "Ember", new Move("Ember", "Fire", 40, 100, 25) },
                { "Vine Whip", new Move("Vine Whip", "Fire", 40, 100, 25) }
            };
        }
    }

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

>>>>>>> 1618b2485e1e39baef421e09aa69a515bcd81a41
}