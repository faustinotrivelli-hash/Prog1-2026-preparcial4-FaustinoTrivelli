namespace FiguritasHub;

using System.Linq;

public class GestorDeCanjeService
{
    protected List<Album> Albums = new List<Album>();

    public void RegistrarAlbum(Album album)
    {
        Albums.Add(album);
    }

    public void Canjear(Album origen, Album destino, int numeroDeFigurita)
    {
        Figurita figurita =
            origen.BuscarPorNumero(numeroDeFigurita);

        if (figurita == null)
        {
            throw new ArgumentException("La figurita no existe en el álbum origen");
        }

        Canjear(origen, destino, figurita);
    }

    public void Canjear(Album origen, Album destino, Figurita figurita)
    {
        if (!origen.TieneRepetida(figurita))
        {
            throw new ArgumentException("El álbum origen no tiene la figurita como repetida");
        }

        if (destino.PoseeFigurita(figurita.Numero))
        {
            throw new ArgumentException("El álbum destino ya posee esa figurita");
        }

        origen.RemoverUnaCopia(figurita);
        destino.AgregarFigurita(figurita);
    }

    public Album? ObtenerAlbumConMasRepetidas()
    {
        if (!Albums.Any())
            return null;

        return Albums
            .OrderByDescending(a => a.CantidadRepetidasTotales())
            .First();
    }
}
