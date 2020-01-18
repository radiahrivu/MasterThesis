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

    public Button ButtonStartExperiment;
    public Text TopText;

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

    public void OnClickStartExperiment()
    {
        StartCoroutine(StartExperiment());
    }

    IEnumerator StartExperiment()
    {
        yield return new WaitForSeconds(.5f);

        yield return StartCoroutine(PlayVideo());
        yield return StartCoroutine(Sleep(60)); // Duration of the Video: 60s
        yield return StartCoroutine(Sleep(30)); // 30s break

        yield return StartCoroutine(ShowManikin());
        yield return StartCoroutine(Sleep(30)); // 30s display time
        yield return StartCoroutine(Sleep(30)); // 30s break

        yield return StartCoroutine(PlayImage());
        yield return StartCoroutine(Sleep(30)); // 30s display time
        yield return StartCoroutine(Sleep(30)); // 30s break

        yield return StartCoroutine(ShowManikin());
        yield return StartCoroutine(Sleep(30)); // 30s display time
        yield return StartCoroutine(Sleep(30)); // 30s break

        yield return StartCoroutine(PlayAudio());
        yield return StartCoroutine(Sleep(187)); // Duration of the Audio: 187s
        yield return StartCoroutine(Sleep(30)); // 30s break

        yield return StartCoroutine(ShowManikin());
        yield return StartCoroutine(Sleep(30)); // 30s display time
        yield return StartCoroutine(Sleep(30)); // 30s break
    }

    IEnumerator PlayVideo()
    {
        yield return StartCoroutine(ScreenSetups(true));

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

        yield return null;
    }

    IEnumerator PlayImage()
    {
        yield return StartCoroutine(ScreenSetups(false, true));

        yield return null;
    }

    IEnumerator PlayAudio()
    {
        yield return StartCoroutine(ScreenSetups());

        audioSource.clip = audioClip;
        audioSource.Play(0);

        yield return null;
    }

    IEnumerator ShowManikin()
    {
        yield return StartCoroutine(ScreenSetups(false, false, true, true, true, true, true, true, true, true, true));

        yield return null;
    }

    IEnumerator ScreenSetups(bool videoScreenOn = false, bool imageScreenOn = false, bool vs1On = false, bool vs2On = false, bool vs3On = false, bool vs4On = false, bool vs5On = false, bool vs6On = false, bool vs7On = false, bool vs8On = false, bool vs9On = false, bool buttonStartExperimentOn = false, string topText = "")
    {
        if (videoPlayer != null) videoPlayer.Stop();
        if (audioSource != null) audioSource.Stop();
        videoScreen.enabled = videoScreenOn;
        imageScreen.enabled = imageScreenOn;

        vs1.enabled = vs1On;
        vs2.enabled = vs2On;
        vs3.enabled = vs3On;
        vs4.enabled = vs4On;
        vs5.enabled = vs5On;
        vs6.enabled = vs6On;
        vs7.enabled = vs7On;
        vs8.enabled = vs8On;
        vs9.enabled = vs9On;

        ButtonStartExperiment.gameObject.SetActive(buttonStartExperimentOn);
        TopText.text = topText;

        yield return null;
    }

    IEnumerator Sleep(float timeToWait)
    {
        float counter = 0;

        while (counter < timeToWait)
        {
            //Increment Timer until counter >= waitTime
            counter += Time.deltaTime;
            Debug.Log("You still have: " + Convert.ToString(timeToWait - counter) + " seconds");

            //Wait for a frame so that Unity doesn't freeze
            yield return null;
        }
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
