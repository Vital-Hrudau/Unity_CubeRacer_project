using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    float speed;
    public float randMin, randMax;
    void Start()
    {
        speed = Random.Range(randMin,randMax);
    }

  
    void FixedUpdate()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
