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
    public AvionPrivado(string propietario, string iD, int distancia, int velocidad, double capacidadCombustible, double consumoCombustible, double combustibleActual)  
    : base(iD, distancia, velocidad, capacidadCombustible, combustibleActual, consumoCombustible)
    {
        this.propietario = propietario;
    }
}