public class AvionPrivado : Avion{
    private string? Propietario;
    public string GetPropietario(){
        return Propietario;
    }
    public void SetPropietario(string propietario){
        propietario = Propietario;
    }
    public AvionPrivado(string iD, int distancia, int velocidad, double capacidadCombustible, double combustibleActual, string propietario) 
    : base(iD, distancia, velocidad, capacidadCombustible, combustibleActual){
        Propietario = propietario;
    }
}