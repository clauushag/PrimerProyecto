public class AvionPrivado : Avion
{
    private string propietario;
    public string GetPropietario()
    {
        return propietario;
    }
    public void SetPropietario(string propietario)
    {
        this.propietario = propietario;
    }
    public AvionPrivado(string iD, Estado estadoAvion, int distancia, int velocidad, double capacidadCombustible, double consumoCombustible, string propietario)
    : base(iD, estadoAvion, distancia, velocidad, capacidadCombustible, consumoCombustible)
    {
        this.propietario = propietario;
    }
}