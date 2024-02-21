using System;
using UnityEngine.UIElements;

[System.Serializable]
public struct LineC
{
    #region FIELDS
    public Vector3C origin;
    public Vector3C direction;

    #endregion

    #region PROPIERTIES
    #endregion

    #region CONSTRUCTORS
    public LineC(Vector3C origin, Vector3C direction)
    {
        this.origin = origin;
        this.direction = direction;


    }
    #endregion

    #region OPERATORS
    #endregion

    #region METHODS


    Vector3C NearestPointToPoint(Vector3C point) //el punto m�s cercano de la linea a otro punto
    {
        //Calcula el vector desde el punto inicial de la l�nea hasta el punto dado
        Vector3C fromOriginToPoint = point - origin;

        // Proyecta el vector desde el punto inicial hasta el punto dado sobre el vector de direcci�n de la l�nea
        float projectionFactor = Vector3C.Dot(fromOriginToPoint, direction.normalized);
        Vector3C projectedVector = direction.normalized * projectionFactor;

        // El punto m�s cercano en la l�nea al punto dado es el punto inicial de la l�nea m�s la proyecci�n
        Vector3C nearestPoint = origin + projectedVector;

        return nearestPoint;
    }

    public Vector3C NearestPointToLine(LineC otherLine) //El punto m�s cercano de una linea a otra linea
    {
        Vector3C lineToLine = otherLine.origin - origin;
        float t = Vector3C.Dot(lineToLine, direction.normalized);
        return origin + direction.normalized * t;
    }

    #endregion

    #region FUNCTIONS
    public static LineC FromPoints(Vector3C pointA, Vector3C pointB) //Dado 2 puntos crea una linea
    {
        Vector3C direction = pointB - pointA;
        return new LineC(pointA, direction);
    }
    #endregion

}