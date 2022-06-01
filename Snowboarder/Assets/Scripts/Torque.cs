using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour
{
    [SerializeField] float torqueAmount = 10;
    [SerializeField] float BoostSpeed = 60;
    [SerializeField] float BaseSpeed;

    public bool canMove {get; private set;} = true;
    Rigidbody2D rb2d;

    SurfaceEffector2D surfaceEffector2D;
    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        BaseSpeed = surfaceEffector2D.speed;
    }

    void Update()
    {
        if (canMove)
        {
            Rotate();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }
    private void RespondToBoost()
    {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                surfaceEffector2D.speed = BoostSpeed;
            }

            else if (surfaceEffector2D.speed != BaseSpeed)
            {
                surfaceEffector2D.speed = BaseSpeed;
            }
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
