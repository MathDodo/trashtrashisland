using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [SerializeField]
    private bool _green;

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
        if (Input.GetKey(left))
        {
            foreach (Transform t in childTrans)
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
            PointsManager.Instance.PointCounting(_green ? 0 : 1);
            rBody.constraints = RigidbodyConstraints2D.FreezeAll;

            enabled = false;

            GetComponentInChildren<Collider2D>().enabled = false;
            sailingAnimation.SetActive(false);
        }
    }
}