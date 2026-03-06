using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your fist name? ");
        string firstname = Console.ReadLine();

        Console.Write("What is your last name? ");
        string lastname = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine($"Your name is {lastname}, {firstname} {lastname}.");
    }
}

