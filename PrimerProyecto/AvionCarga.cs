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
    public AvionCarga(string iD, int distancia, int velocidad, double capacidadCombustible, double consumoComb, double combAct, double cargaMaxima)
    : base(iD, distancia, velocidad, capacidadCombustible, consumoComb, combAct)
    {
        this.cargaMaxima = cargaMaxima;
    }
}