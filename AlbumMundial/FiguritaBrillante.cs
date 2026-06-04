namespace FiguritasHub;

using System;

public class FiguritaBrillante : Figurita
{
    public bool EsEdicionLimitada { get; set; }
    public FiguritaBrillante(int numero, string nombre, string pais, bool esEdicionLimitada) : base(numero, nombre, pais)
    {
        EsEdicionLimitada = esEdicionLimitada;
    }

    public override string ConsultarCategoria()
    {
        if (EsEdicionLimitada)
        {
            return $"Brillante (Edición Limitada)";
        }
        else
        {
            return "Brillante";
        }
    }
}