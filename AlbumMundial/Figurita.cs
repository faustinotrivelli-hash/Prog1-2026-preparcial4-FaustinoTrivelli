namespace FiguritasHub;

using System;

public abstract class Figurita
{
    public int Numero { get; set; }
    public string Nombre { get; set; }
    public string Pais { get; set; }
    public Figurita(int numero, string nombre, string pais)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre no puede estar vacío");
        }

        if (numero <= 0)
        {
            throw new ArgumentException("El número de la figurita no puede ser menor o igual a cero");
        }

        Numero = numero;
        Nombre = nombre;
        Pais = pais;
    }

    public abstract string ConsultarCategoria();

}
