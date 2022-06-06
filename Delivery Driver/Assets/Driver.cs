using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]    float moveSpeed = 225;
    [SerializeField]    float steerSpeed = 175;
    [SerializeField] float DefaultSpeed = 225;
    [SerializeField] float slowSpeed = 100;
    [SerializeField] float boostSpeed = 300;
    [SerializeField] float timeSpeedChange = 3.5f;
    float speedTimer = 0;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal")*steerSpeed * Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical")*moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,speedAmount/10,0);
        //transform.Rotate(new Vector3(0,0,0), 10);
        
        if(speedTimer <= 0 && moveSpeed != DefaultSpeed)
        {
            moveSpeed = DefaultSpeed;
            Debug.Log("Default speed is active");
        }
        else if (speedTimer > 0 )
        {
            speedTimer -= Time.deltaTime; 
        }
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag != "Bumper")
        {
            moveSpeed = slowSpeed;
            speedTimer = timeSpeedChange;
            Debug.Log("Slow speed is active");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
            speedTimer = timeSpeedChange;
            Debug.Log("Boost speed is active");
        }    
    }
}
