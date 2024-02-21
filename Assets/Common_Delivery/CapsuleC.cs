using System;

[System.Serializable]
public struct CapsuleC
{
    #region FIELDS
    public Vector3C positionA;
    public Vector3C positionB;
    public float radius;
    #endregion

    #region PROPIERTIES
    #endregion

    #region CONSTRUCTORS
    public CapsuleC(Vector3C positionA, Vector3C positionB, float radius) //Creamos una capsula con el punto de abajo y el de arriba estirando la capsula
    {
        this.positionA = positionA;
        this.positionB = positionB;
        this.radius = radius;
    }

    public CapsuleC(Vector3C position, float radius, float height, Vector3C rotation) : this()
    {
        
    }
    #endregion

    #region OPERATORS
    #endregion

    #region METHODS
    public bool IsInside(Vector3C point)
    {
        // Calcula la distancia del punto al segmento AB
        Vector3C AB = positionB - positionA;
        Vector3C AP = point - positionA;

        // Calcula el producto escalar de AP y AB
        float dotProduct = Vector3C.Dot(AP, AB);

        // Calcula la magnitud al cuadrado de AB
        float magnitudeSquared = AB.magnitude * AB.magnitude;

        // Calcula la proyección de AP sobre AB
        Vector3C projection = AB * (dotProduct / magnitudeSquared);

        // Calcula la distancia al cuadrado entre AP y su proyección sobre AB
        float distanceToSegmentSquared = Vector3C.DistanceSquared(AP, projection);

        // Si la distancia al cuadrado es menor o igual al radio al cuadrado, el punto está dentro de la cápsula
        return distanceToSegmentSquared <= radius * radius;
    }

    public bool Equals(CapsuleC other) //Comparar con otra capsula
    {
        return positionA == other.positionA && positionB == other.positionB && radius == other.radius;
    }
    #endregion

    #region FUNCTIONS
    #endregion

}