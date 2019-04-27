using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    public float BobbingMagnitude = 10;
    public float BobbingSeed = 1;
    public bool MoveX = true;
    public bool MoveY = true;

    Vector2 startPos;
    Vector3 startScale;

    void Start()
    {
        startPos = transform.localPosition;
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector2(
            MoveX ? startPos.x + BobbingMagnitude * (Mathf.Sin(Time.time * BobbingSeed)) : startPos.x,
            MoveY ? startPos.y + BobbingMagnitude * (Mathf.Sin(Time.time * BobbingSeed)) : startPos.y
        );

        transform.localScale = new Vector3(
            startScale.x + .1f * (Mathf.Sin(Time.time * BobbingSeed)),
            startScale.y + .1f * (Mathf.Sin(Time.time * BobbingSeed)),
            startScale.z + .1f * (Mathf.Sin(Time.time * BobbingSeed))
        );
    }
}