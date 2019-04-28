using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Restart : MonoBehaviour
{

    public VideoPlayer vPlayer;

    private void Start()
    {
        StartCoroutine(Restarter());
    }

    IEnumerator Restarter()
    {
        yield return new WaitForSeconds(3);
        vPlayer.Play();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
