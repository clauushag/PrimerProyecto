public class AvionCarga : Avion{
    private double cargaMaxima;
    public double GetCargaMaxima(){
        return cargaMaxima;
    }
    public void SetCargaMaxima(double cargaMaxima){
        this.cargaMaxima = cargaMaxima;
    }
    public AvionCarga(string iD, int distancia, int velocidad, double capacidadCombustible, double combustibleActual, double cargaMaxima, double consumoCombustible) 
    : base(iD, distancia, velocidad, capacidadCombustible, combustibleActual, consumoCombustible){
        this.cargaMaxima = cargaMaxima;
    }
}