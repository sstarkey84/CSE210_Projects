// I added an error message if the user types anything other than hit enter or type quit.  I made it so quit becomes lower case so it doesn't matter how its typed.  I started out hiding 5% of the scripture with each enter.  It took too long so I changed it to 20%.

using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Moroni", 10, 4, 5);
        Scripture scripture = new Scripture(reference, "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost.  And by the power of the Holy Ghost ye may know the truth of all things.");

        string input = "";

        while (input != "quit")
        {
            if (scripture.IsCompletelyHidden() == true)
            {
                break;
            }
        
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press enter or type quit: ");

            input = Console.ReadLine().ToLower();

            if (input == "")
            {
                scripture.HideRandomWords();
            }
            else if (input == "quit")
            {
                break;
            }
            else
            {
                    Console.WriteLine("Invalid input. Press enter to continue or type quit to exit.");
                    Console.ReadLine();
            }
        }
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Progarm ended.");
    }
}