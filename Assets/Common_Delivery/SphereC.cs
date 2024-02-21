using System;

[System.Serializable]
public struct SphereC
{
    #region FIELDS
    public Vector3C position;
    public float radius;
    #endregion

    #region PROPIERTIES
    public bool unitary
    {
        get { return radius == 1f; }
    }
    #endregion

    #region CONSTRUCTORS
    public SphereC(Vector3C position, float radius)
    {
        this.position = position;
        this.radius = radius;
    }
    #endregion

    #region OPERATORS
    #endregion

    #region METHODS
    public bool IsInside(Vector3C point) //Comprobamos si collisiona con la esfera comparando la distancia del centro a un punto con el radio de la esfera
    {

        float distanceSquared = Vector3C.DistanceSquared(point, position);
        return distanceSquared <= radius * radius; //Usamos radio al cuadrado para ahorrarnos una raiz cuadrada
    }
    public override bool Equals(object obj) //Comprobamos si son iguales las esferas comparando la posicion y el radio
    {
        if (obj is SphereC)
        {
            SphereC other = (SphereC)obj;
            return position == other.position && radius == other.radius;
        }
        return false;
    }
    #endregion

    #region FUNCTIONS
    #endregion

}