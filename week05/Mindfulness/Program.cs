// Made it so questions do not repeat back to back.  Inside ReflectingActivity.


using System;

class Program
{
    static void Main(string[] args)
    {
        string choice = "";
        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start breathing activity");
            Console.WriteLine(" 2. Start reflecting activity");
            Console.WriteLine(" 3. Start listing activity");
            Console.WriteLine(" 4. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();

                Console.WriteLine("\nPress Enter to return to the menu.");
                Console.ReadLine();
            }
            else if (choice == "2")
            {
                ReflectingActivity activity = new ReflectingActivity();
                activity.Run();

                Console.WriteLine("\nPress Enter to return to the menu.");
                Console.ReadLine();
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();

                Console.WriteLine("\nPress Enter to return to the menu.");
                Console.ReadLine();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("\nInvalid choice.");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
            }
        }
    }
}