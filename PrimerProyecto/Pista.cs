using System.Threading.Tasks;

public class Pista
{
    private string ID;
    public enum Estado
    {
        Libre,
        Ocupada
    }
    private Estado estadoActual = Estado.Libre;
    public Avion avionActual;//avión asignado actualmente a la pista
    private const int DISPONIBILIDADTICKS = 3;
    public string GetId()
    {
        return ID;
    }

    public Avion GetAvion()
    {
        return avionActual;
    }

    public Estado GetEstadoActual()
    {
        return estadoActual;
    }

    public Pista(string id)
    {
        ID = id; //No inicializamos el avión, ya que cuando me creo una pista, no me creo un avión. Solo nos interesa el ID.
    }
    //SOLICITARATERRIZAJE: comprueba que la pista esté libre, si lo está asigna el avión y lo aterriza. Si no está libre, WARNING.
    public void SolicitarAterrizaje(Avion avion) //asigna un avión para aterrizar en esta pista. 
    {
        if (estadoActual == Estado.Libre)
        {
            avionActual = avion;
            Aterrizar();
            Console.WriteLine($"El avion {avion} ha aterrizado en la pista {ID}.");
        }

        else Console.WriteLine($"La pista {ID} está ocupada. El avion {avion} no puede aterrizar.");
    }
    private void LiberarPista() //libera la pista una vez que el avión ha aterrizado y la ha despejado.
    {
        estadoActual = Estado.Libre;
    }
    private void Aterrizar() //DUDA
    {
        if(estadoActual == Estado.Libre) estadoActual = Estado.Ocupada;
        else Console.WriteLine($"La pista {ID} esta ocupada");
        //Tengo el avión asignado y pasan 3 ticks
        LiberarPista();
    }
}