using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Qual é o seu nome? ");
        string firstName = Console.ReadLine();

        Console.Write("Qual é o seu sobrenome? ");
        string lastName = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine($"Seu nome é {lastName}, {firstName} {lastName}.");
    }
}