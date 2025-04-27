
public class AvionComercial : Avion
{
    private int numPasajeros;
    public int GetNumPasajeros()
    {
        return numPasajeros;
    }
    public void SetNumPasajeros(int numPasajeros)
    {
        this.numPasajeros = numPasajeros;
    }
    public AvionComercial(string iD, Estado estadoAvion, int distancia, int velocidad, double capacidadCombustible, double consumoCombustible, int numPasajeros)
    : base(iD, estadoAvion, distancia, velocidad, capacidadCombustible, consumoCombustible)
    {
        this.numPasajeros = numPasajeros;
    }
}