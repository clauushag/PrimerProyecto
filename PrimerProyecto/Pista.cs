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
    public void SolicitarAterrizaje(Avion avion) //asigna un avión para aterrizar en esta pista. 
    {
        if (estadoActual == Estado.Libre)
        {
            avionActual = avion;
<<<<<<< HEAD:PrimerProyecto/Pista.cs
=======
            estadoActual = Estado.Ocupada; //está ocupada por el avión que entra, no por el que se va.
>>>>>>> 7ad796d1d46d7245be70813339563d53aee4767d:Pista.cs
            Aterrizar();
            Console.WriteLine($"El avion {avion} ha aterrizado en la pista {ID}.");
        }

        else Console.WriteLine($"La pista {ID} está ocupada. El avion {avion} no puede aterrizar.");
    }
    private void LiberarPista() //libera la pista una vez que el avión ha aterrizado y la ha despejado.
    {
        estadoActual = Estado.Libre;
        avionActual = null; //Elimina el avión.
    }
    private void Aterrizar() //Cuando se llama al método aterrizar, tiene que llegar el contador a 0 (pasan los 3 ticks) hasta que se pueda volver a aterrizar.
    {
<<<<<<< HEAD:PrimerProyecto/Pista.cs
        if(estadoActual == Estado.Libre) estadoActual = Estado.Ocupada;
        else Console.WriteLine($"La pista {ID} esta ocupada");
        //Tengo el avión asignado y pasan 3 ticks
        LiberarPista();
=======
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
>>>>>>> 7ad796d1d46d7245be70813339563d53aee4767d:Pista.cs
    }
}