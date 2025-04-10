public class Pista
{
    public string ID { get; set; }
    public enum Estado
    {
        Libre,
        Ocupada
    }
    public Avion AvionActual { get; set; }
    const int DisponibilidadTicks = 3;

    public Pista(string id, Avion avionActual)
    {
        ID = id;
        AvionActual = avionActual;
    }

    public void SolicitarAterrizaje(Avion avion) //asigna un avión para aterrizar en esta pista.
    {

    }

    public void LiberarPista() //libera la pista una vez que el avión ha aterrizado y la ha despejado.
    {

    }
}