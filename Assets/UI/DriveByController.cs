using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveByController : MonoBehaviour
{
    public int IntervalMin = 10;
    public int IntervalMax = 30;

    float timer = 0;
    Animator animtor;

    private void Start()
    {
        timer = Random.Range(IntervalMin, IntervalMax);
        animtor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            timer = Random.Range(IntervalMin, IntervalMax);
            animtor.Play("Menu Drive by");
        }
        else
            timer -= Time.deltaTime;
    }
}