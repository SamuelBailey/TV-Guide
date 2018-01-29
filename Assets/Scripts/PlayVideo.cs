using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    VideoPlayer videoPlayer;

    private void OnEnable()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Prepare();
    }

    // private void Start()
    // {
    //     videoPlayer = gameObject.GetComponent<VideoPlayer>();
    // }
    // 
    // private void OnEnable()
    // {
    //     videoPlayer.Play();
    // }
    // 
    // public void PlayPause()
    // {
    //     if (videoPlayer.isPlaying)
    //         videoPlayer.Pause();
    //     else
    //         videoPlayer.Play();
    // }
}
