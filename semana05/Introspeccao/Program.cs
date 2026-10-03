// Foi add perguntas sem repeticao na reflexao, registro de sessoes/estatisticas e animacao visual de respiracao

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> contagemAtividades = new Dictionary<string, int>
        {
            { "Atividade de Respiração", 0 },
            { "Atividade de Reflexão", 0 },
            { "Atividade de Listagem", 0 }
        };

        Dictionary<string, int> tempoAtividades = new Dictionary<string, int>
        {
            { "Atividade de Respiração", 0 },
            { "Atividade de Reflexão", 0 },
            { "Atividade de Listagem", 0 }
        };

        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("Menu Principal:");
            Console.WriteLine("  1. Iniciar atividade de respiração");
            Console.WriteLine("  2. Iniciar atividade de reflexão");
            Console.WriteLine("  3. Iniciar atividade de listagem");
            Console.WriteLine("  4. Exibir registro de atividades");
            Console.WriteLine("  5. Sair");
            Console.Write("Escolha uma opção do menu: ");

            string entrada = Console.ReadLine();
            if (entrada == null)
            {
                break;
            }

            string opcao = entrada.Trim();

            if (opcao == "1")
            {
                AtividadeDeRespiracao atividade = new AtividadeDeRespiracao();
                atividade.Executar();
                contagemAtividades["Atividade de Respiração"]++;
                tempoAtividades["Atividade de Respiração"] += atividade.ObterDuracao();
            }
            else if (opcao == "2")
            {
                AtividadeDeReflexao atividade = new AtividadeDeReflexao();
                atividade.Executar();
                contagemAtividades["Atividade de Reflexão"]++;
                tempoAtividades["Atividade de Reflexão"] += atividade.ObterDuracao();
            }
            else if (opcao == "3")
            {
                AtividadeDeListagem atividade = new AtividadeDeListagem();
                atividade.Executar();
                contagemAtividades["Atividade de Listagem"]++;
                tempoAtividades["Atividade de Listagem"] += atividade.ObterDuracao();
            }
            else if (opcao == "4")
            {
                ExibirRegistroDeAtividades(contagemAtividades, tempoAtividades);
            }
            else if (opcao == "5")
            {
                executando = false;
                Console.Clear();
                Console.WriteLine("Obrigado por usar o Programa de Introspecção!");
                ExibirRegistroDeAtividades(contagemAtividades, tempoAtividades);
            }
            else
            {
                Console.WriteLine("\nOpção inválida. Pressione Enter para tentar novamente.");
                Console.ReadLine();
            }
        }
    }

    static void ExibirRegistroDeAtividades(Dictionary<string, int> contagem, Dictionary<string, int> tempo)
    {
        Console.WriteLine();
        Console.WriteLine("==================================================");
        Console.WriteLine("             REGISTRO DE ATIVIDADES               ");
        Console.WriteLine("==================================================");
        int tempoTotalGeral = 0;
        int sessoesTotais = 0;

        foreach (var item in contagem)
        {
            string nomeAtividade = item.Key;
            int sessoes = item.Value;
            int segundos = tempo[nomeAtividade];
            sessoesTotais += sessoes;
            tempoTotalGeral += segundos;

            Console.WriteLine($"- {nomeAtividade}: {sessoes} sessão(ões) | {segundos} segundos");
        }

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Total geral: {sessoesTotais} sessão(ões) concluída(s) | {tempoTotalGeral} segundos de introspecção.");
        Console.WriteLine("==================================================");
        Console.WriteLine("Pressione Enter para continuar...");
        Console.ReadLine();
    }
}