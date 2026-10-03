using System;
using System.Threading;

public class AtividadeDeRespiracao : Atividade
{
    public AtividadeDeRespiracao() : base(
        "Atividade de Respiração",
        "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. Limpe sua mente e concentre-se na sua respiração.")
    {
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        DateTime tempoFinal = DateTime.Now.AddSeconds(ObterDuracao());

        while (DateTime.Now < tempoFinal)
        {
            Console.Write("Inspire... ");
            ExibirRespiracaoComContagem(4, true);
            Console.WriteLine();

            if (DateTime.Now >= tempoFinal)
            {
                break;
            }

            Console.Write("Agora expire... ");
            ExibirRespiracaoComContagem(6, false);
            Console.WriteLine();
            Console.WriteLine();
        }

        ExibirMensagemFinal();
    }

    private void ExibirRespiracaoComContagem(int segundos, bool inspirando)
    {
        for (int i = segundos; i > 0; i--)
        {
            int passos = inspirando ? (segundos - i + 1) : i;
            string barra = new string('=', passos * 2);
            string indicador = $"{i} [{barra}]";
            Console.Write(indicador);
            Thread.Sleep(1000);

            for (int j = 0; j < indicador.Length; j++)
            {
                Console.Write("\b \b");
            }
        }
    }
}
