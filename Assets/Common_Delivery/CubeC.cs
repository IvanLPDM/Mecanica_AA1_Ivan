using System;

[System.Serializable]
public struct CubeC
{
    #region FIELDS
    public Vector3C position;
    public Vector3C scale;
    public Vector3C rotation; // o puede ser un float para el ángulo de rotación
    public float radius; // si es un cubo, puede ser el radio de la esfera circunscrita
    #endregion

    #region PROPIERTIES
    #endregion

    #region CONSTRUCTORS
    public CubeC(Vector3C position, Vector3C scale, Vector3C rotation, float radius)
    {
        this.position = position;
        this.scale = scale;
        this.rotation = rotation;
        this.radius = radius;
    }
    #endregion

    #region OPERATORS
    #endregion

    #region METHODS
    public bool IsInside(Vector3C point)
    {
        // Obtiene los límites del cubo en cada dimensión
        float minX = position.x - scale.x / 2;
        float maxX = position.x + scale.x / 2;
        float minY = position.y - scale.y / 2;
        float maxY = position.y + scale.y / 2;
        float minZ = position.z - scale.z / 2;
        float maxZ = position.z + scale.z / 2;

        // Verifica si el punto está dentro de los límites del cubo
        if (point.x >= minX && point.x <= maxX &&
            point.y >= minY && point.y <= maxY &&
            point.z >= minZ && point.z <= maxZ)
        {
            return true;
        }

        return false;
    }

    public bool Equals(CubeC other)
    {
        if (position == other.position &&
        scale == other.scale &&
        rotation == other.rotation &&
        radius == other.radius)
        {
            return true;
        }

        return false;
    }
    #endregion

    #region FUNCTIONS
    #endregion

}