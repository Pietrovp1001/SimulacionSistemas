using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sin : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int instances = 50;
    [SerializeField] [Range(0, 10)] private float separacion = 0.5f;
    [SerializeField] [Range(0, 10)] private float amplitud = 1f;
    void Start()
    {
        for (int i = 0; i < instances; i++)
        {
            Instantiate(prefab, transform);
        }
    }
    void Update()
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            float x = i * separacion;
            float y = Mathf.Sin(Time.time + x);
            child.transform.localPosition = new Vector3(x, amplitud * y);
            i++;
        }
    }
}
