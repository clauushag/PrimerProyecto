using System.Runtime.CompilerServices;

public abstract class Avion{
    private string? ID;
    public string GetId(){
        return ID;
    }
    public void SetId(string iD){
        iD = ID;
    }
    private int Distancia;
    public int GetDistancia(){
        return Distancia;
    }
    public void SetDistancia(int distancia){
        distancia = Distancia;
    }
    private int Velocidad;
    public int GetVelocidad(){
        return Velocidad;
    }
    public void SetVelocidad(int velocidad){
        velocidad = Velocidad;
    }
    private double CapacidadCombustible;
    public double GetCapacidadCombustible(){
        return CapacidadCombustible;
    }
    public void SetCapacidadCombustible(double capacidadCombustible){
        capacidadCombustible = CapacidadCombustible;
    }
    private double CombustibleActual;
    public double GetCombustibleActual(){
        return CombustibleActual;
    }
    public void SetCombustibleActual(double combustibleActual){
        combustibleActual = CombustibleActual;
    }
    private enum Estado{
        EnVuelo,
        EnEspera,
        Aterrizando,
        EnTierra
    }

    public Avion(string iD, int distancia, int velocidad, double capacidadCombustible, double combustibleActual){
        ID = iD;
        Distancia = distancia;
        Velocidad = velocidad;
        CapacidadCombustible = capacidadCombustible;
        CombustibleActual = combustibleActual;
    }


}