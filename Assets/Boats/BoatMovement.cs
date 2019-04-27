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
    public AudioClip start;
    public AudioClip stop;
    public AudioClip loop;
    public Transform[] childTrans;

    private Rigidbody2D rBody;
    private AudioSource audioSource;
    private bool sailing;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        sailing = false;
    }
    
    void FixedUpdate()
    {
        if (Input.GetKey(left))
        {
            foreach(Transform t in childTrans)
            {
                t.Rotate(new Vector3(0, 0, rotation));
            }
        }

        if (Input.GetKey(right))
        {
            foreach (Transform t in childTrans)
            {
                t.Rotate(new Vector3(0, 0, -rotation));
            }
        }

        if (Input.GetKey(forward))
        {
            rBody.AddForce(childTrans[0].right * acceleration);
        }

        rBody.velocity = rBody.velocity * friction;

        if (rBody.velocity.magnitude > maxSpeed)
        {
            rBody.velocity = rBody.velocity.normalized * maxSpeed;
        }

        if (Input.GetKeyDown(forward))
        {
            sailing = true;
            StartCoroutine(StartSound());
        }

        if (Input.GetKeyUp(forward))
        {
            sailing = false;
            audioSource.Stop();
            audioSource.clip = stop;
            audioSource.loop = false;
            audioSource.Play();
        }
    }

    IEnumerator StartSound()
    {
        audioSource.clip = start;
        audioSource.Play();
        yield return new WaitForSeconds(1);
        if (sailing)
        {
            audioSource.Stop();
            audioSource.clip = loop;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
