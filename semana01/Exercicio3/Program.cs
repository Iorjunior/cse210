using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 101);

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("Qual é o seu palpite? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Mais alto");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Mais baixo");
            }
            else
            {
                Console.WriteLine("Você adivinhou!");
            }
        }
    }
}