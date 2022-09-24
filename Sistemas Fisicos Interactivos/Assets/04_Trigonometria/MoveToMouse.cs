using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{ 
    private enum MovementMode {
        Constant,
        Acceleration
    } 
   
    [SerializeField] private MovementMode movementMode;
    [SerializeField] private float speed;
    private Vector3 acceleration;
    private Vector3 velocity;
    

    private void Update() 
    {
        UpdateMovementVectors();
        
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        
        RotateZ(Mathf.Atan2(velocity.y, velocity.x) - Mathf.PI / 2f);
    }

    private void UpdateMovementVectors() 
    {
        if (movementMode == MovementMode.Constant)
        {
            velocity = GetWorldMousePosition() - transform.position;
            velocity.z = 0;
            velocity.Normalize();
            velocity *= speed;
            acceleration *= 0;
        }
        else if (movementMode == MovementMode.Acceleration) 
        {
            acceleration = GetWorldMousePosition() - transform.position;
            velocity.z = 0;
        }
    }

    private Vector3 GetWorldMousePosition() 
    {
        Camera camera = Camera.main;
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        Vector4 mousewWorldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        return mousewWorldPosition;
    }
    private void RotateZ(float radians) 
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}

