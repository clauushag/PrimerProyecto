public class Program
{

    public static void Main(string[] args)
    {
        while (true)
        {


            Aeropuerto aeropuerto = new Aeropuerto(3, 3);

            Console.WriteLine("Choose an option:");
            Console.WriteLine();
            Console.WriteLine("_________________________________________________________________");
            Console.WriteLine("1. Load flights from file");
            Console.WriteLine("2. Load flight manually");
            Console.WriteLine("3. start a simulation (Manual)");
            Console.WriteLine("4. start a simulation (Automatic)");
            Console.WriteLine("5. Exit");
            Console.WriteLine("_________________________________________________________________");
            Console.WriteLine();
            Console.Write("Choose your option:");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Console.WriteLine("Escriba el nombre del archivo.");
                    string? archivo = Console.ReadLine();
                    if (File.Exists(archivo))
                    {
                        aeropuerto.CargarAvionesDesdeArchivo(archivo);
                        Console.WriteLine("Aviones cargados correctamente.");
                    }
                    break;

                case 2:
                    aeropuerto.AddAvion();
                    break;

                case 3:

                    break;

                case 4:
                    Console.WriteLine("Lo sentimos, estamos trabajando en ello :( (es broma, no lo tenemos)");
                    Console.WriteLine();
                    break;

                case 5:
                    Console.WriteLine("Presione una tecla para finalizar.");
                    Console.ReadKey();
                    Console.WriteLine("Saliendo...");
                    return;
                default:
                    break;
            }
        }
    }
}