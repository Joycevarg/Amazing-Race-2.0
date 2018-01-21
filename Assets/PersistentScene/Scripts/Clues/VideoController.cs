using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

    public VideoPlayer videoPlayer;
    public CluesController cluesController;
    public int clueNo;

	void Update () {
        //if (cluesController.currentClueDisp==clueNo)
        //{
        //    if (!videoPlayer.isPlaying)
        //    {
        //        Debug.Log("Playing Started");
        //        videoPlayer.Play();
        //    }
        //}
        //else
        //{
        //    if (videoPlayer.isPlaying)
        //    {
        //        Debug.Log("Stopped Playing");
        //        videoPlayer.Stop();
        //    }
        //}
	}
}
