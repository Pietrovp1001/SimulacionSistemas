using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBolita : MonoBehaviour
{
    
    private MyVector2D position;
    
    [SerializeField]private MyVector2D velocity;
    [SerializeField]private MyVector2D acceleration; 
    [Range(0,1f)] [SerializeField]private float dampingFactor = 0.9f;
    
    [Header("World")]
    [SerializeField]private Camera camera;
    
    private int actualAcceleration = 0;

    private readonly MyVector2D[] directions = new MyVector2D [4]
    {
        
        //Estas son las direcciones a las cuales debe cambiar nuestra bolita
        
        new MyVector2D(0, -9.8f), //Hacia abajo
        new MyVector2D(9.8f, 0), //Hacia la derecha
        new MyVector2D(0, 9.8f), //Hacia arriba
        new MyVector2D(-9.8f, 0) //Hacia la izquierda
    };
    
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
        //Pintamos la posicion de la bola
        position.Draw(Color.red);
        velocity.Draw(position, Color.green);
        acceleration.Draw(position, Color.blue);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Cambiamos la direccion de la bolita
            acceleration = directions[(actualAcceleration++) % directions.Length];
            velocity *= 0;
        }
    }
    public void Move()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;
        
        //Chequeamos si la bolita sale de la pantalla horizontalmente
        if (position.x > camera.orthographicSize)
        {
            velocity.x *= -1;
            position.x = camera.orthographicSize;
            velocity *= dampingFactor;
        }
        else if (position.x < -camera.orthographicSize)
        {
            
            velocity.x *= -1;
            position.x = -camera.orthographicSize;
            velocity *= dampingFactor;
        }
        
        //Chequeamos si la bolita sale de la pantalla verticalmente
        if (position.y > camera.orthographicSize)
        {
            velocity.y *= -1;
            position.y = camera.orthographicSize;
            velocity *= dampingFactor;
        }
        else if (position.y < -camera.orthographicSize)
        {
            velocity.y *= -1;
            position.y = -camera.orthographicSize;
            velocity *= dampingFactor;
        }
        
        transform.position = new Vector3(position.x, position.y, 0);
    }
}

