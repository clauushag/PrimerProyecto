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
    private int contador;
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

    public int GetContador()
    {
        return contador;
    }

    public Pista(string id)
    {
        ID = id; //No inicializamos el avión, ya que cuando me creo una pista, no me creo un avión. Solo nos interesa el ID.
        contador = DISPONIBILIDADTICKS;
    }
    //SOLICITARATERRIZAJE: comprueba que la pista esté libre, si lo está asigna el avión y lo aterriza. Si no está libre, WARNING.
    public bool SolicitarAterrizaje(Avion avion) //asigna un avión para aterrizar en esta pista. 
    {
        if (estadoActual == Estado.Libre)
        {
            avionActual = avion;
            estadoActual = Estado.Ocupada; //está ocupada por el avión que entra, no por el que se va.
            Aterrizar();
            Console.WriteLine($"El avion {avion} ha aterrizado en la pista {ID}.");
            contador = 3;
            avionActual.SetEstadoAvion(Avion.Estado.Aterrizando);
            return true;
        }

        else
        {
            Console.WriteLine($"La pista {ID} está ocupada. El avion {avion} no puede aterrizar.");
            return false;
        }

    }
    private void LiberarPista() //libera la pista una vez que el avión ha aterrizado y la ha despejado.
    {
        estadoActual = Estado.Libre;
        avionActual.SetEstadoAvion(Avion.Estado.EnTierra); //según el funcionamiento del programa, para poder eliminar
                                                           // el avión cuando queramos liberar la piesta, este debe estar en tierra.
        avionActual = null; //Elimina el avión.
        contador = DISPONIBILIDADTICKS;//reinicio el contador cuando queda libre
    }
    private void Aterrizar() //Cuando se llama al método aterrizar, tiene que llegar el contador a 0 (pasan los 3 ticks) hasta que se pueda volver a aterrizar.
    {
        if (contador == 0)
        {
            LiberarPista();
        }
    }

    public void SimularTick() //Aterrizas, simulas 3 ticks, liberas la pista y vuelve a 3.
    {
        if (Pista.Estado.Ocupada == estadoActual)
        {
            contador--;
            Aterrizar();
        }
    }
}