using System;
using UnityEngine;

[System.Serializable]
public struct PlaneC
{
    #region FIELDS
    public Vector3C position;
    public Vector3C normal;
    #endregion

    #region PROPIERTIES
    #region Propiedades
    public Vector3C right { get { return Vector3C.Cross(normal, Vector3C.up).normalized; } } 
    public Vector3C up { get { return Vector3C.Cross(right, normal).normalized; } }
    public Vector3C forward { get { return normal.normalized; } }
    #endregion
    #endregion

    #region CONSTRUCTORS
    public PlaneC(Vector3C position, Vector3C normal) //Crear un pano a partir de una posicion y un vector normal
    {
        this.position = position;
        this.normal = normal;
    }

    public PlaneC(Vector3C n, float D) : this() //Crear un plano a partir de 1 vector y una distancia
    {
        this.position = n * D;
        this.normal = n.normalized;
    }

    public PlaneC(Vector3C point1, Vector3C point2, Vector3C point3) : this() //Crear un plano a partud de 3 puntos
    {
        this.normal = Vector3C.Cross(point2 - point1, point3 - point1).normalized;
        this.position = point1;
    }

    public PlaneC(float a, float b, float c, float d) : this() //Crear un plano a partir de la ecuacion general
    {
        this.normal = new Vector3C(a, b, c).normalized;
        this.position = normal * (d / normal.magnitude);
    }
    #endregion

    #region OPERATORS

    #endregion

    #region METHODS
    public float[] ToEquation() //Crear la ecuacion general de la recta A + B + C + D = 0
    {
        float[] equation = new float[4];
        equation[0] = normal.x;
        equation[1] = normal.y;
        equation[2] = normal.z;
        equation[3] = Vector3C.Dot(normal, position);
        return equation;
    }

    public Vector3C NearestPoint(Vector3C point) //Punto más cercano del plano a otro punto
    {
        float distance = Vector3C.Dot(point - position, normal);
        return point - normal * distance;
    }

    public Vector3C Intersection(LineC line) //En que punto intersecciona una recta con el plano
    {
        Vector3C lineDirection = line.direction.normalized;
        float denom = Vector3C.Dot(normal, lineDirection);
        float minDistance = 0.0001f;

        if (Mathf.Abs(denom) > minDistance)
        {
            Vector3C pointToLine = position - line.origin;
            float t = Vector3C.Dot(pointToLine, normal) / denom;
            return line.origin + lineDirection * t;
        }
        else
        {
            throw new Exception("La línea es paralela al plano.");
        }
    }
    public bool Equals(PlaneC other) //Comparamos si los planos son iguales (vector normal y posicion)
    {
        return position == other.position && normal == other.normal;
    }

    #endregion

    #region FUNCTIONS
    #endregion

}