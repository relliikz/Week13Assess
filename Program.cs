using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Week13Assess
{
    class Program
    {
        static List<int> rolls = new List<int>();
        static void Main(string[] args)
        {
            while(true){
                Console.Clear();
                Console.WriteLine("Welcome to the DiceRoll Menu!");
                Console.WriteLine("Please select a menu item (1-5)");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Roll Dice\n2. Calculate Key Values\n3. List Rolls\n4. Delete rolls\n5. Exit");
                string selection = Console.ReadLine();

                if (selection == "1"){
                    RollDice();
                }
                if (selection == "2"){
                    KeyValsCalc();
                }
                if (selection == "3"){
                    RollsList();
                }
                if (selection == "4"){
                    using (StreamWriter writer = new StreamWriter("./rolls.txt", false))
                    {
                    writer.Write("");
                    }
                    Console.WriteLine("Rolls Deleted");
                }
                if (selection == "5"){
                    Console.WriteLine("Thanks for playing!");
                    Environment.Exit(0);
                }

                static void RollDice(){
                Console.Clear();

                Random r = new Random();
                List<int> RollStorage = new List<int>();

                Console.WriteLine("How many dice would you like to roll?");
                string diceAmount = Console.ReadLine();

                for(int i = 0; i < int.Parse(diceAmount); i++){
                    int roll = r.Next(1,7);
                    Console.WriteLine("Roll #" + (i+1));
                    Console.WriteLine(roll);
                    rolls.Add(roll);
                    RollStorage.Add(roll);
                }
                while(true){
                    using (StreamWriter writer = new StreamWriter("./rolls.txt", true))
                {
                    foreach (int roll in RollStorage)
                    {
                        writer.WriteLine(roll);
                    }
                }
                Console.WriteLine("Would you like to roll again?");
                string rollResponse = Console.ReadLine().ToUpper();
                if(rollResponse == "Y"){
                    RollDice();
                    break;
                } else {
                Console.WriteLine("Would you like to return? (Y/N)");
                string response = Console.ReadLine().ToUpper();
                if(response == "Y"){
                break;
                } else {
                Console.WriteLine("Thanks for playing!");
                Environment.Exit(0);
                        }
                    }
                }
                }
                static void KeyValsCalc() {
                    while(true){
                        Console.Clear();
                        Console.WriteLine("The key values are as follows: \n--------------------");
                        //Calculates the Average of the rolls
                        Console.WriteLine("The Average of all rolls was " + rolls.Average());
                        //Calculates the total of the rolls
                        Console.WriteLine("The Total of all rolls was " + rolls.Sum());
                        Console.WriteLine("Would you like to return? (Y/N)");
                        string response = Console.ReadLine().ToUpper();
                        if(response == "Y"){
                        break;
                        } else {
                        Console.WriteLine("Thanks for playing!");
                        Environment.Exit(0);
                        }
                    }
                }
                static void RollsList(){
                while(true){
                    Console.Clear();
                    foreach(int roll in rolls)
                    {
                        Console.WriteLine(roll);
                    }
                    Console.WriteLine("Would you like to return? (Y/N)");
                    string response = Console.ReadLine().ToUpper();
                    if (response == "Y")
                        {
                        break;
                        } else {
                        Console.WriteLine("Thanks for playing!");
                        Environment.Exit(0);
                            }     
                    }
                }
            }
        }
    }
}
