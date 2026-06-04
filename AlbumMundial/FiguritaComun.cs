namespace FiguritasHub;

using System;

public class FiguritaComun : Figurita
{
    public int Rareza { get; set; }
    public FiguritaComun(int numero, string nombre, string pais, int rareza) : base(numero, nombre, pais)
    {
        if (rareza < 1 || rareza > 5)
        {
            throw new ArgumentException("La rareza tiene que ser entre 1 y 5");
        }

        Rareza = rareza;
    }

    public override string ConsultarCategoria()
    {
        return $"Común (Rareza: {Rareza})";
    }
}