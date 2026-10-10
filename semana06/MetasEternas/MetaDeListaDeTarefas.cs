using System;

public class MetaDeListaDeTarefas : Meta
{
    private int _concluidas;
    private int _total;
    private int _bonus;

    public MetaDeListaDeTarefas(string nome, string descricao, string pontos, int total, int bonus) : base(nome, descricao, pontos)
    {
        _concluidas = 0;
        _total = total;
        _bonus = bonus;
    }

    public MetaDeListaDeTarefas(string nome, string descricao, string pontos, int total, int bonus, int concluidas) : base(nome, descricao, pontos)
    {
        _total = total;
        _bonus = bonus;
        _concluidas = concluidas;
    }

    public int ObterConcluidas()
    {
        return _concluidas;
    }

    public int ObterTotal()
    {
        return _total;
    }

    public int ObterBonus()
    {
        return _bonus;
    }

    public override void RegistrarEvento()
    {
        _concluidas++;
    }

    public override bool EstaConcluida()
    {
        return _concluidas >= _total;
    }

    public override string ObterDetalhesEmTexto()
    {
        string marcador = EstaConcluida() ? "X" : " ";
        return $"[{marcador}] {_nome} ({_descricao}) -- Atualmente concluída: {_concluidas}/{_total}";
    }

    public override string ObterRepresentacaoEmTexto()
    {
        return $"MetaDeListaDeTarefas:{_nome},{_descricao},{_pontos},{_total},{_bonus},{_concluidas}";
    }
}
