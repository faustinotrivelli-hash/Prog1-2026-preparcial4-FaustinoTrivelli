namespace FiguritasHub;
using System.Linq;
using System;
using System.Collections.Generic;

public class Album
{
    public string ?Nombre {get; set;}
    protected List<Figurita> Figuritas = new List<Figurita>();

    public void AgregarFigurita(Figurita figurita)
    {
        Figuritas.Add(figurita);
    }

    public void AgregarFigurita(Figurita figurita, int cantidad)
    {
        if (cantidad  <= 0)
        {
            throw new ArgumentException("La cantidad no puede ser menor o igual a cero");
        }

        for (int i = 0; i < cantidad; i++)
        {
            Figuritas.Add(figurita);
        }
    }

    public bool TieneRepetida(Figurita figurita)
    {
        return TieneRepetida(figurita.Numero);
    }

    public bool TieneRepetida(int numero)
    {
        return Figuritas.Count(f => f.Numero == numero) > 1;
    }

    public List<Figurita> ObtenerRepetidas()
    {
        return Figuritas
            .GroupBy(f => f.Numero)
            .Where(g => g.Count() > 1)
            .Select(g => g.First())
            .ToList();
    }

    public void RemoverUnaCopia(Figurita figurita)
    {
        // Remove one instance that matches the provided figurita (by reference or by number)
        var item = Figuritas.FirstOrDefault(f => Object.ReferenceEquals(f, figurita) || f.Numero == figurita.Numero);
        if (item != null)
            Figuritas.Remove(item);
    }

    public int CantidadRepetidasTotales()
    {
        return Figuritas
            .GroupBy(f => f.Numero)
            .Sum(g => Math.Max(0, g.Count() - 1));
    }

    public Figurita? BuscarPorNumero(int numero)
    {
        return Figuritas.FirstOrDefault(f => f.Numero == numero);
    }

    public bool PoseeFigurita(int numero)
    {
        return Figuritas.Any(f => f.Numero == numero);
    }

    public int CantidadDeFigurita(int numero)
    {
        return Figuritas.Count(f => f.Numero == numero);
    }
}