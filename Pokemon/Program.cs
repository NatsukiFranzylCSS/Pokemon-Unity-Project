// added on May 25, 2025

using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
// git test
namespace PokemonShowdown
{
    class Program
    {
        static Random rng = new Random();
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
            bool winner = false;

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
                Console.WriteLine("Level " + firstAttacker.Level + ": " + firstAttacker.Name + "'s turn:");
                Console.WriteLine("HP:" + firstAttacker.CurrentHP);
                pokemonMove(firstAttacker, secondAttacker);
                Console.ReadLine();
                Console.Clear();

                if (secondAttacker.CurrentHP <= 0)
                {
                    Console.WriteLine("Level " + secondAttacker.Level + ": " + secondAttacker.Name + " has fainted!");
                    winner = firstAttacker == playerPokemon;
                    isOver = true;
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine(secondAttacker.Name + "'s turn:");
                Console.WriteLine("HP:" + secondAttacker.CurrentHP);
                pokemonMove(secondAttacker, firstAttacker);
                Console.ReadLine();
                Console.Clear();

                if (firstAttacker.CurrentHP <= 0)
                {
                    Console.WriteLine(firstAttacker.Name + " has fainted!");
                    winner = secondAttacker == playerPokemon;
                    isOver = true;
                    Console.ReadLine();
                    break;
                }
            }
            return;
        }

        static void pokemonMove(Pokemon attacker, Pokemon target)
        {
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
            target.CurrentHP -= FinalDamage;
        }

        static Pokemon Menu()
        {
            bool choiceMade = false;
            int level = 10;

            while (true)
            {
                var allMoves = MoveDatabase.GetAllMoves();
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
                        return bulbasaur;
                    default:
                        Console.WriteLine("Choice Failed, press again to retry!");
                        break;
                }
            }
        }
    }
}