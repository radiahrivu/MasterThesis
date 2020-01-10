using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaController : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.playOnAwake = false;
    }

    public void OnClickPlayVideo()
    {

    }
}
