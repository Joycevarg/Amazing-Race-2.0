using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public AudioSource audioPlayer;
    public CluesController cluesController;
    public int clueNo;

    void Update()
    {
        //if (cluesController.currentClueDisp == clueNo)
        //{
        //    if (!audioPlayer.isPlaying)
        //    {
        //        Debug.Log("Playing Started");
        //        audioPlayer.Play();
        //    }
        //}
        //else
        //{
        //    if (audioPlayer.isPlaying)
        //    {
        //        Debug.Log("Stopped Playing");
        //        audioPlayer.Stop();
        //    }
        //}
    }
}
