using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Qual é a sua porcentagem de nota? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Sua nota é: {letter}");

        if (percent >= 70)
        {
            Console.WriteLine("Parabéns! Você foi aprovado!");
        }
        else
        {
            Console.WriteLine("Não desista! Continue tentando na próxima vez!");
        }
    }
}