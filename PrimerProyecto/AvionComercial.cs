
public class AvionComercial : Avion
{
    private int NumPasajeros;
    public int GetPasajerosMaximos()
    {
        return NumPasajeros;
    }
    public void SetPasajerosMaximos(int pasajerosMaximos)
    {
        pasajerosMaximos = NumPasajeros;
    }
    public AvionComercial(int numpas, string id, int dis, int vel, double capComb, double combAct, int numPas)
    : base(id, dis, vel, capComb, combAct)
    {
        NumPasajeros = numPas;
    }
}