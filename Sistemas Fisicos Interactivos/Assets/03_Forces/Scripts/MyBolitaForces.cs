using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBolitaForces : MonoBehaviour
{
    public enum  BolitaModes
    {
        Friction,
        FluidFriction,
        Gravity,
    }
    
    private MyVector2D position;
    
    [SerializeField] private BolitaModes runMode;
    [SerializeField]private MyVector2D velocity;
    [SerializeField]private MyVector2D acceleration;
    [SerializeField] private float mass = 1f;
    
    [Header("Fuerzas")]
    [SerializeField]private MyVector2D gravity;
    [SerializeField]private MyVector2D wind;
    
    [Header("World")]
    [SerializeField]private Camera camera;
    [Range(0,1f)] [SerializeField]private float dampingFactor = 0.9f;
    [SerializeField]private MyBolitaForces otherBolita;
    [Range(0,1f)] [SerializeField]private float frictionCoefficient = 0.9f;

    void Start()
    {

        position = new MyVector2D(transform.position.x, transform.position.y);
    }
    private void FixedUpdate() 
    {
        acceleration *= 0f;
        if (runMode != BolitaModes.Gravity)
        {
            MyVector2D weight = gravity * mass;
            ApplyForce(weight);
        }
        if (runMode == BolitaModes.FluidFriction)
        {
           ApplyFluidFriction();
        }
        else if (runMode == BolitaModes.Friction)
        {
            ApplyFriction();
        }
        else if (runMode == BolitaModes.Gravity)
        {
            MyVector2D diff = otherBolita.position - position;
            float distance = diff.magnitude;
            float scalarPart =  (mass * otherBolita.mass) / (distance * distance);
            MyVector2D gravityForce = diff.normalized * scalarPart;
            ApplyForce(gravityForce);
        }
        Move();
    }
    void Update()
    {
        //Pintamos la posicion de la bola
        position.Draw(Color.red);
        velocity.Draw(position, Color.green);
        acceleration.Draw(position, Color.blue);
    }
    public void Move()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;

        if (runMode != BolitaModes.Gravity)
        {
            CheckWorldBoxBounds();
        }

        transform.position = new Vector3(position.x, position.y, 0);
    }
    private void ApplyForce(MyVector2D force)
    {
        acceleration += force / mass;
    }

    public void ApplyFriction()
    {
        float N = -mass * gravity.y;
        MyVector2D friction = -frictionCoefficient * N * velocity.normalized ;
        ApplyForce (friction) ;
    }

    public void ApplyFluidFriction()
    {
        if (transform.localPosition.y <=0)
        {
            float frontalArea = transform.localScale.x;
            float rho = 1;
            float fluidDragCoefficient = 1F;
            float velocityMagnitude = velocity.magnitude;
            float scalarPart = -0.5f * rho * velocityMagnitude * velocityMagnitude *frontalArea * fluidDragCoefficient;
            MyVector2D friction = velocity.normalized * scalarPart;
            ApplyForce(friction);
        }
    }

    public void CheckWorldBoxBounds()
    {
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
    }
}

