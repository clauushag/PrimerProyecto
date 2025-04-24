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
    private Estado estadoAvion;
    private int distancia; //en kilómetros
    private int velocidad; //en km/h
    private double capacidadCombustible; //en litros
    private double consumoCombustible; //en litros/km
    private double combustibleActual; //en litros

    public Estado GetEstadoAvion()
    {
        return estadoAvion;
    }

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
    public Avion(string iD, Estado estadoAvion, int distancia, int velocidad, double capacidadCombustible, double consumoCombustible)
    {
        ID = iD;
        this.estadoAvion = estadoAvion;
        this.distancia = distancia;
        this.velocidad = velocidad;
        this.capacidadCombustible = capacidadCombustible;
        this.consumoCombustible = consumoCombustible;
        combustibleActual = capacidadCombustible; //Siempre está al máximo, y por tanto lo inicializo a la capacidadCombustible.
        this.consumoCombustible = consumoCombustible;
        estadoAvion = Estado.EnVuelo;
    }

    public void SimularAvion()
    {
        int distanciaRecorrida;
        if (distancia != 0)
        {
            distanciaRecorrida = velocidad * 60 / 4; //distancia recorrida en un cuarto de hora(1 tick).
            if (distancia < distanciaRecorrida)
            {
                distanciaRecorrida = distancia; //para evitar pasarnos de largo, comprobamos cuando la distancia recorrida va a ser mayor que la distancia.
                                                //cuando eso sucede la distancia recorrida es la distancia.
            }
            distancia -= distanciaRecorrida; //actualizamos el valor distancia en función de lo que ya hemos recorrdido.
        }

        if (combustibleActual != 0)
        {
            combustibleActual -= consumoCombustible * distanciaRecorrida; //reduzco el combustible a medida que avanza el avión.
        }
        if (combustibleActual == 0) //Complicado el asunto si se queda sin combustible el avión. 
        {
            throw new Exception("Complicado.");
        }
    }
}