using System;
using System.Numerics;

[System.Serializable]
public struct Vector3C
{
    #region FIELDS
    public float x;
    public float y;
    public float z;
    #endregion

    #region PROPIERTIES
    public float r { get => x; set => x = value; }
    public float g { get => y; set => y = value; }
    public float b { get => z; set => z = value; }
    public float magnitude { get { return Magnitude(x, y, z); } }
    public Vector3C normalized { get { return Normalize(x, y, z); } }

    public static Vector3C zero { get { return new Vector3C(0, 0, 0); } }
    public static Vector3C one { get { return new Vector3C(1, 1, 1); } }
    public static Vector3C right { get { return new Vector3C(1, 0, 0); } }
    public static Vector3C up { get { return new Vector3C(0, 1, 0); } }
    public static Vector3C forward { get { return new Vector3C(0, 0, 1); } }

    public static Vector3C black { get { return new Vector3C(0, 0, 0); } }
    public static Vector3C white { get { return new Vector3C(1, 1, 1); } }
    public static Vector3C red { get { return new Vector3C(1, 0, 0); } }
    public static Vector3C green { get { return new Vector3C(0, 1, 0); } }
    public static Vector3C blue { get { return new Vector3C(0, 0, 1); } }
    #endregion

    #region CONSTRUCTORS
    public Vector3C(float x, float y, float z)
    {
        this.x = x; this.y = y; this.z = z;
    }
    public Vector3C(Vector3C v1, Vector3C v2) : this()
    {
        Vector3C NewVector = v2 - v1;

        this.x = NewVector.x;
        this.y = NewVector.y;
        this.z = NewVector.z;
    }
    #endregion

    #region OPERATORS
    public static Vector3C operator +(Vector3C a)
    {
        return +a;
    }

    public static Vector3C operator -(Vector3C a)
    {
        return -a;
    }

    public static Vector3C operator +(Vector3C a, Vector3C b)
    {
        return new Vector3C( a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static Vector3C operator -(Vector3C a, Vector3C b)
    {
        return new Vector3C(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static Vector3C operator *(Vector3C a, float b)
    {
        return new Vector3C(a.x*b, a.y*b, a.z*b);
    }

    public static Vector3C operator *(Vector3C a, Vector3C b)
    {
        return new Vector3C(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
    }

    public static Vector3C operator /(Vector3C a, float b)
    {
        return new Vector3C(a.x / b, a.y / b, a.z / b);
    }

    public static Vector3C operator /(Vector3C a, Vector3C b)
    {
        return new Vector3C(0, 0, 0);
    }

    public static bool operator ==(Vector3C a, Vector3C b)
    {
        if (a.x == b.x && a.y == b.y && a.z == b.z) return true;
        else
            return false;
    }

    public static bool operator !=(Vector3C a, Vector3C b)
    {
        if (a.x == b.x && a.y == b.y && a.z == b.z) return true;
        else
            return false;
    }



    #endregion

    #region METHODS
    public Vector3C Normalize(float x, float y, float z)
    {
        float newX = x / magnitude;
        float newY = y / magnitude;
        float newZ = z / magnitude;

        return new Vector3C(newX, newY, newZ);
    }

    public float Magnitude(float x, float y, float z)
    {
        return (float)Math.Sqrt(x*x + y*y + z*z);
    }

    public override bool Equals(object obj)
    {
        if(obj is Vector3C)
        {
            Vector3C other = (Vector3C)obj;
            return other == this;
        }
        return false; //nptr
    }

    public static float AngleBetween(Vector3C v1, Vector3C v2)
    {
        // Calcula el producto punto entre los dos vectores
        float dotProduct = Dot(v1, v2);

        // Calcula las magnitudes de los vectores
        float magnitude1 = v1.magnitude;
        float magnitude2 = v2.magnitude;

        // Calcula el coseno del ángulo entre los vectores
        float cosAngle = dotProduct / (magnitude1 * magnitude2);

        // Usa la función arcocoseno para obtener el ángulo en radianes
        float angleInRadians = (float)Math.Acos(cosAngle);

        // Convierte el ángulo a grados si es necesario
        float angleInDegrees = angleInRadians * (180.0f / (float)Math.PI);

        return angleInDegrees;
    }


    #endregion

    #region FUNCTIONS
    public static float Dot(Vector3C v1, Vector3C v2) //Producto escalar
    {
        //calcular angulo
        float angulo = AngleBetween(v1, v2);
        return v1.magnitude * v2.magnitude * (float)Math.Cos(angulo);
    }

    public static Vector3C Cross(Vector3C v1, Vector3C v2) //Vector normal o perpendicular
    {
        return new Vector3C(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.y - v1.y *v2.x);
    }
    public static float Distance(Vector3C point1, Vector3C point2) //Calcula la distancia entre 2 vectores
    {
            float dx = point2.x - point1.x;
            float dy = point2.y - point1.y;
            float dz = point2.z - point1.z;

            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }

    public static float DistanceSquared(Vector3C point1, Vector3C point2) //Calcula la distancia entre 2 vectores sin hacer la raiz cuadrada
    {
        float dx = point2.x - point1.x;
        float dy = point2.y - point1.y;
        float dz = point2.z - point1.z;

        return dx * dx + dy * dy + dz * dz;
    }
    #endregion

}