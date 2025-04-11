public abstract class Avion //Hola.
{
    private string? ID;
    private enum Estado
    {
        EnVuelo,
        EnEspera,
        Aterrizando,
        EnTierra
    }
    private int distancia;
    private int velocidad;
    private double capacidadCombustible;
    private double consumoCombustible;
    private double combustibleActual;
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
        return capacidadCombustible;
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

    public Avion(string iD, int distancia, int velocidad, double capacidadCombustible, double combustibleActual)
    {
        ID = iD;
        this.distancia = distancia;
        this.velocidad = velocidad;
        this.capacidadCombustible = capacidadCombustible;
        this.combustibleActual = combustibleActual;
    }
}