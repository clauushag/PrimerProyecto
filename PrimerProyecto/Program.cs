public class Program
{

    public static void Main(string[] args)
    {
        while (true)
        {


            Aeropuerto aeropuerto = new Aeropuerto(3, 3);

            Console.WriteLine("=================================================");
            Console.WriteLine("||                   AIR UFV                    ||");
            Console.WriteLine("=================================================");
            Console.WriteLine("||                                              ||");
            Console.WriteLine("||      Choose an option                        ||");
            Console.WriteLine("||      1. Load flights from file               ||");
            Console.WriteLine("||      2. Load flight manually                 ||");
            Console.WriteLine("||      3. Start a simulation (Manual)          ||");
            Console.WriteLine("||      4. Start a simulation (Automatic)       ||");
            Console.WriteLine("||      5. Exit                                 ||");
            Console.WriteLine("||                                              ||");
            Console.WriteLine("=================================================");
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
                    while (aeropuerto.AvionesVolando())
                    {
                        aeropuerto.AvanzarTick();
                        aeropuerto.MostrarEstado();
                        Console.WriteLine("Enter para continuar");
                        Console.ReadKey();
                    }
                    break;

                case 4:
                    while (aeropuerto.AvionesVolando())
                    {
                        aeropuerto.AvanzarTick();
                        aeropuerto.MostrarEstado();
                        System.Threading.Thread.Sleep(2500); //Pausa la ejecución por 2500 milisegundos.
                    }
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