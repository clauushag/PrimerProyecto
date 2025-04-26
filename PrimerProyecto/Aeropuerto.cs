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
        try
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
        catch (DirectoryNotFoundException e)
        {//el directorio no existe
            Console.WriteLine($"El Directorio no Existe {ruta}");
        }
        catch (FileNotFoundException e)
        {//archivo no encontrado
            Console.WriteLine($"No se pudo encontrar el archivo {ruta}");
        }
        catch (Exception e)
        {//excepciones no contempladas
            Console.WriteLine($"Error no contemplado {e.Message}");
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
        Console.WriteLine("Escoja el avion que desea crear.");
        Console.WriteLine("1. Avion de Carga.");
        Console.WriteLine("2. Avion Comercial.");
        Console.WriteLine("3. Avion privado.");

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
        try
        {
            switch (input)
            {
                case 1:
                    Console.Write("Escriba la carga maxima del avion: ");
                    double cargaMaxima = double.Parse(Console.ReadLine());
                    listaAviones.Add(new AvionCarga(id, Avion.Estado.EnVuelo, distancia, velocidad, capacidadCombustible, consumoCombustible, cargaMaxima));
                    break;
                case 2:
                    Console.Write("Escriba el numero de pasajeros del avion: ");
                    int numPasajeros = int.Parse(Console.ReadLine());
                    listaAviones.Add(new AvionComercial(id, Avion.Estado.EnVuelo, distancia, velocidad, capacidadCombustible, consumoCombustible, numPasajeros));
                    break;

                case 3:
                    Console.Write("Escriba el nombre del propietario del avion: ");
                    string? propietario = Console.ReadLine();
                    listaAviones.Add(new AvionPrivado(id, Avion.Estado.EnVuelo, distancia, velocidad, capacidadCombustible, consumoCombustible, propietario));
                    break;
                default:
                    throw new ArgumentException($"No se puede crear un avión distinto a Comercial, Privado o de Carga");
            }
        }
        catch (ArgumentException e) //gestiono la excepcion que he lanzado en el default.
        {
            Console.WriteLine($"{e.Message}");
        }
        catch (FormatException e) //gestiono las excepciones que puedan ocurrir en las conversiones de string a int y double
        {
            Console.WriteLine($"No introduzcas texto cuando se pidan cantidades{e.Message}");
        }
        catch (Exception e)
        {//gestion de exepciones no contempladas
            Console.WriteLine($"Error no contemplado: {e.Message}");
        }
    }
}