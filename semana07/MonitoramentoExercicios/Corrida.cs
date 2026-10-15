using System;

public class Corrida : Atividade
{
    private double _distancia;

    public Corrida(string data, int minutos, double distancia) : base(data, minutos)
    {
        _distancia = distancia;
    }

    public override double ObterDistancia()
    {
        return _distancia;
    }

    public override double ObterVelocidade()
    {
        if (ObterMinutos() <= 0)
        {
            return 0.0;
        }

        return (_distancia / ObterMinutos()) * 60.0;
    }

    public override double ObterRitmo()
    {
        if (_distancia <= 0)
        {
            return 0.0;
        }

        return ObterMinutos() / _distancia;
    }

    public override string ObterNome()
    {
        return "Corrida";
    }
}
