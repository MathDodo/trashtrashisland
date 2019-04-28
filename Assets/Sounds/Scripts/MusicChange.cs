using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{

    public AudioClip round2Music;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        Spawner.OnRoundChange += ChangeMusic;
    }

    void ChangeMusic()
    {
        source.Stop();
        source.clip = round2Music;
        source.Play();
    }
}
