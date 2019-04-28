using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingameAnimationManager : MonoBehaviour
{
    Animator animator;
    bool hasPlayedRoundTwo;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PointsManager.Instance._RoundTwo && !hasPlayedRoundTwo)
        {
            hasPlayedRoundTwo = true;
            animator.Play("Round 2");
        }
    }
}