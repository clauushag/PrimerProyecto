public class AvionComercial : Avion
{
    public int NumeroPasajeros { get; set; }
    public AvionComercial(int numPas, string id, int dis, int vel, double capComb, double consComb, double combAct) : base(id, dis, vel, capComb, consComb, combAct)
    {
        NumeroPasajeros = numPas;
    }
}