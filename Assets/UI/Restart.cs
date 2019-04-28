using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Restart : MonoBehaviour
{

    public VideoPlayer vPlayer1;
    public VideoPlayer vPlayer2;
    public VideoPlayer vPlayer3;
    public GameObject vid1;
    public GameObject vid2;
    public GameObject vid3;


    private void Start()
    {
        StartCoroutine(Restarter());

    }

    IEnumerator Restarter()
    {
        yield return new WaitForSeconds(3);
        vPlayer1.Play();
        yield return new WaitForSeconds(1);
        vPlayer2.Play();
        yield return new WaitForSeconds(1);
        vPlayer3.Play();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
