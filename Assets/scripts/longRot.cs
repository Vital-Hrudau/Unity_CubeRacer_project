using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longRot : MonoBehaviour
{
    float speedRotate;
    void Start()
    {
        speedRotate = Random.Range(-0.1f,1.5f);
    }

    
    void Update()
    {
        transform.Rotate(0, speedRotate, 0); 
    }
}
