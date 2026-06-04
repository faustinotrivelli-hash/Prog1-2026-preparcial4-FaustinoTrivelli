using FiguritasHub;
namespace AlbumMundialTest;

[TestFixture]
public class GestorDeCanjeTests
{
    [Test]
    public void AgregarFiguritaConCantidad_RegistroTresCopias_YApareceEnRepetidas()
    {
        Album album = new Album();

        Figurita figurita = new FiguritaComun(10, "Messi", "Argentina", 3);

        album.AgregarFigurita(figurita, 3);

        Assert.That(album.TieneRepetida(10), Is.True);
        Assert.That(album.ObtenerRepetidas().Count, Is.EqualTo(1));
    }
    [Test]
    public void TieneRepetida_DevuelveTrueOSegunCantidad()
    {
        Album album = new Album();

        Figurita figurita = new FiguritaComun(10, "Messi", "Argentina", 3);

        album.AgregarFigurita(figurita);

        Assert.That(album.TieneRepetida(10), Is.False);

        album.AgregarFigurita(figurita);

        Assert.That(album.TieneRepetida(10), Is.True);
    }
    [Test]
    public void Canjear_Valido_OrigenPierdeCopia_DestinoRecibe()
    {
        Album origen = new Album();
        Album destino = new Album();

        Figurita figurita = new FiguritaComun(10, "Messi", "Argentina", 3);

        origen.AgregarFigurita(figurita, 2);

        GestorDeCanjeService gestor = new GestorDeCanjeService();

        gestor.Canjear(origen, destino, figurita);

        Assert.That(origen.TieneRepetida(10), Is.False);
        Assert.That(destino.PoseeFigurita(10), Is.True);
    }
    [Test]
    public void Canjear_LanzaExcepcion_SiDestinoYaPoseeFigurita()
    {
        Album origen = new Album();
        Album destino = new Album();

        Figurita figurita = new FiguritaComun(10, "Messi", "Argentina", 3);

        origen.AgregarFigurita(figurita, 2);
        destino.AgregarFigurita(figurita);

        GestorDeCanjeService gestor = new GestorDeCanjeService();

        Assert.That(
            () => gestor.Canjear(origen, destino, figurita),
            Throws.TypeOf<ArgumentException>());
    }
    [Test]
    public void Canjear_LanzaExcepcion_SiOrigenNoTieneRepetida()
    {
        Album origen = new Album();
        Album destino = new Album();

        Figurita figurita = new FiguritaComun(10, "Messi", "Argentina", 3);

        origen.AgregarFigurita(figurita);

        GestorDeCanjeService gestor = new GestorDeCanjeService();

        Assert.That(() => gestor.Canjear(origen, destino, figurita), Throws.TypeOf<ArgumentException>());


    }
}
