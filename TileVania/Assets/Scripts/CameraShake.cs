using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    Transform thisCamera;

    void Start()
    {
        thisCamera = GetComponent<Transform>();
        for (int i = 0; i < 10; i++)
        {
            Invoke("Rotate", 0.1f);
            Invoke("Shake", 0.1f);
            //Rotate();
            //Shake();
        }
    }

    void Rotate()
    {
        thisCamera.RotateAround(thisCamera.position, new Vector3(0,0,1), Random.Range(-20,20));
    }

    void Shake()
    {
        thisCamera.position += new Vector3(Random.Range(-50,50),Random.Range(-50,50),0);
    }
}
