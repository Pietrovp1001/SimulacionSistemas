using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct MyVector2D
{
    public float x;
    public float y;
    
    public MyVector2D(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    
    public MyVector2D Sum(MyVector2D a)
    {
        return new MyVector2D();
    }

    public void Draw(Color color)
    {
        Debug.DrawLine(Vector3.zero, new Vector3(x, y, 0), color);
    }
    public void Draw(MyVector2D newOrigins, Color color)
    {
        Debug.DrawLine(new Vector3(newOrigins.x, newOrigins.y), new Vector3(newOrigins.x + x, newOrigins.y+ y), color);
    }
    
    public static  MyVector2D operator +(MyVector2D a, MyVector2D b)
    {
        return new MyVector2D(a.x + b.x, a.y + b.y);
    }
    
    public static  MyVector2D operator -(MyVector2D a, MyVector2D b)
    {
        return new MyVector2D(a.x - b.x, a.y - b.y);
    }
    
    public  static MyVector2D operator *(MyVector2D a, float b)
    {
        return new MyVector2D(a.x * b, a.y * b);
    }
    
    public static MyVector2D operator *(float b, MyVector2D a) 
    {     
        return new MyVector2D(a.x * b, a.y * b);
    }
    
    public MyVector2D Mult(MyVector2D a) 
    {                          
        return new MyVector2D(x * a.x, y * a.y);
    }

}   

    
