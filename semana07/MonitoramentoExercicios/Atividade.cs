using System;
using System.Globalization;

public abstract class Atividade
{
    private string _data;
    private int _minutos;

    public Atividade(string data, int minutos)
    {
        _data = data;
        _minutos = minutos;
    }

    public string ObterData()
    {
        return _data;
    }

    public int ObterMinutos()
    {
        return _minutos;
    }

    public abstract double ObterDistancia();

    public abstract double ObterVelocidade();

    public abstract double ObterRitmo();

    public virtual string ObterNome()
    {
        return GetType().Name;
    }

    public virtual string ObterResumo()
    {
        string distanciaFormatada = ObterDistancia().ToString("0.0", CultureInfo.InvariantCulture);
        string velocidadeFormatada = ObterVelocidade().ToString("0.0", CultureInfo.InvariantCulture);
        string ritmoFormatada = ObterRitmo().ToString("0.0#", CultureInfo.InvariantCulture);

        return $"{_data} {ObterNome()} ({_minutos} min): Distância {distanciaFormatada} km, Velocidade: {velocidadeFormatada} km/h, Ritmo: {ritmoFormatada} min por km";
    }

    public double GetDistance()
    {
        return ObterDistancia();
    }

    public double GetSpeed()
    {
        return ObterVelocidade();
    }

    public double GetPace()
    {
        return ObterRitmo();
    }

    public string GetSummary()
    {
        return ObterResumo();
    }
}
