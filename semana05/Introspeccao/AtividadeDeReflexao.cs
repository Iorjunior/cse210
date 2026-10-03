using System;
using System.Collections.Generic;

public class AtividadeDeReflexao : Atividade
{
    private List<string> _reflexoes;
    private List<string> _perguntas;
    private List<string> _perguntasNaoUtilizadas;
    private Random _random;

    public AtividadeDeReflexao() : base(
        "Atividade de Reflexão",
        "Esta atividade ajudará você a refletir sobre momentos da sua vida em que você demonstrou força e resiliência. Isso ajudará você a reconhecer o poder que você tem e como pode usá-lo em outros aspectos da sua vida.")
    {
        _random = new Random();

        _reflexoes = new List<string>
        {
            "Pense em uma ocasião em que você defendeu outra pessoa.",
            "Pense em uma ocasião em que você fez algo realmente difícil.",
            "Pense em uma ocasião em que você ajudou alguém necessitado.",
            "Pense em uma ocasião em que você fez algo verdadeiramente altruísta."
        };

        _perguntas = new List<string>
        {
            "Por que essa experiência foi significativa para você?",
            "Você já fez algo assim antes?",
            "Como você começou?",
            "Como você se sentiu quando terminou?",
            "O que tornou esse momento diferente de outras vezes em que você não teve tanto sucesso?",
            "Qual é a sua coisa favorita sobre essa experiência?",
            "O que você pode aprender com essa experiência que se aplica a outras situações?",
            "O que você aprendeu sobre si mesmo por meio dessa experiência?",
            "Como você pode manter essa experiência em mente no futuro?"
        };

        _perguntasNaoUtilizadas = new List<string>(_perguntas);
    }

    public void Executar()
    {
        ExibirMensagemInicial();
        ExibirReflexoes();
        ExibirPerguntas();
        ExibirMensagemFinal();
    }

    public string ObterReflexoesAleatorias()
    {
        int indice = _random.Next(_reflexoes.Count);
        return _reflexoes[indice];
    }

    public string ObterPerguntasAleatorias()
    {
        if (_perguntasNaoUtilizadas.Count == 0)
        {
            _perguntasNaoUtilizadas = new List<string>(_perguntas);
        }

        int indice = _random.Next(_perguntasNaoUtilizadas.Count);
        string perguntaSelecionada = _perguntasNaoUtilizadas[indice];
        _perguntasNaoUtilizadas.RemoveAt(indice);

        return perguntaSelecionada;
    }

    public void ExibirReflexoes()
    {
        Console.WriteLine("Considere a seguinte mensagem:");
        Console.WriteLine();
        Console.WriteLine($" --- {ObterReflexoesAleatorias()} ---");
        Console.WriteLine();
        Console.WriteLine("Quando tiver pensado em algo, pressione Enter para continuar.");
        Console.ReadLine();

        Console.WriteLine("Agora reflita sobre cada uma das seguintes perguntas relacionadas a esta experiência.");
        Console.Write("Você pode começar em: ");
        ExibirContagemRegressiva(5);
        Console.Clear();
    }

    public void ExibirPerguntas()
    {
        DateTime tempoFinal = DateTime.Now.AddSeconds(ObterDuracao());

        while (DateTime.Now < tempoFinal)
        {
            string pergunta = ObterPerguntasAleatorias();
            Console.Write($"> {pergunta} ");
            ExibirProgresso(5);
            Console.WriteLine();
        }
    }
}
