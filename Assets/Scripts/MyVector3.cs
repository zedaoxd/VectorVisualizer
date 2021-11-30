using UnityEngine;

[System.Serializable]
public struct MyVector3
{
    public float X;
    public float Y;
    public float Z;

    public float Magnitude => Mathf.Sqrt(SqrMagnitude);
    public float SqrMagnitude => X * X + Y * Y + Z * Z;
    public MyVector3 Normalized => this * (1.0f / Magnitude);
    public static MyVector3 Right => new MyVector3(1.0f, 0, 0);
    public static MyVector3 Up => new MyVector3(0, 1.0f, 0);
    public static MyVector3 Forward => new MyVector3(0, 0, 1.0f);

    public MyVector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public MyVector3 Add(in MyVector3 vector)
    {
        return new MyVector3(X + vector.X, Y + vector.Y, Z + vector.Z);
    }

    public MyVector3 Scale(float k)
    {
        return new MyVector3(X * k, Y * k, Z * k);
    }

    public static MyVector3 operator +(in MyVector3 a, in MyVector3 b)
    {
        return a.Add(b);
    }

    public static MyVector3 operator *(in MyVector3 v, float k)
    {
        return v.Scale(k);
    }

    public static implicit operator Vector3(MyVector3 v)
    {
        return new Vector3(v.X, v.Y, v.Z);
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }
}
