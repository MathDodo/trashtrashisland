using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [SerializeField]
    private bool _green;

    [SerializeField]
    private string _speed, _right, _left;

    public float acceleration;
    public float rotation;
    public float maxSpeed;
    public float friction;
    public AudioClip start;
    public AudioClip stop;
    public AudioClip loop;
    public Transform[] childTrans;
    public GameObject sailingAnimation;

    private Rigidbody2D rBody;
    private AudioSource audioSource;
    private bool sailing;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        sailing = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetButton(_left))
        {
            foreach (Transform t in childTrans)
            {
                t.Rotate(new Vector3(0, 0, rotation));
            }
        }

        if (Input.GetButton(_right))
        {
            foreach (Transform t in childTrans)
            {
                t.Rotate(new Vector3(0, 0, -rotation));
            }
        }

        if (Input.GetButton(_speed))
        {
            rBody.AddForce(childTrans[0].right * acceleration);
        }

        rBody.velocity = rBody.velocity * friction;

        if (rBody.velocity.magnitude > maxSpeed)
        {
            rBody.velocity = rBody.velocity.normalized * maxSpeed;
        }

        if (Input.GetButtonDown(_speed))
        {
            sailing = true;
            StartCoroutine(StartSound());
        }

        if (Input.GetButtonUp(_speed))
        {
            sailing = false;
            audioSource.Stop();
            audioSource.clip = stop;
            audioSource.loop = false;
            audioSource.Play();
        }

        if (rBody.velocity.magnitude < 0.1) sailingAnimation.SetActive(false);
        else sailingAnimation.SetActive(true);
    }

    private IEnumerator StartSound()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trash"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            audioSource.enabled = false;
            PointsManager.Instance.PointCounting(_green ? 0 : 1);
            rBody.constraints = RigidbodyConstraints2D.FreezeAll;

            enabled = false;

            GetComponentInChildren<Collider2D>().enabled = false;
            sailingAnimation.SetActive(false);
        }
    }
}