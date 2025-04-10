public class Avion
{
    public string ID { get; set; }
    public enum Estado
    {
        EnVuelo,
        EnEspera,
        Aterrizando,
        EnTierra
    }
    public int Distancia { get; set; } //en kilómetros.
    public int Velocidad { get; set; } //en km/h.
    public double CapacidadCombustible { get; set; } //en litros.
    public double ConsumoCombustible { get; set; } //en litros/km.
    public double CombustibleActual { get; set; } //en litros.

    public Avion(string id, int dist, int vel, double capComb, double consComb, double combAct)
    {
        ID = id;
        Distancia = dist;
        Velocidad = vel;
        CapacidadCombustible = capComb;
        ConsumoCombustible = consComb;
        CombustibleActual = combAct;
    }
}