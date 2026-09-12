// Added a mood tracker (_mood)

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool isRunning = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (isRunning)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("> ");
                string response = Console.ReadLine();

                Console.Write("Current mood (e.g., Happy, Motivated, Tired, Peaceful): ");
                string mood = Console.ReadLine();

                string dateText = DateTime.Now.ToShortDateString();
                Entry entry = new Entry(dateText, prompt, response, mood);
                journal.AddEntry(entry);
                Console.WriteLine();
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "5")
            {
                isRunning = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose an option from 1 to 5.\n");
            }
        }
    }
}