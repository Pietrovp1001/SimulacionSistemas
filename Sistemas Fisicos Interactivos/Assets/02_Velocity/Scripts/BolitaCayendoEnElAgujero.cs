using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolitaCayendoEnElAgujero : MonoBehaviour
{
    
    private MyVector2D position;
    
    [SerializeField]private MyVector2D velocity;
    [SerializeField]private MyVector2D acceleration; 
    
    [Header("World")]
    [SerializeField]private Camera camera;
    [SerializeField] private Transform Agujero;
    
    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate() 
    {
        Move();
    }

    void Update()
    {
        position.Draw(Color.red);
        velocity.Draw(position, Color.green);
        acceleration.Draw(position, Color.blue);
        
        MyVector2D miPosicion = new MyVector2D(transform.position.x, transform.position.y);
        MyVector2D posicionAgujero = new MyVector2D(Agujero.position.x, Agujero.position.y);
        
        acceleration = posicionAgujero - miPosicion;
    }
    public void Move()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        
        position = position + velocity * Time.fixedDeltaTime;
        
        //Actualizamos la posicion de la bola
        transform.position = new Vector3(position.x, position.y, 0);
    }
}

