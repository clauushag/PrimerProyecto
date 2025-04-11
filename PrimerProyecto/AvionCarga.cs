public class AvionCarga : Avion{
    private double CargaMaxima;
    public double GetCargaMaxima(){
        return CargaMaxima;
    }
    public void SetCargaMaxima(double cargaMaxima){
        cargaMaxima = CargaMaxima;
    }
    public AvionCarga(string iD, int distancia, int velocidad, double capacidadCombustible, double combustibleActual, double cargaMaxima, double cargaActual) 
    : base(iD, distancia, velocidad, capacidadCombustible, combustibleActual){
        CargaMaxima = cargaMaxima;
    }
}