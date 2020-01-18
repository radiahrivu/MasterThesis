using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;    

public class MediaController : MonoBehaviour
{
    public VideoClip videoClip;
    private VideoPlayer videoPlayer;
    public Renderer videoScreen;
    public RenderTexture videoMaterialTexture;

    public Material imageMaterial;
    public Renderer imageScreen;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public Image vs1;
    public Image vs2;
    public Image vs3;
    public Image vs4;
    public Image vs5;
    public Image vs6;
    public Image vs7;
    public Image vs8;
    public Image vs9;


    // Start is called before the first frame update
    //void Start()
    //{
    //    //var connectionString = "Data Source=(localdb)/MSSQLLocalDB;Initial Catalog=masterthesis;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    //    //var conn = new SqlConnection(connectionString);

    //    //try
    //    //{
    //    //    conn.Open();

    //    //    Debug.Log(conn.State);
    //    //}
    //    //catch (Exception e)
    //    //{
    //    //    Debug.Log(e);
    //    //}
    //}

    public void OnClickPlayVideo()
    {
        if (this.audioSource != null) this.audioSource.Stop();
        videoScreen.enabled = true;
        imageScreen.enabled = false;

        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        var audioSource = gameObject.AddComponent<AudioSource>();

        videoPlayer.playOnAwake = false;
        videoPlayer.clip = videoClip;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = videoMaterialTexture;
        videoPlayer.targetMaterialRenderer = videoScreen;
        videoPlayer.targetMaterialProperty = "_MainTex";
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);

        videoPlayer.Play();
    }

    public void OnClickPlayImage()
    {
        if (videoPlayer != null) videoPlayer.Stop();
        if (audioSource != null) audioSource.Stop();
        videoScreen.enabled = false;
        imageScreen.enabled = true;
    }

    public void OnClickPlayAudio()
    {
        if (videoPlayer != null) videoPlayer.Stop();
        videoScreen.enabled = false;
        imageScreen.enabled = false;

        audioSource.clip = audioClip;
        audioSource.Play(0);
    }

    public void OnClickShowValence()
    {
        if (videoPlayer != null) videoPlayer.Stop();
        if (audioSource != null) audioSource.Stop();
        videoScreen.enabled = false;
        imageScreen.enabled = false;

        vs1.enabled = true;
        vs2.enabled = true;
        vs3.enabled = true;
        vs4.enabled = true;
        vs5.enabled = true;
        vs6.enabled = true;
        vs7.enabled = true;
        vs8.enabled = true;
        vs9.enabled = true;
    }

    public void OnClickVS1()
    {
        Debug.Log("asdasdad");
    }

    public void OnClickVS2()
    {
        Debug.Log("asdasdad");
    }

    public void OnClickVS3()
    {
        Debug.Log("asdasdad");
    }

    public void OnClickVS4()
    {
        Debug.Log("asdasdad");
    }

    public void OnClickVS5()
    {
        Debug.Log("asdasdad");
    }

    public void OnClickVS6()
    {
        Debug.Log("asdasdad");
    }

    public void OnClickVS7()
    {
        Debug.Log("asdasdad");
    }

    public void OnClickVS8()
    {
        Debug.Log("asdasdad");
    }

    public void OnClickVS9()
    {
        Debug.Log("asdasdad");
    }
}
