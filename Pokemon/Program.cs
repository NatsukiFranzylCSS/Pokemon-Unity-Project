using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;

namespace PokemonShowdown
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            
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
            bool winner;

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
                Console.WriteLine(firstAttacker.Name + "'s turn:");
                Console.WriteLine("HP:" + firstAttacker.CurrentHP);
                pokemonMove(firstAttacker, secondAttacker);
                Console.ReadLine();
                Console.Clear();

                if (enemyPokemon.CurrentHP <= 0)
                {
                    Console.WriteLine(enemyPokemon.Name + " has fainted!");
                    winner = true;
                    isOver = true;
                    break;
                }

                Console.WriteLine(secondAttacker.Name + "'s turn:");
                Console.WriteLine("HP:" + secondAttacker.CurrentHP);
                pokemonMove(secondAttacker, firstAttacker);
                Console.ReadLine();
                Console.Clear();

                if (playerPokemon.CurrentHP <= 0)
                {
                    Console.WriteLine(playerPokemon.Name + " has fainted!");
                    winner = false;
                    isOver = true;
                    break;
                }
            }
            return;
        }

        static void pokemonMove(Pokemon attacker, Pokemon target)
        {
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
            target.CurrentHP -= FinalDamage;
        }

        static Pokemon Menu()
        {
            bool choiceMade = false;

            while (true)
            {
                var allMoves = GetAllMoves();
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
                        return bulbasaur;
                    default:
                        Console.WriteLine("Choice Failed, press again to retry!");
                        break;
                }
            }
        }
        
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

}