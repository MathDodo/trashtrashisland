using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameAudio : MonoBehaviour
{
    public AudioClip[] voiceLines;
    public AudioClip[] collisionSounds;

    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        Event.OnCollision += PlaySound;
    }

    void PlaySound()
    {
        if(Random.Range(0,10) >= 5)
        {
            PlayCollisionSound();
        }
        else
        {
            PlayVoiceLine();
        }
    }
    
    void PlayCollisionSound()
    {
        source.clip = collisionSounds[Random.RandomRange(0, collisionSounds.Length)];
        source.Play();
    }

    void PlayVoiceLine()
    {
        source.clip = voiceLines[Random.RandomRange(0, voiceLines.Length)];
        source.Play();
    }

}
