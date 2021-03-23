using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCames : MonoBehaviour
{
    public Animator CameraAnim;
    public float maxTime;

    void Start()
    {
        CameraAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (maxTime > 20)
        {
            CameraAnim.SetBool("isRotate", true);
        }
        if (maxTime > 23)
        {
            CameraAnim.SetBool("isRotate", false);
            maxTime = 0;
        }
        maxTime += Time.deltaTime;
    }
}
