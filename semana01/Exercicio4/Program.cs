using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userNumber = -1;

        Console.WriteLine("Insira uma lista de números e digite 0 quando terminar.");

        while (userNumber != 0)
        {
            Console.Write("Insira o número: ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        int sum = 0;
        int max = numbers[0];

        foreach (int number in numbers)
        {
            sum += number;
            if (number > max)
            {
                max = number;
            }
        }

        double average = ((double)sum) / numbers.Count;

        Console.WriteLine($"A soma é: {sum}");
        Console.WriteLine($"A média é: {average}");
        Console.WriteLine($"O maior número é: {max}");
    }
}