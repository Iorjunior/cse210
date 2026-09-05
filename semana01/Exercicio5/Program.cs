using System;

class Program
{
    static void Main(string[] args)
    {
        ExibirBoasVindas();

        string userName = PerguntarNomeUsuario();
        int userNumber = PerguntarNumeroFavorito();

        int squaredNumber = ElevarAoQuadrado(userNumber);

        ExibirResultado(userName, squaredNumber);
    }

    static void ExibirBoasVindas()
    {
        Console.WriteLine("Bem-vindo ao programa!");
    }

    static string PerguntarNomeUsuario()
    {
        Console.Write("Por favor, insira seu nome: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PerguntarNumeroFavorito()
    {
        Console.Write("Por favor, insira seu número favorito: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static int ElevarAoQuadrado(int number)
    {
        int square = number * number;
        return square;
    }

    static void ExibirResultado(string name, int square)
    {
        Console.WriteLine($"{name}, o quadrado do seu número é {square}");
    }
}