using System;
using System.Collections.Generic;
using System.Threading;

public class Atividade
{
    private string _nome;
    private string _descricao;
    private int _duracao;

    public Atividade(string nome, string descricao)
    {
        _nome = nome;
        _descricao = descricao;
        _duracao = 0;
    }

    public string ObterNome()
    {
        return _nome;
    }

    public int ObterDuracao()
    {
        return _duracao;
    }

    public void DefinirDuracao(int duracao)
    {
        _duracao = duracao;
    }

    public void ExibirMensagemInicial()
    {
        Console.Clear();
        Console.WriteLine($"Bem-vindo(a) à {_nome}.");
        Console.WriteLine();
        Console.WriteLine(_descricao);
        Console.WriteLine();
        Console.Write("Quanto tempo, em segundos, você deseja para a sua sessão? ");

        int duracao;
        while (true)
        {
            string entrada = Console.ReadLine();
            if (entrada == null)
            {
                duracao = 5;
                break;
            }

            if (int.TryParse(entrada, out duracao) && duracao > 0)
            {
                break;
            }

            Console.Write("Por favor, digite um número inteiro positivo de segundos: ");
        }
        _duracao = duracao;

        Console.Clear();
        Console.WriteLine("Prepare-se para começar...");
        ExibirProgresso(5);
        Console.WriteLine();
    }

    public void ExibirMensagemFinal()
    {
        Console.WriteLine();
        Console.WriteLine("Muito bem!!");
        ExibirProgresso(4);
        Console.WriteLine();
        Console.WriteLine($"Você concluiu mais {_duracao} segundos da {_nome}.");
        ExibirProgresso(5);
        Console.WriteLine();
    }

    public void ExibirProgresso(int segundos)
    {
        List<string> animacao = new List<string> { "|", "/", "-", "\\" };
        DateTime tempoLimite = DateTime.Now.AddSeconds(segundos);
        int indice = 0;

        while (DateTime.Now < tempoLimite)
        {
            string caractere = animacao[indice % animacao.Count];
            Console.Write(caractere);
            Thread.Sleep(250);
            Console.Write("\b \b");
            indice++;
        }
    }

    public void ExibirContagemRegressiva(int segundos)
    {
        for (int i = segundos; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
