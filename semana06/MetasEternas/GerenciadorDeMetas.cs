using System;
using System.Collections.Generic;
using System.IO;

public class GerenciadorDeMetas
{
    private List<Meta> _metas;
    private int _pontos;

    public GerenciadorDeMetas()
    {
        _metas = new List<Meta>();
        _pontos = 0;
    }

    public void Iniciar()
    {
        bool continuar = true;

        while (continuar)
        {
            ExibirInfoJogador();

            Console.WriteLine("Opções de Menu:");
            Console.WriteLine("  1. Criar Nova Meta");
            Console.WriteLine("  2. Listar Metas");
            Console.WriteLine("  3. Salvar Metas");
            Console.WriteLine("  4. Carregar Metas");
            Console.WriteLine("  5. Registrar Evento");
            Console.WriteLine("  6. Sair");
            Console.Write("Selecione uma opção do menu: ");

            string entrada = Console.ReadLine();
            string opcao = entrada != null ? entrada.Trim() : "";

            switch (opcao)
            {
                case "1":
                    CriarMeta();
                    break;
                case "2":
                    ListarDetalhesDasMetas();
                    break;
                case "3":
                    SalvarMetas();
                    break;
                case "4":
                    CarregarMetas();
                    break;
                case "5":
                    RegistrarEvento();
                    break;
                case "6":
                    continuar = false;
                    Console.WriteLine("\nObrigado por usar o Programa de Metas Eternas! Até a próxima!\n");
                    break;
                default:
                    Console.WriteLine("\nOpção inválida. Por favor, escolha um número de 1 a 6.\n");
                    break;
            }
        }
    }

    public void ExibirInfoJogador()
    {
        int nivelAtual = ObterNivel(_pontos);
        string tituloAtual = ObterTituloNivel(nivelAtual);
        int pontosProximoNivel = ObterPontosNecessariosParaProximoNivel(nivelAtual);

        Console.WriteLine();
        Console.WriteLine("==================================================");
        Console.WriteLine($" Pontos: {_pontos} | Nível {nivelAtual}: {tituloAtual}");

        if (pontosProximoNivel > 0)
        {
            int baseNivel = ObterPontosBaseNivel(nivelAtual);
            int pontosNoNivel = _pontos - baseNivel;
            int totalNecessario = pontosProximoNivel - baseNivel;
            int porcentagem = Math.Clamp((int)((double)pontosNoNivel / totalNecessario * 100), 0, 100);

            int barrasPreenchidas = porcentagem / 5;
            string barra = new string('=', barrasPreenchidas).PadRight(20, ' ');
            int faltam = pontosProximoNivel - _pontos;

            Console.WriteLine($" Progresso: [{barra}] {porcentagem}% (Faltam {faltam} pts para o Nível {nivelAtual + 1})");
        }
        else
        {
            Console.WriteLine(" Progresso: [====================] 100% (Nível Máximo Atingido!)");
        }

        Console.WriteLine("==================================================");
        Console.WriteLine();
    }

    public void ListarNomesDasMetas()
    {
        Console.WriteLine("As metas são:");
        for (int i = 0; i < _metas.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_metas[i].ObterNome()}");
        }
    }

    public void ListarDetalhesDasMetas()
    {
        Console.WriteLine();
        if (_metas.Count == 0)
        {
            Console.WriteLine("Nenhuma meta cadastrada no momento.");
        }
        else
        {
            Console.WriteLine("As metas são:");
            for (int i = 0; i < _metas.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {_metas[i].ObterDetalhesEmTexto()}");
            }
        }
        Console.WriteLine();
    }

    public void CriarMeta()
    {
        Console.WriteLine("\nOs tipos de Metas são:");
        Console.WriteLine("  1. Meta Simples");
        Console.WriteLine("  2. Meta Eterna");
        Console.WriteLine("  3. Meta de Lista de Tarefas");
        Console.Write("Qual tipo de meta você gostaria de criar? ");

        string tipo = Console.ReadLine()?.Trim();

        if (tipo != "1" && tipo != "2" && tipo != "3")
        {
            Console.WriteLine("Tipo de meta inválido.\n");
            return;
        }

        Console.Write("Qual é o nome da sua meta? ");
        string nome = Console.ReadLine()?.Trim() ?? "";

        Console.Write("Qual é uma breve descrição dela? ");
        string descricao = Console.ReadLine()?.Trim() ?? "";

        Console.Write("Qual é a quantidade de pontos associada a esta meta? ");
        string pontos = Console.ReadLine()?.Trim() ?? "0";

        if (tipo == "1")
        {
            _metas.Add(new MetaSimples(nome, descricao, pontos));
            Console.WriteLine("Meta Simples criada com sucesso!\n");
        }
        else if (tipo == "2")
        {
            _metas.Add(new MetaEterna(nome, descricao, pontos));
            Console.WriteLine("Meta Eterna criada com sucesso!\n");
        }
        else if (tipo == "3")
        {
            Console.Write("Quantas vezes essa meta precisa ser realizada para receber um bônus? ");
            int total;
            while (!int.TryParse(Console.ReadLine(), out total) || total <= 0)
            {
                Console.Write("Por favor, digite um número inteiro positivo: ");
            }

            Console.Write("Qual é o bônus por realizá-la essa quantidade de vezes? ");
            int bonus;
            while (!int.TryParse(Console.ReadLine(), out bonus) || bonus < 0)
            {
                Console.Write("Por favor, digite um número inteiro não-negativo: ");
            }

            _metas.Add(new MetaDeListaDeTarefas(nome, descricao, pontos, total, bonus));
            Console.WriteLine("Meta de Lista de Tarefas criada com sucesso!\n");
        }
    }

    public void RegistrarEvento()
    {
        Console.WriteLine();
        if (_metas.Count == 0)
        {
            Console.WriteLine("Você ainda não possui metas cadastradas para registrar um evento.\n");
            return;
        }

        ListarNomesDasMetas();
        Console.Write("Qual meta você realizou? ");

        int indice;
        if (!int.TryParse(Console.ReadLine(), out indice) || indice < 1 || indice > _metas.Count)
        {
            Console.WriteLine("Seleção de meta inválida.\n");
            return;
        }

        Meta metaEscolhida = _metas[indice - 1];

        if (metaEscolhida.EstaConcluida())
        {
            Console.WriteLine("\nEsta meta já foi concluída anteriormente! Não é possível registrá-la novamente.\n");
            return;
        }

        int nivelAntes = ObterNivel(_pontos);
        int pontosGanhos = metaEscolhida.ObterPontos();
        bool bonusConcedido = false;
        int valorBonus = 0;

        metaEscolhida.RegistrarEvento();

        if (metaEscolhida is MetaDeListaDeTarefas checklist)
        {
            if (checklist.EstaConcluida())
            {
                bonusConcedido = true;
                valorBonus = checklist.ObterBonus();
                pontosGanhos += valorBonus;
            }
        }

        _pontos += pontosGanhos;

        Console.WriteLine();
        if (bonusConcedido)
        {
            Console.WriteLine($"*** PARABÉNS! Você completou todas as etapas desta meta e recebeu um BÔNUS de {valorBonus} pontos! ***");
        }
        Console.WriteLine($"Parabéns! Você ganhou {pontosGanhos} pontos!");
        Console.WriteLine($"Você agora tem {_pontos} pontos.");

        int nivelDepois = ObterNivel(_pontos);
        if (nivelDepois > nivelAntes)
        {
            ExibirComemoracaoSubidaNivel(nivelDepois);
        }
        Console.WriteLine();
    }

    public void SalvarMetas()
    {
        Console.Write("\nQual é o nome do arquivo para o arquivo de meta? ");
        string nomeArquivo = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(nomeArquivo))
        {
            Console.WriteLine("Nome de arquivo inválido.\n");
            return;
        }

        try
        {
            using (StreamWriter arquivoSaida = new StreamWriter(nomeArquivo))
            {
                arquivoSaida.WriteLine(_pontos);
                foreach (Meta meta in _metas)
                {
                    arquivoSaida.WriteLine(meta.ObterRepresentacaoEmTexto());
                }
            }
            Console.WriteLine($"Metas salvas com sucesso no arquivo '{nomeArquivo}'!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar o arquivo: {ex.Message}\n");
        }
    }

    public void CarregarMetas()
    {
        Console.Write("\nQual é o nome do arquivo para o arquivo de meta? ");
        string nomeArquivo = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(nomeArquivo))
        {
            Console.WriteLine("Nome de arquivo inválido.\n");
            return;
        }

        if (!File.Exists(nomeArquivo))
        {
            Console.WriteLine($"O arquivo '{nomeArquivo}' não foi encontrado.\n");
            return;
        }

        try
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            if (linhas.Length == 0)
            {
                Console.WriteLine("O arquivo está vazio.\n");
                return;
            }

            if (int.TryParse(linhas[0], out int pontosLidos))
            {
                _pontos = pontosLidos;
            }

            _metas.Clear();

            for (int i = 1; i < linhas.Length; i++)
            {
                string linha = linhas[i].Trim();
                if (string.IsNullOrWhiteSpace(linha))
                {
                    continue;
                }

                string[] partesTipo = linha.Split(":");
                if (partesTipo.Length < 2)
                {
                    continue;
                }

                string tipo = partesTipo[0];
                string[] dados = partesTipo[1].Split(",");

                if (tipo == "MetaSimples" && dados.Length >= 4)
                {
                    string nome = dados[0];
                    string descricao = dados[1];
                    string pontos = dados[2];
                    bool estaConcluida = bool.Parse(dados[3]);
                    _metas.Add(new MetaSimples(nome, descricao, pontos, estaConcluida));
                }
                else if (tipo == "MetaEterna" && dados.Length >= 3)
                {
                    string nome = dados[0];
                    string descricao = dados[1];
                    string pontos = dados[2];
                    _metas.Add(new MetaEterna(nome, descricao, pontos));
                }
                else if (tipo == "MetaDeListaDeTarefas" && dados.Length >= 6)
                {
                    string nome = dados[0];
                    string descricao = dados[1];
                    string pontos = dados[2];
                    int total = int.Parse(dados[3]);
                    int bonus = int.Parse(dados[4]);
                    int concluidas = int.Parse(dados[5]);
                    _metas.Add(new MetaDeListaDeTarefas(nome, descricao, pontos, total, bonus, concluidas));
                }
            }

            Console.WriteLine($"Metas carregadas com sucesso! {_metas.Count} meta(s) carregada(s).\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar o arquivo: {ex.Message}\n");
        }
    }

    private int ObterNivel(int pontos)
    {
        if (pontos >= 3500) return 6;
        if (pontos >= 2200) return 5;
        if (pontos >= 1300) return 4;
        if (pontos >= 700) return 3;
        if (pontos >= 300) return 2;
        return 1;
    }

    private string ObterTituloNivel(int nivel)
    {
        switch (nivel)
        {
            case 1: return "Novato das Metas";
            case 2: return "Aspirante Determinado";
            case 3: return "Guerreiro da Disciplina";
            case 4: return "Mestre dos Hábitos";
            case 5: return "Campeão da Jornada";
            case 6: return "Lenda da Missão Eterna";
            default: return "Lenda Suprema";
        }
    }

    private int ObterPontosBaseNivel(int nivel)
    {
        switch (nivel)
        {
            case 1: return 0;
            case 2: return 300;
            case 3: return 700;
            case 4: return 1300;
            case 5: return 2200;
            case 6: return 3500;
            default: return 3500;
        }
    }

    private int ObterPontosNecessariosParaProximoNivel(int nivel)
    {
        switch (nivel)
        {
            case 1: return 300;
            case 2: return 700;
            case 3: return 1300;
            case 4: return 2200;
            case 5: return 3500;
            default: return -1; // Nível máximo
        }
    }

    private void ExibirComemoracaoSubidaNivel(int novoNivel)
    {
        string novoTitulo = ObterTituloNivel(novoNivel);
        Console.WriteLine();
        Console.WriteLine("**************************************************");
        Console.WriteLine("             ★ SUBIU DE NÍVEL! ★                  ");
        Console.WriteLine($"  Você alcançou o Nível {novoNivel}: {novoTitulo}!");
        Console.WriteLine("  Continue firme na sua jornada de progresso!");
        Console.WriteLine("**************************************************");
    }
}
