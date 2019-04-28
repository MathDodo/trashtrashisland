﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public delegate void Collision();
    public static event Collision OnCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision();
    }
}
