using System;

public abstract class Meta
{
    protected string _nome;
    protected string _descricao;
    protected string _pontos;

    public Meta(string nome, string descricao, string pontos)
    {
        _nome = nome;
        _descricao = descricao;
        _pontos = pontos;
    }

    public string ObterNome()
    {
        return _nome;
    }

    public string ObterDescricao()
    {
        return _descricao;
    }

    public string ObterPontosString()
    {
        return _pontos;
    }

    public virtual int ObterPontos()
    {
        return int.TryParse(_pontos, out int valor) ? valor : 0;
    }

    public abstract void RegistrarEvento();

    public abstract bool EstaConcluida();

    public virtual string ObterDetalhesEmTexto()
    {
        string marcador = EstaConcluida() ? "X" : " ";
        return $"[{marcador}] {_nome} ({_descricao})";
    }

    public abstract string ObterRepresentacaoEmTexto();
}
