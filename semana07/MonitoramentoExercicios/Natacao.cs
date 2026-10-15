using System;

public class Natacao : Atividade
{
    private int _voltas;

    public Natacao(string data, int minutos, int voltas) : base(data, minutos)
    {
        _voltas = voltas;
    }

    public override double ObterDistancia()
    {
        return (_voltas * 50.0) / 1000.0;
    }

    public override double ObterVelocidade()
    {
        if (ObterMinutos() <= 0)
        {
            return 0.0;
        }

        return (ObterDistancia() / ObterMinutos()) * 60.0;
    }

    public override double ObterRitmo()
    {
        double distancia = ObterDistancia();
        if (distancia <= 0)
        {
            return 0.0;
        }

        return ObterMinutos() / distancia;
    }

    public override string ObterNome()
    {
        return "Natação";
    }
}
