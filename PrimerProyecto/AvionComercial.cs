
public class AvionComercial : Avion
{
    private int numPasajeros;
    public int GetPasajerosMaximos()
    {
        return numPasajeros;
    }
    public void SetPasajerosMaximos(int pasajerosMaximos)
    {
        this.numPasajeros = pasajerosMaximos;
    }
    public AvionComercial(int numpas, string id, int dis, int vel, double capComb, double consumoComb, double combAct, int numPas)
    : base(id, dis, vel, capComb, consumoComb, combAct)
    {
        numPasajeros = numPas;
    }
}