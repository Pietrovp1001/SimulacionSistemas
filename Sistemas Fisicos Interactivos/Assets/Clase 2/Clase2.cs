using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Clase2 : MonoBehaviour
{

    [SerializeField] MyVector2D myFirstVector = new MyVector2D(-3,3);
    [SerializeField] MyVector2D mySecondVector = new MyVector2D(3,3);
    [Range(0,1)][SerializeField] float scalar = 0;
    
    /*void Start()
    {
    MyVector2D a = new MyVector2D();
    MyVector2D b = new MyVector2D();
  
    MyVector2D au = new MyVector2D(2,4);
    MyVector2D bu = new MyVector2D(3,5);
   
    }
    */
    private void Update()
    {
        
        myFirstVector.Draw(Color.red);
        mySecondVector.Draw(Color.green);
        
        //MyVector2D ResultSuma = myFirstVector + mySecondVector;
        //ResultSuma.Draw(Color.yellow);
        
        MyVector2D Result = (mySecondVector - myFirstVector) * scalar;
        Result.Draw(Color.yellow);

        MyVector2D Result2 = myFirstVector + Result; 
        
        Result2.Draw(Color.yellow);
        Result.Draw(myFirstVector, Color.yellow);
        Result2.Draw(Color.blue);
    }

}
