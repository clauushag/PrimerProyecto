using System.Threading.Tasks;

public class Pista
{
    public string iD;
    public enum Estado{
        Libre,
        Ocupada
    }
    public Avion avionActual;
    public Estado estadoActual = Estado.Libre;

    public string GetId(){
        return iD;
    }
    public void SetId(string iD){
        this.iD = iD;
    }
    public Avion GetAvionActual(){
        return avionActual;
    }
    public void SetAvionActual(Avion avionActual){
        this.avionActual = avionActual;
    }
    const int DisponibilidadTicks = 3;

    public Pista(string id, Avion avionActual){
        iD = id;
        this.avionActual = avionActual;
    }

  public void SolicitarAterrizaje(Avion avion) //asigna un avión para aterrizar en esta pista. 
  {
        if (estadoActual == Estado.Libre){
            avionActual = avion;
            estadoActual = Estado.Ocupada;
            Console.WriteLine($"El avion {avion} ha aterrizado en la pista {iD}.");
        }

        else Console.WriteLine($"La pista {iD} está ocupada. El avion {avion} no puede aterrizar.");
    }

    public async Task LiberarPista() //libera la pista una vez que el avión ha aterrizado y la ha despejado.
    {
        if(estadoActual == Estado.Ocupada){
            await Task.Delay(DisponibilidadTicks * 1000); // el *1000 porque la funcion esta en milisegunds.

            avionActual = null;
            estadoActual = Estado.Libre;
            Console.WriteLine($"Se ha liberado la pista {iD}.");
        }
        
        else Console.WriteLine($"La pista {iD} ya está libre.");
    }
}