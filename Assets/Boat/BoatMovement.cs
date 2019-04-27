using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{

    public float acceleration;
    public float rotation;
    public float maxSpeed;
    public Transform parentTrans;
    public float friction;

    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        //StartCoroutine(FrictionRoutine());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            parentTrans.Rotate(new Vector3(0, 0, rotation));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            parentTrans.Rotate(new Vector3(0, 0, -rotation));
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rBody.AddForce(transform.up * acceleration);   
        }

        rBody.velocity = rBody.velocity * friction;

        if (rBody.velocity.magnitude > maxSpeed)
        {
            rBody.velocity = rBody.velocity.normalized * maxSpeed;
        }

    }

    IEnumerator FrictionRoutine()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(1);
        }
    }


}
