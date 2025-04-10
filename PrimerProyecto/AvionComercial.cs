public class AcionComercial : Avion{
    private int NumPasajeros;
    public int GetPasajerosMaximos(){
        return NumPasajeros;
    }
    public void SetPasajerosMaximos(int pasajerosMaximos){
        pasajerosMaximos = NumPasajeros;
    }
    public AcionComercial(string iD, int distancia, int velocidad, double capacidadCombustible, double combustibleActual, int pasajerosMaximos) 
    : base(iD, distancia, velocidad, capacidadCombustible, combustibleActual){
        NumPasajeros = pasajerosMaximos;
    }
}