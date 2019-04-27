using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{

    public float acceleration;
    public float rotation;
    public float maxSpeed;
    public float friction;
    public KeyCode left;
    public KeyCode right;
    public KeyCode forward;


    private Rigidbody2D rBody;
    
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        if (Input.GetKey(left))
        {
            transform.Rotate(new Vector3(0, 0, rotation));
        }

        if (Input.GetKey(right))
        {
            transform.Rotate(new Vector3(0, 0, -rotation));
        }

        if (Input.GetKey(forward))
        {
            rBody.AddForce(transform.up * acceleration);   
        }

        rBody.velocity = rBody.velocity * friction;

        if (rBody.velocity.magnitude > maxSpeed)
        {
            rBody.velocity = rBody.velocity.normalized * maxSpeed;
        }

    }
    

}
