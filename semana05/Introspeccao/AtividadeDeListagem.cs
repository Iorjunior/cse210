using System;
using System.Collections.Generic;

public class AtividadeDeListagem : Atividade
{
    private int _contador;
    private List<string> _perguntas;
    private Random _random;

    public AtividadeDeListagem() : base(
        "Atividade de Listagem",
        "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, fazendo com que você liste o máximo de coisas que puder em uma determinada área.")
    {
        _contador = 0;
        _random = new Random();

        _perguntas = new List<string>
        {
            "Quem são as pessoas que você aprecia?",
            "Quais são seus pontos fortes pessoais?",
            "Quem são as pessoas que você ajudou esta semana?",
            "Quando você sentiu o Espírito Santo neste mês?",
            "Quem são alguns dos seus heróis pessoais?"
        };
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        Console.WriteLine("Liste tantas respostas quanto puder para a seguinte mensagem:");
        Console.WriteLine($" --- {ObterPerguntaAleatoria()} ---");
        Console.Write("Você pode começar em: ");
        ExibirContagemRegressiva(5);
        Console.WriteLine();

        List<string> itens = ObterListaDoUsuario();
        _contador = itens.Count;

        Console.WriteLine($"Você listou {_contador} itens!");

        ExibirMensagemFinal();
    }

    public string ObterPerguntaAleatoria()
    {
        int indice = _random.Next(_perguntas.Count);
        return _perguntas[indice];
    }

    public List<string> ObterListaDoUsuario()
    {
        List<string> itens = new List<string>();
        DateTime tempoFinal = DateTime.Now.AddSeconds(ObterDuracao());

        while (DateTime.Now < tempoFinal)
        {
            Console.Write("> ");
            string resposta = Console.ReadLine();
            if (resposta == null)
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(resposta))
            {
                itens.Add(resposta.Trim());
            }
        }

        return itens;
    }
}
