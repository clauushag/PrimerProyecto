using System.ComponentModel;
using System.Data.Common;

public class Aeropuerto
{
    public Pista[,] arrayPistas; //representa las pistas disponibles
    public List<Avion> listaAviones = new List<Avion>();

    public Aeropuerto(int filas, int columnas)
    {
        arrayPistas = new Pista[filas, columnas]; //inicializo el array de pistas con el número de filas y columnas que me pasan por parámetro.
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                arrayPistas = new Pista[filas, columnas]; //se inicializa el array de pistas con las filas y las columnas que pasan al constructor.
            }
        }
    }

    public void AvanzarTick()
    {
        foreach (Avion a in listaAviones) //avanzo simulación para aviones con el método de encapsulación.
        {
            a.SimularAvion();
        }

        for (int i = 0; i < arrayPistas.GetLength(0); i++) //recorro las filas.
        {
            for (int j = 0; j < arrayPistas.GetLength(1); j++) //recorro las columnas.
            {
                arrayPistas[i, j].SimularTick();
            }
        }
    }
    public void MostrarEstado()
    {
        Console.WriteLine("Estado actual de todas las pistas y aviones:");
        for (int i = 0; i < arrayPistas.GetLength(0); i++) //recorro las filas.
        {
            for (int j = 0; j < arrayPistas.GetLength(1); j++) //recorro las columnas.
            {
                Console.WriteLine($" La pista con id: {arrayPistas[i, j].GetId()} está {arrayPistas[i, j].GetEstadoActual()}"); // Para cada pista, muestra su ID y si está libre u ocupada.
                if (arrayPistas[i, j].GetEstadoActual() == Pista.Estado.Ocupada)
                {
                    Console.WriteLine($"El id del avión es: {arrayPistas[i, j].GetAvion().GetId()}");
                    Console.WriteLine($"Quedan {arrayPistas[i, j].GetContador()} ticks restantes."); //Si está ocupada, muestra el ID de la aeronave y los ticks restantes hasta que quede libre.
                }
            }
        }
    }

    public void CargarAvionesDesdeArchivo(string ruta) //carga los datos de los aviones desde una ruta de archivo especificada
    {
        using (StreamReader sr = File.OpenText(ruta))
        {
            string linea = "";
            while ((linea = sr.ReadLine()) != null)
            {
                char caracter = ','; //lo separo por comas porque en csv el carácter separador es la coma.
                string[] atributo = linea.Split(caracter);

                //Creo los aviones con los datos que he adquirido desde el archivo añadiendolos a la lista.
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

    public void AddAvion()
    {
        Console.WriteLine("Introduzca el ID del avión: ");
        string id = Console.ReadLine();

        Console.WriteLine("Introduzca la distancia a la que se encuentra el avión: ");
        int distancia = Console.ReadLine();

        Console.WriteLine("Introduzca la velocidad del avión: ");
        int velocidad = Console.ReadLine();

        Console.WriteLine("Introduzca la capacidad de combustible del avión: ");
        double capacidadCombustible = Console.ReadLine();

        Console.WriteLine("Introduzca el consumo de combustible del avión: ");
        double consumoCombustible = Console.ReadLine();

        Console.WriteLine("Introduzca el combustible actual del avión: ");
        double combustibleActual = Console.ReadLine();

        Console.WriteLine("Introduzca el número de avión que desee: ");
        Console.WriteLine("1. Avión Comercial.");
        Console.WriteLine("2. Avión de Carga.");
        Console.WriteLine("3. Avión Privado.");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case 1:
                Console.WriteLine("Introduzca el número de pasajeros: ");
                int numPasajeros = Console.ReadLine();
                listaAviones.Add(new AvionComercial(id, distancia, velocidad, capacidadCombustible, consumoCombustible, combustibleActual, numPasajeros));
                break;
            case 2:
                Console.WriteLine("Introduzca la carga máxima del avión: ");
                double cargaMaxima = Console.ReadLine();
                listaAviones.Add(new AvionCarga(id, distancia, velocidad, capacidadCombustible, consumoCombustible, combustibleActual, numPasajeros));
                break;
            case 3:
                Console.WriteLine("Introduzca el nombre del propietario del avión: ");
                string propietario = Console.ReadLine();
                listaAviones.Add(new AvionPrivado(id, distancia, velocidad, capacidadCombustible, consumoCombustible, combustibleActual, numPasajeros));
                break;
        }

    }
}