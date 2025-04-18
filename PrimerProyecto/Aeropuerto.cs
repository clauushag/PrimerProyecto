using System.Data.Common;

public class Aeropuerto
{
    public Pista[] arrayPistas; //representa las pistas disponibles
    public List<Avion> listaAviones = new List<Avion>();

    public Aeropuerto(Pista[] pistas)
    {
        arrayPistas = pistas;
    }

    public void MostrarEstado()
    /*muestra el estado actual de todas las pistas y aviones. 
    Para cada pista, muestra su ID y si está libre u ocupada. 
    Si está ocupada, muestra el ID de la aeronave y los ticks restantes hasta que quede libre.*/
    {
        Console.WriteLine("Estado actual de todas las pistas y aviones:");
        foreach (Pista p in arrayPistas)
        {
            Console.WriteLine($" La pista con id: {p.GetId()} está {p.GetEstadoActual()}");
            if (p.GetEstadoActual() == Pista.Estado.Ocupada)
            {
                Console.WriteLine($"El id del avión es: {p.GetAvion().GetId()}");
            }
        }
    }
}