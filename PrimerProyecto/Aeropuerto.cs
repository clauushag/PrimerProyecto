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

    public void MostrarEstado()
    //hay que cambiarlo para que muestre las pistas en 2D.
    //muestra el estado actual de todas las pistas y aviones. 
    //Para cada pista, muestra su ID y si está libre u ocupada. 
    //Si está ocupada, muestra el ID de la aeronave y los ticks restantes hasta que quede libre.
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

    public Avion AddAvion()
    {
        Console.WriteLine("Escoja el avion que desea crear.");
        Console.WriteLine("1. Aavion de Carga.");
        Console.WriteLine("2. Aavion Comercial.");
        Console.WriteLine("3. Aavion privado.");

        int input = int.Parse(Console.ReadLine());

        Console.Write("Escriba el Id del avion: ");
        string? id = Console.ReadLine();
        Console.Write("Escriba la velocidad del avion: ");
        int velocidad = int.Parse(Console.ReadLine());
        Console.Write("Escriba la capacidad de combustible del avion: ");
        double capacidadCombustible = double.Parse(Console.ReadLine());
        Console.Write("Escriba el consumo de combustible del avion: ");
        double consumoCombustible = double.Parse(Console.ReadLine());
        Console.WriteLine("Escriba la distancia que recorrerá el avión: ");
        int distancia = int.Parse(Console.ReadLine());

        switch (input)
        {
            case 1:
                Console.Write("Escriba la carga maxima del avion: ");
                double cargaMaxima = double.Parse(Console.ReadLine());
                listaAviones.Add(new AvionCarga(id, Avion.Estado.EnVuelo, distancia, velocidad, capacidadCombustible, consumoCombustible, cargaMaxima));
                return new AvionCarga(id, Avion.Estado.EnVuelo, distancia, velocidad, capacidadCombustible, consumoCombustible, cargaMaxima);

            case 2:
                Console.Write("Escriba el numero de pasajeros del avion: ");
                int numPasajeros = int.Parse(Console.ReadLine());
                listaAviones.Add(new AvionComercial(id, Avion.Estado.EnVuelo, distancia, velocidad, capacidadCombustible, consumoCombustible, numPasajeros));
                return new AvionComercial(id, Avion.Estado.EnVuelo, distancia, velocidad, capacidadCombustible, consumoCombustible, numPasajeros);


            case 3:
                Console.Write("Escriba el nombre del propietario del avion: ");
                string? propietario = Console.ReadLine();
                listaAviones.Add(new AvionPrivado(id, Avion.Estado.EnVuelo, distancia, velocidad, capacidadCombustible, consumoCombustible, propietario));
                return new AvionPrivado(id, Avion.Estado.EnVuelo, distancia, velocidad, capacidadCombustible, consumoCombustible, propietario);

            default:
                Console.WriteLine("No se puede crear el avion debido a que no ha elegido ninguna de las opciones correctas.");
                return null;

        }
    }
}