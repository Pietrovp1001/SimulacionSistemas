using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarExperiments : MonoBehaviour
{
    
    [Header("Polar Coordinates")]
    [SerializeField]  private float initialRadio = 1f;
    [SerializeField] [Range(0,10)]private float speed = 1f; 
    private float theta;
    
    private float radius = 0.5f;
    bool lim1, lim2;

    void Update()
    {
        if (radius >= 0 && radius < 5)
        {
            if (!lim1) radius += initialRadio * Time.deltaTime;
            else lim2 = false; radius -= initialRadio * Time.deltaTime;
        }
        else if (radius > 5)
        {
            lim2 = true; radius -= initialRadio * Time.deltaTime;
        }
        else if(radius < 0 && radius > -5)
        {
            if (!lim2) radius -= initialRadio * Time.deltaTime;
            else lim1 = false; radius += initialRadio * Time.deltaTime;
        }
        else if (radius < -5)
        {
            lim2 = true; radius += initialRadio * Time.deltaTime;
        }
        theta += speed * Time.deltaTime;
        radius += initialRadio * Time.deltaTime;

        Vector3 cartesian = PolarToCartesian(radius, theta);
        transform.localPosition = cartesian;

        Debug.DrawLine(Vector3.zero, cartesian, Color.yellow);
    }
    Vector3 PolarToCartesian(float radio, float theta)
    {
        return new Vector3(radio * Mathf.Cos(theta), radio * Mathf.Sin(theta));
    }
}
