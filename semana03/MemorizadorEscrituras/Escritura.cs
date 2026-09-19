using System;
using System.Collections.Generic;
using System.Linq;

public class Escritura
{
    private Referencia _referencia;
    private List<Palavra> _palavras;

    public Escritura(Referencia referencia, string texto)
    {
        _referencia = referencia;
        _palavras = new List<Palavra>();

        string[] partes = texto.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string parte in partes)
        {
            _palavras.Add(new Palavra(parte));
        }
    }

    public void OcultarPalavrasAleatorias(int numeroParaOcultar)
    {
        Random random = new Random();
        List<Palavra> palavrasVisiveis = _palavras.Where(p => !p.EstaOculta()).ToList();

        int quantidadeParaOcultar = Math.Min(numeroParaOcultar, palavrasVisiveis.Count);
        for (int i = 0; i < quantidadeParaOcultar; i++)
        {
            int indice = random.Next(palavrasVisiveis.Count);
            palavrasVisiveis[indice].Ocultar();
            palavrasVisiveis.RemoveAt(indice);
        }
    }

    public string ObterTexto()
    {
        List<string> partesTexto = new List<string>();
        foreach (Palavra palavra in _palavras)
        {
            partesTexto.Add(palavra.ObterTexto());
        }

        return $"{_referencia.ObterTexto()} {string.Join(" ", partesTexto)}";
    }

    public bool EstaCompletamenteOculta()
    {
        return _palavras.All(p => p.EstaOculta());
    }
}
