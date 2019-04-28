using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayOnStart : MonoBehaviour
{

    public AudioClip[] sounds;

    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = sounds[Random.RandomRange(0, sounds.Length)];
        source.Play();
    }
}
