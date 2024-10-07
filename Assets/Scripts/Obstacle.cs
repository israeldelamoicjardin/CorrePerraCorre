using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float moveSpeed = 4f;
    public float rangoDeMovimiento = -10f;


    // Update is called once per frame
    void Update()
    {
        transform.position  += (Vector3.left* moveSpeed* Time.deltaTime);
        if(transform.position.x < rangoDeMovimiento)
        {
            // te has salido de la cámara, desaparece, objeto
            Destroy(gameObject);
        }
    }
}
