using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisicClassScript : MonoBehaviour
{
    public Vector3 accelerationVector;
    public Vector3 velocityVector2;
    // come�a chamando o primeiro frame atualizado    
    void Start()
    {
    }
    // Atualiza chamando uma vez por frame    
    void FixedUpdate()
    {
        UpdateVelocity();
        transform.position += velocityVector2 * Time.deltaTime + (accelerationVector * (Time.deltaTime * Time.deltaTime) / 2);
    }
    void UpdateVelocity()
    {
        velocityVector2 += accelerationVector * Time.deltaTime;
    }
}
