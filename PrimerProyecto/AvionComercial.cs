
public class AvionComercial : Avion
{
    private int numPasajeros;
    public int GetPasajerosMaximos(){
        return numPasajeros;
    }
    public void SetPasajerosMaximos(int numPasajeros){
        this.numPasajeros = numPasajeros;
    }
    public AvionComercial(int numPasajeros, string iD, int distancia, int velocidad, double capacidadCombustible, double consumoCombustible, double combustibleActual)
    : base(iD, distancia, velocidad, capacidadCombustible, combustibleActual, consumoCombustible){
        this.numPasajeros = numPasajeros;
    }
}