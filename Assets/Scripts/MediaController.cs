using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Linq;
using System.Data;
using Mono.Data.Sqlite;
using Assets.Scripts.Models;

public class MediaController : MonoBehaviour
{
    enum Sequence
    {
        Task,
        Rest,
        Image,
        Audio,
        Self,
        Manikin
    }

    public VideoClip videoClip;
    private VideoPlayer videoPlayer;
    public Renderer videoScreen;
    public RenderTexture videoMaterialTexture;

    public Material imageMaterial;
    public Renderer imageScreen;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public Button buttonStartExperiment;
    public Text topText;

    public Toggle m1;
    public Toggle m2;
    public Toggle m3;
    public Toggle m4;
    public Toggle m5;
    public Toggle m6;
    public Toggle m7;
    public Toggle m8;
    public Toggle m9;
    public Button buttonSubmitManikin;
    public ToggleGroup manikinGroup;

    Sequence sequence;
    int counter = 5;

    bool isFading;

    string connectionString;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScreenSetups(false, false, false, false, false, false, false, false, false, false, false, false, true, "Welcome! Please observe and get familiar with the room and hit the \"Start Experiment\" button when you feel ready."));

        connectionString = "URI=file:" + Application.dataPath + "/MT_Ruoyu.sqlite";
    }

    public void OnClickStartExperiment()
    {
        StartCoroutine(StartExperiment());
    }

    IEnumerator StartExperiment()
    {
        yield return new WaitForSeconds(.5f);

        yield return StartCoroutine(PlayVideo());
        yield return StartCoroutine(Sleep(5)); // Duration of the Video: 60s

        sequence = Sequence.Manikin;
        counter++;
        yield return StartCoroutine(Then());
    }

    public void OnClickButtonSubmitManikin()
    {
        var selectedToggle = manikinGroup.ActiveToggles().FirstOrDefault();

        if (selectedToggle)
        {
            Debug.Log("You chose: " + selectedToggle.name);

            manikinGroup.SetAllTogglesOff();

            StartCoroutine(Then());
        }
        else
        {
            StartCoroutine(ScreenSetups(false, false, true, true, true, true, true, true, true, true, true, true, false, "Please make sure you have selected one of the choices."));
        }
    }

    IEnumerator Then()
    {
        Debug.Log(counter);

        if (counter == 24) // A round of 4 elicitations is done
        {
            //todo
        }
        if (counter % 6 == 0 && counter != 0)
        {
            yield return StartCoroutine(ToNext());
        }

        switch (sequence)
        {
            case Sequence.Task:
                break;
            case Sequence.Rest:
                StartCoroutine(ToRest());
                break;
            case Sequence.Image:
                break;
            case Sequence.Audio:
                break;
            case Sequence.Self:
                break;
            case Sequence.Manikin:
                StartCoroutine(ToManikin());
                break;
            default:
                break;
        }

        yield return null;
    }

    IEnumerator ToRest()
    {
        yield return StartCoroutine(ScreenSetups(false, false, false, false, false, false, false, false, false, false, false, false, false, "Please take a rest until our next question."));

        yield return StartCoroutine(Sleep(5)); // 30s break
        sequence = Sequence.Manikin;
        counter++;

        yield return StartCoroutine(Then());
    }

    IEnumerator ToManikin()
    {
        sequence = Sequence.Rest;
        counter++;

        yield return StartCoroutine(ScreenSetups(false, false, true, true, true, true, true, true, true, true, true, true, false, "Please evaluate your current emotions, with bigger size you choose indicating stronger emotion. To proceed further, please click \"Subimit my Selection\" button after fulfilling the form."));
    }

    IEnumerator ToNext()
    {
        switch (counter / 6)
        {
            case 1:
                yield return StartCoroutine(PlayImage());
                yield return StartCoroutine(Sleep(5)); // 30s display time

                yield return StartCoroutine(ScreenSetups());

                sequence = Sequence.Manikin;
                counter++;
                Then();
                break;
            case 2:
                yield return StartCoroutine(PlayAudio());
                yield return StartCoroutine(Sleep(5)); // Duration of the Audio: 187s

                yield return StartCoroutine(ScreenSetups());

                sequence = Sequence.Manikin;
                counter++;
                Then();
                break;
            case 3:
                break;
            default:
                break;
        }
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

    IEnumerator ScreenSetups(bool videoScreenOn = false, bool imageScreenOn = false, bool m1On = false, bool m2On = false, bool m3On = false, bool m4On = false, bool m5On = false, bool m6On = false, bool m7On = false, bool m8On = false, bool m9On = false, bool buttonSubmitManikinOn = false, bool buttonStartExperimentOn = false, string topText = "")
    {
        if (videoPlayer != null) videoPlayer.Stop();
        if (audioSource != null) audioSource.Stop();
        videoScreen.enabled = videoScreenOn;
        imageScreen.enabled = imageScreenOn;

        m1.gameObject.SetActive(m1On);
        m2.gameObject.SetActive(m2On);
        m3.gameObject.SetActive(m3On);
        m4.gameObject.SetActive(m4On);
        m5.gameObject.SetActive(m5On);
        m6.gameObject.SetActive(m6On);
        m7.gameObject.SetActive(m7On);
        m8.gameObject.SetActive(m8On);
        m9.gameObject.SetActive(m9On);
        buttonSubmitManikin.gameObject.SetActive(buttonSubmitManikinOn);

        buttonStartExperiment.gameObject.SetActive(buttonStartExperimentOn);
        this.topText.text = topText;

        yield return null;
    }

    IEnumerator Sleep(float timeToWait)
    {
        float counter = 0;

        while (counter < timeToWait)
        {
            //Increment Timer until counter >= waitTime
            counter += Time.deltaTime;
            //Debug.Log("You still have: " + Convert.ToString(timeToWait - counter) + " seconds");

            //Wait for a frame so that Unity doesn't freeze
            yield return null;
        }
    }
}
