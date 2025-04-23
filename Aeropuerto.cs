using System.ComponentModel;
using System.Data.Common;

public class Aeropuerto
{
    public Pista[,] arrayPistas; //representa las pistas disponibles
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

    public void CargarAvionesDesdeArchivo(string ruta)
    //carga los datos de los aviones desde una ruta de archivo especificada
    {

        using (StreamReader sr = File.OpenText(ruta))
        {
            string linea = "";
            while ((linea = sr.ReadLine()) != null)
            {
                char caracter = ',';
                string[] atributo = linea.Split(caracter);

                //Creo los aviones con los datos que he adquirido desde el archivo y me creo los aviones añadiendolos a la lista.
                switch (atributo[4])
                {
                    case "Comercial":
                        listaAviones.Add(new AvionComercial(atributo[0], DevolverEstado(atributo[1]), int.Parse(atributo[2]), int.Parse(atributo[3]), double.Parse(atributo[5]), double.Parse(atributo[6]), int.Parse(atributo[7])));
                        break;
                    case "Carga":
                        listaAviones.Add(new AvionCarga(atributo[0], DevolverEstado(atributo[1]), int.Parse(atributo[2]), int.Parse(atributo[3]), double.Parse(atributo[5]), double.Parse(atributo[6]), double.Parse(atributo[7])));
                        break;
                    case "Privado":
                        listaAviones.Add(new AvionPrivado(atributo[0], DevolverEstado(atributo[1]), int.Parse(atributo[2]), int.Parse(atributo[3]), double.Parse(atributo[5]), double.Parse(atributo[6]), atributo[7]));
                        break;
                }
            }
        }

    }

    private Avion.Estado DevolverEstado(string estado)
    {
        switch (estado)
        {
            case "EnVuelo": return Avion.Estado.EnVuelo;
            case "EnEspera": return Avion.Estado.EnEspera;
            case "Aterrizando": return Avion.Estado.Aterrizando;
            case "EnTierra": return Avion.Estado.EnTierra;
            default:
                return Avion.Estado.EnTierra; //Por defecto que el avión esté en tierra, así está más seguro.
        }
    }
}