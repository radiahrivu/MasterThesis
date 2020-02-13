using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MediaController : MonoBehaviour
{
    enum NextStep
    {
        Video,
        AbR,
        Image,
        Audio,
        Task,
        Rest,
        Manikin
    }

    enum Emotion
    {
        Sad,
        Anger,
        Happy,
        Exciting
    }

    enum Method
    {
        Video,
        AbR,
        Image,
        Audio
    }

    int[,] sequence = new int[,] { { 0, 1, 2, 3 }, { 0, 1, 3, 2 }, { 0, 2, 1, 3 }, { 0, 2, 3, 1 }, { 0, 3, 1, 2 }, { 0, 3, 2, 1 }, { 1, 0, 2, 3 }, { 1, 0, 3, 2 }, { 1, 2, 0, 3 }, { 1, 2, 3, 0 }, { 1, 3, 0, 2 }, { 1, 3, 2, 0 }, { 2, 0, 1, 3 }, { 2, 0, 3, 1 }, { 2, 1, 0, 3 }, { 2, 1, 3, 0 }, { 2, 3, 1, 0 }, { 2, 3, 0, 1 }, { 3, 0, 1, 2 }, { 3, 0, 2, 1 }, { 3, 1, 0, 2 }, { 3, 1, 2, 0 }, { 3, 2, 0, 1 }, { 3, 2, 1, 0 } };

    int[,] pilotSequence = new int[,] { { 0, 1 }, { 1, 0 } };

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

    public Toggle a1;
    public Toggle a2;
    public Toggle a3;
    public Toggle a4;
    public Toggle a5;
    public Toggle a6;
    public Toggle a7;
    public Toggle a8;
    public Toggle a9;
    public ToggleGroup arousalGroup;

    public Toggle v1;
    public Toggle v2;
    public Toggle v3;
    public Toggle v4;
    public Toggle v5;
    public Toggle v6;
    public Toggle v7;
    public Toggle v8;
    public Toggle v9;
    public ToggleGroup valenceGroup;

    public Toggle d1;
    public Toggle d2;
    public Toggle d3;
    public Toggle d4;
    public Toggle d5;
    public Toggle d6;
    public Toggle d7;
    public Toggle d8;
    public Toggle d9;
    public ToggleGroup dominanceGroup;

    public Button buttonSubmitManikin;

    public Button buttonAbRNext;

    public GameObject avatar;

    NextStep nextStep;
    int counter = 0;
    int methodCounter = 0;

    string connString;
    int userId;

    ExperimentSetting setting;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScreenSetups(false, false, false, true, "Welcome! Please observe and get familiar with the room and hit the \"Start Experiment\" button when you feel ready."));

        connString = "URI=file:" + Application.dataPath + "/MT_Ruoyu.sqlite";

        userId = 1;

        setting = new ExperimentSetting();
        _ = setting.GetExperimentSettingByUserId(connString, userId);
    }

    public void OnClickStartExperiment()
    {
        counter = 0;
        StartCoroutine(StartExperiment(pilotSequence[setting.Sequence, methodCounter]));
    }

    IEnumerator StartExperiment(int firstStep)
    {
        nextStep = (NextStep)firstStep;

        //yield return new WaitForSeconds(.5f);
        StartCoroutine(Then());

        //yield return StartCoroutine(PlayVideo());
        //yield return StartCoroutine(Sleep(5)); // Duration of the Video: 60s

        //nextStep = NextStep.Manikin;
        //counter++;

        nextStep = NextStep.Manikin;
        yield return StartCoroutine(Then());
    }

    public void OnClickButtonSubmitManikin()
    {
        var selectedToggleArousal = arousalGroup.ActiveToggles().FirstOrDefault();
        var selectedToggleValence = valenceGroup.ActiveToggles().FirstOrDefault();
        var selectedToggleDominance = dominanceGroup.ActiveToggles().FirstOrDefault();

        if (selectedToggleArousal && selectedToggleValence && selectedToggleDominance)
        {
            var result = new ExperimentResult(userId, setting.ID, pilotSequence[setting.Sequence, methodCounter], int.Parse(selectedToggleArousal.name), int.Parse(selectedToggleValence.name), int.Parse(selectedToggleDominance.name), counter);

            result.InsertResult(connString);

            valenceGroup.SetAllTogglesOff();

            counter++;

            StartCoroutine(Then());
        }
        else
        {
            StartCoroutine(ScreenSetups(false, false, true, false, "Please make sure you have selected one of the choices."));
        }
    }

    public void OnClickButtonAbRNext()
    {
        counter++;

        StartCoroutine(Then());
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

        counter++;
    }

    IEnumerator PlayImage()
    {
        yield return StartCoroutine(ScreenSetups(false, true));

        counter++;

        yield return null;
    }

    IEnumerator PlayAudio()
    {
        yield return StartCoroutine(ScreenSetups());

        audioSource.clip = audioClip;
        audioSource.Play(0);

        counter++;

        yield return null;
    }

    IEnumerator Then()
    {
        Debug.Log(counter);

        if (counter == 24) // A round of 4 elicitations is done
        {
            //todo
        }
        //if (counter % 6 == 0 && counter != 0)
        //{
        //    yield return StartCoroutine(ToNext());
        //}

        switch (nextStep)
        {
            case NextStep.Video:
                StartCoroutine(PlayVideo());
                StartCoroutine(Sleep(5)); // Duration of the Video: 60s
                break;
            case NextStep.Task:
                break;
            case NextStep.Rest:
                StartCoroutine(ToRest());
                break;
            case NextStep.Image:
                yield return StartCoroutine(PlayImage());
                yield return StartCoroutine(Sleep(60)); // 60s display time

                yield return StartCoroutine(ScreenSetups());

                nextStep = NextStep.Manikin;
                Then();
                break;
            case NextStep.Audio:
                yield return StartCoroutine(PlayAudio());
                yield return StartCoroutine(Sleep(187)); // Duration of the Audio: 187s

                yield return StartCoroutine(ScreenSetups());

                nextStep = NextStep.Manikin;
                Then();
                break;
            case NextStep.AbR:
                StartCoroutine(ToAbR());
                break;
            case NextStep.Manikin:
                StartCoroutine(ToManikin());
                break;
            default:
                break;
        }

        yield return null;
    }

    //IEnumerator ToNext()
    //{
    //    switch (counter / 6)
    //    {
    //        case 1:
    //            yield return StartCoroutine(PlayImage());
    //            yield return StartCoroutine(Sleep(5)); // 30s display time

    //            yield return StartCoroutine(ScreenSetups());

    //            nextStep = NextStep.Manikin;
    //            counter++;
    //            Then();
    //            break;
    //        case 2:
    //            yield return StartCoroutine(PlayAudio());
    //            yield return StartCoroutine(Sleep(5)); // Duration of the Audio: 187s

    //            yield return StartCoroutine(ScreenSetups());

    //            nextStep = NextStep.Manikin;
    //            counter++;
    //            Then();
    //            break;
    //        case 3:
    //            break;
    //        default:
    //            break;
    //    }
    //}

    IEnumerator ToRest()
    {
        switch (counter) // Reach end of each REST round, then entering into the next phase
        {
            case 5:
                methodCounter++;
                nextStep = (NextStep)pilotSequence[setting.Sequence, methodCounter];
                StartCoroutine(Then());
                break;
            case 11:
                // Finish the pilot experiment
                StartCoroutine(Finish());

                //methodCounter++;
                //nextStep = (NextStep)pilotSequence[setting.Sequence, methodCounter];
                //StartCoroutine(Then());
                break;
            case 17:
                methodCounter++;
                nextStep = (NextStep)pilotSequence[setting.Sequence, methodCounter];
                StartCoroutine(Then());
                break;
            case 23:
                // Finish the experiment
                StartCoroutine(Finish());
                break;
            default:
                break;
        }

        yield return StartCoroutine(ScreenSetups(false, false, false, false, "Please take a rest until our next question."));

        yield return StartCoroutine(Sleep(30)); // 30s break
        nextStep = NextStep.Manikin;

        yield return StartCoroutine(Then());
    }

    IEnumerator ToManikin()
    {
        nextStep = NextStep.Rest;

        yield return StartCoroutine(ScreenSetups(false, false, true, false, "Please evaluate your current emotions, with bigger size you choose indicating stronger emotion. To proceed further, please click \"Subimit my Selection\" button after fulfilling the form."));
    }

    IEnumerator ToAbR()
    {
        nextStep = NextStep.Rest;

        yield return StartCoroutine(ScreenSetups(false, false, false, false, "Please think of the " + (Emotion)setting.Emotion + " memory as we informed earlier, then you can share the memory or your feeling to the avatar next to you. What you said will not be listened or recorded by any party. Once you are done, please click the \"Next Step\" button which will appear in 2 minutes.", true));
    }

    IEnumerator Finish()
    {
        yield return StartCoroutine(ScreenSetups(false, false, false, false, "Thank you for participating our experiment, now you may remove the VR headset and let the experimenter know it is all finished."));
    }

    IEnumerator ScreenSetups(bool videoScreenOn = false, bool imageScreenOn = false, bool manikin = false, bool buttonStartExperimentOn = false, string topText = "", bool avatar = false)
    {
        if (videoPlayer != null) videoPlayer.Stop();
        if (audioSource != null) audioSource.Stop();
        videoScreen.enabled = videoScreenOn;
        imageScreen.enabled = imageScreenOn;

        ManikinSetups(manikin);

        buttonStartExperiment.gameObject.SetActive(buttonStartExperimentOn);
        this.topText.text = topText;

        this.avatar.SetActive(avatar);

        yield return null;
    }

    IEnumerator ManikinSetups(bool manikin)
    {
        a1.gameObject.SetActive(manikin);
        a2.gameObject.SetActive(manikin);
        a3.gameObject.SetActive(manikin);
        a4.gameObject.SetActive(manikin);
        a5.gameObject.SetActive(manikin);
        a6.gameObject.SetActive(manikin);
        a7.gameObject.SetActive(manikin);
        a8.gameObject.SetActive(manikin);
        a9.gameObject.SetActive(manikin);

        v1.gameObject.SetActive(manikin);
        v2.gameObject.SetActive(manikin);
        v3.gameObject.SetActive(manikin);
        v4.gameObject.SetActive(manikin);
        v5.gameObject.SetActive(manikin);
        v6.gameObject.SetActive(manikin);
        v7.gameObject.SetActive(manikin);
        v8.gameObject.SetActive(manikin);
        v9.gameObject.SetActive(manikin);

        d1.gameObject.SetActive(manikin);
        d2.gameObject.SetActive(manikin);
        d3.gameObject.SetActive(manikin);
        d4.gameObject.SetActive(manikin);
        d5.gameObject.SetActive(manikin);
        d6.gameObject.SetActive(manikin);
        d7.gameObject.SetActive(manikin);
        d8.gameObject.SetActive(manikin);
        d9.gameObject.SetActive(manikin);

        buttonSubmitManikin.gameObject.SetActive(manikin);

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
