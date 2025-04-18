public abstract class Avion
{
    private string? ID;
    public enum Estado
    {
        EnVuelo,
        EnEspera,
        Aterrizando,
        EnTierra
    }
    private int distancia; //en kilómetros
    private int velocidad; //en km/h
    private double capacidadCombustible; //en litros
    private double consumoCombustible; //en litros/km
    private double combustibleActual; //en litros
    public string GetId()
    {
        return ID;
    }
    public void SetId(string iD)
    {
        ID = iD;
    }

    public int GetDistancia()
    {
        return distancia;
    }
    public void SetDistancia(int distancia)
    {
        this.distancia = distancia;
    }

    public int GetVelocidad()
    {
        return velocidad;
    }
    public void SetVelocidad(int velocidad)
    {
        this.velocidad = velocidad;
    }

    public double GetCapacidadCombustible()
    {
        return capacidadCombustible;
    }
    public void SetCapacidadCombustible(double capacidadCombustible)
    {
        this.capacidadCombustible = capacidadCombustible;
    }
    public double GetConsumoCombustible()
    {
        return consumoCombustible;
    }
    public void SetConsumoCombustible(double consumoCombustible)
    {
        this.consumoCombustible = consumoCombustible;
    }
    public double GetCombustibleActual()
    {
        return combustibleActual;
    }
    public void SetCombustibleActual(double combustibleActual)
    {
        this.combustibleActual = combustibleActual;
    }

    public Avion(string iD, int distancia, int velocidad, double capacidadCombustible, double consumoCombustible, double combustibleActual)
    {
        ID = iD;
        this.distancia = distancia;
        this.velocidad = velocidad;
        this.capacidadCombustible = capacidadCombustible;
        this.consumoCombustible = consumoCombustible;
        this.combustibleActual = combustibleActual;
    }
}