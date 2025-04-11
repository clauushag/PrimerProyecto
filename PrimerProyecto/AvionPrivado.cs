public class AvionPrivado : Avion
{
    private string? propietario;
    public string GetPropietario()
    {
        return propietario;
    }
    public void SetPropietario(string propietario)
    {
        this.propietario = propietario;
    }
    public AvionPrivado(string iD, int distancia, int velocidad, double capacidadCombustible, double combustibleActual, string propietario)
    : base(iD, distancia, velocidad, capacidadCombustible, combustibleActual)
    {
        this.propietario = propietario;
    }
}