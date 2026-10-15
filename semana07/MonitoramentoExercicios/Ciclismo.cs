using System;

public class Ciclismo : Atividade
{
    private double _velocidade;

    public Ciclismo(string data, int minutos, double velocidade) : base(data, minutos)
    {
        _velocidade = velocidade;
    }

    public override double ObterDistancia()
    {
        return (_velocidade * ObterMinutos()) / 60.0;
    }

    public override double ObterVelocidade()
    {
        return _velocidade;
    }

    public override double ObterRitmo()
    {
        if (_velocidade <= 0)
        {
            return 0.0;
        }

        return 60.0 / _velocidade;
    }

    public override string ObterNome()
    {
        return "Ciclismo";
    }
}
