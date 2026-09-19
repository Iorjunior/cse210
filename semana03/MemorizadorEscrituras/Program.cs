// o programa seleciona aleatoriamente apenas as palavras que nao estao ocultas

using System;

class Program
{
    static void Main(string[] args)
    {
        Referencia referencia = new Referencia("Provérbios", 3, 5, 6);
        string texto = "Confia no Senhor de todo o teu coração e não te estribes no teu próprio entendimento. Reconhece-o em todos os teus caminhos, e ele endireitará as tuas veredas.";
        Escritura escritura = new Escritura(referencia, texto);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(escritura.ObterTexto());
            Console.WriteLine();

            if (escritura.EstaCompletamenteOculta())
            {
                break;
            }

            Console.WriteLine("Pressione Enter para continuar ou digite 'sair' para encerrar:");
            string entrada = Console.ReadLine();

            if (entrada != null && (entrada.Trim().ToLower() == "sair" || entrada.Trim().ToLower() == "quit"))
            {
                break;
            }

            escritura.OcultarPalavrasAleatorias(3);
        }
    }
}