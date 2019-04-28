using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameAudio : MonoBehaviour
{
    public AudioClip[] greenVoiceLines;
    public AudioClip[] greenCollisionSounds;
    public AudioClip[] greenStartSounds;
    public AudioClip[] greenRound2Sounds;
    public AudioClip[] greenFirstSounds;

    public AudioClip[] redVoiceLines;
    public AudioClip[] redCollisionSounds;
    public AudioClip[] redStartSounds;
    public AudioClip[] redRound2Sounds;
    public AudioClip[] redFirstSounds;



    public int cdTime;

    private AudioSource source;
    private int cd;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        PlayStartSound();
        Spawner.OnRoundChange += PlayRound2Sound;
        GreenEvent.OnCollision += PlayGreenSound;
        RedEvent.OnCollision += PlayRedSound;
        PointsManager.OnGreenFirst += PlayGreenFirst;
        PointsManager.OnRedFirst += PlayRedFirst;
    }

    void PlayGreenFirst()
    {
        source.clip = greenFirstSounds[Random.Range(0, greenFirstSounds.Length)];
        source.Play();
    }

    void PlayRedFirst()
    {
        source.clip = redFirstSounds[Random.Range(0, redFirstSounds.Length)];
        source.Play();
    }

    void PlayRound2Sound()
    {
        if (Random.Range(0, 10) >= 5)
            source.clip = greenRound2Sounds[Random.Range(0, greenRound2Sounds.Length)];
        else
            source.clip = redRound2Sounds[Random.Range(0, redRound2Sounds.Length)];

        source.Play();
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

    private void OnDestroy()
    {
        Spawner.OnRoundChange -= PlayRound2Sound;
        GreenEvent.OnCollision -= PlayGreenSound;
        RedEvent.OnCollision -= PlayRedSound;
        PointsManager.OnGreenFirst -= PlayGreenFirst;
        PointsManager.OnRedFirst -= PlayRedFirst;
    }
}