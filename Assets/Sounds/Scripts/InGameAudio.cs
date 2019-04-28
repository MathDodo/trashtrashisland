using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameAudio : MonoBehaviour
{
    public AudioClip[] greenVoiceLines;
    public AudioClip[] greenCollisionSounds;
    public AudioClip[] greenStartSounds;

    public AudioClip[] redVoiceLines;
    public AudioClip[] redCollisionSounds;
    public AudioClip[] redStartSounds;



    public int cdTime;

    private AudioSource source;
    private int cd;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        PlayStartSound();
        GreenEvent.OnCollision += PlayGreenSound;
        RedEvent.OnCollision += PlayRedSound;
    }

    void PlayStartSound()
    {
        if(Random.Range(0,10) >= 5)
            source.clip = greenStartSounds[Random.Range(0, greenStartSounds.Length)];
        else
            source.clip = redStartSounds[Random.Range(0, redStartSounds.Length)];
        
        source.Play();
    }

    void PlayGreenSound()
    {
        if (cd > 0) return;

        if(Random.Range(0,10) >= 5)
        {
            source.clip = greenCollisionSounds[Random.RandomRange(0, greenCollisionSounds.Length)];
        }
        else
        {
            source.clip = greenVoiceLines[Random.RandomRange(0, greenVoiceLines.Length)];
            
        }
        source.Play();
        cd = cdTime;

        StartCoroutine(CoolDown());
    }

    void PlayRedSound()
    {
        if (cd > 0) return;

        if (Random.Range(0, 10) >= 5)
        {
            source.clip = redCollisionSounds[Random.RandomRange(0, redCollisionSounds.Length)];
        }
        else
        {
            source.clip = redVoiceLines[Random.RandomRange(0, redVoiceLines.Length)];

        }
        source.Play();
        cd = cdTime;

        StartCoroutine(CoolDown());
    }

    IEnumerator CoolDown()
    {
        while (cd > 0)
        {
            cd--;
            yield return new WaitForSeconds(1);
        }
    }
}
