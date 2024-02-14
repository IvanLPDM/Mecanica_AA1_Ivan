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
        return new Vector3C(0,0,0);
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


    #endregion

    #region FUNCTIONS
    public static float Dot(Vector3C v1, Vector3C v2)
    {
        return v1.x*v2.x+v1.y*v2.y+v1.z*v2.z;
    }
    public static Vector3C Cross(Vector3C v1, Vector3C v2)
    {
        return new Vector3C();
    }
    #endregion

}