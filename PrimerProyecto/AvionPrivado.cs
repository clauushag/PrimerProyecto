public class AvionPrivado : Avion
{
    public string Propietario { get; set; }
    public AvionPrivado(string prop, string id, int dis, int vel, double capComb, double consComb, double combAct) : base(id, dis, vel, capComb, consComb, combAct)
    {
        Propietario = prop;
    }
}