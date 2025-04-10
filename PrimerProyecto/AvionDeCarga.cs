public class AvionDeCarga : Avion
{
    public double CargaMaxima { get; set; }
    public AvionDeCarga(double cargMax, string id, int dis, int vel, double capComb, double consComb, double combAct) : base(id, dis, vel, capComb, consComb, combAct)
    {
        CargaMaxima = cargMax;
    }
}