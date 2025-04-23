public class AvionCarga : Avion
{
    private double cargaMaxima;
    public double GetCargaMaxima()
    {
        return cargaMaxima;
    }
    public void SetCargaMaxima(double cargaMaxima)
    {
        this.cargaMaxima = cargaMaxima;
    }
    public AvionCarga(string iD, Estado estadoAvion, int distancia, int velocidad, double capacidadCombustible, double consumoCombustible, double cargaMaxima)
    : base(iD, estadoAvion, distancia, velocidad, capacidadCombustible, consumoCombustible)
    {
        this.cargaMaxima = cargaMaxima;
    }
}