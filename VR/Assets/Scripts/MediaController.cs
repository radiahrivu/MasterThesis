using Assets.Scripts.Helpers;
using Assets.Scripts.Models;
using System.Collections;
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
        Rest,
        Manikin,
        Finish
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

    // 0=Sv	1=Aa 2=Hi 3=Er 4=Ar 5=Hv 6=Ea 7=Si 8=Ha 9=Ei 10=Sr 11=Av 12=Ei 13=Sr 14=Av 15=Ha
    readonly int[,] sequences = new int[,] { { 0, 1, 2, 3 }, { 4, 5, 6, 7 }, { 8, 9, 10, 11 }, { 12, 13, 14, 15 }, { 0, 4, 8, 12 }, { 1, 5, 9, 13 }, { 2, 6, 10, 14 }, { 3, 7, 11, 15 }, { 3, 2, 1, 0 }, { 7, 6, 5, 4 }, { 11, 10, 9, 8 }, { 15, 14, 13, 12 }, { 12, 8, 4, 0 }, { 13, 9, 5, 1 }, { 14, 10, 6, 2 }, { 15, 11, 7, 3 } };

    public VideoClip videoClipHappy1;
    public VideoClip videoClipHappy2;

    public VideoClip videoClipAngry1;
    public VideoClip videoClipAngry2;

    public VideoClip videoClipExciting1;
    public VideoClip videoClipExciting2;

    public VideoClip videoClipSad1;
    public VideoClip videoClipSad2;

    private VideoPlayer videoPlayer;
    public Renderer videoScreen;
    public RenderTexture videoMaterialTexture;

    public Material imageAngry1;
    public Material imageAngry2;
    public Material imageSad1;
    public Material imageSad2;
    public Material imageHappy1;
    public Material imageHappy2;
    public Material imageExciting1;
    public Material imageExciting2;

    public Renderer imageScreen;

    public AudioSource audioSource;
    public AudioClip audioAngry1;
    public AudioClip audioAngry2;
    public AudioClip audioSad1;
    public AudioClip audioSad2;
    public AudioClip audioHappy1;
    public AudioClip audioHappy2;
    public AudioClip audioExciting1;
    public AudioClip audioExciting2;

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
    Emotion emotion;
    Method method;
    int counter = 0;
    int methodCounter = 0;
    int finishCounter = 0;

    string connString;
    int userId;

    ExperimentSetting setting;

    public Text finishText;

    public Toggle sus1;
    public Toggle sus2;
    public Toggle sus3;
    public Toggle sus4;
    public Toggle sus5;
    public Toggle sus6;
    public Toggle sus7;
    public ToggleGroup susGroup;
    public Text labelLeft;
    public Text labelRight;
    public Button buttonSUS;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScreenSetups(false, false, false, true, MainScreenSetup.StartingText()));

        // to change
        connString = "URI=file:" + Application.dataPath + "/DB/Production.sqlite";
        //connString = "URI=file:" + Application.dataPath + "/DB/Test.sqlite";

        // to change
        userId = 19;

        setting = new ExperimentSetting();
        setting = setting.GetExperimentSettingByUserId(connString, userId);
    }

    public void OnClickStartExperiment()
    {
        counter = 0;
        StartCoroutine(SetNextStep());
        StartCoroutine(Then());
    }

    public void OnClickButtonSubmitManikin()
    {
        var selectedToggleArousal = arousalGroup.ActiveToggles().FirstOrDefault();
        var selectedToggleValence = valenceGroup.ActiveToggles().FirstOrDefault();
        var selectedToggleDominance = dominanceGroup.ActiveToggles().FirstOrDefault();

        if (selectedToggleArousal && selectedToggleValence && selectedToggleDominance)
        {

            Debug.Log(selectedToggleArousal.name);
            Debug.Log(selectedToggleValence.name);
            Debug.Log(selectedToggleDominance.name);

            var result = new ExperimentResult(userId, setting.ID, (int)method, int.Parse(selectedToggleArousal.name), int.Parse(selectedToggleValence.name), int.Parse(selectedToggleDominance.name), counter, (int)emotion);

            switch (method)
            {
                case Method.Video:
                    result.Clip = setting.VideoClip;
                    break;
                case Method.Audio:
                    result.Clip = setting.AudioClip;
                    break;
                case Method.AbR:
                    result.Clip = 0;
                    break;
                case Method.Image:
                    result.Clip = setting.ImageClip;
                    break;
                default:
                    break;
            }

            result.InsertResult(connString);

            arousalGroup.SetAllTogglesOff();
            valenceGroup.SetAllTogglesOff();
            dominanceGroup.SetAllTogglesOff();

            counter++;

            StartCoroutine(Then());
        }
        else
        {
            StartCoroutine(ScreenSetups(false, false, true, false, MainScreenSetup.ManikinErrorText()));
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

        switch (emotion)
        {
            case Emotion.Anger:
                if (setting.VideoClip == 1)
                {
                    videoPlayer.clip = videoClipAngry1;
                }
                else if (setting.VideoClip == 2)
                {
                    videoPlayer.clip = videoClipAngry2;
                }
                break;
            case Emotion.Exciting:
                if (setting.VideoClip == 1)
                {
                    videoPlayer.clip = videoClipExciting1;
                }
                else if (setting.VideoClip == 2)
                {
                    videoPlayer.clip = videoClipExciting2;
                }
                break;
            case Emotion.Happy:
                if (setting.VideoClip == 1)
                {
                    videoPlayer.clip = videoClipHappy1;
                }
                else if (setting.VideoClip == 2)
                {
                    videoPlayer.clip = videoClipHappy2;
                }
                break;
            case Emotion.Sad:
                if (setting.VideoClip == 1)
                {
                    videoPlayer.clip = videoClipSad1;
                }
                else if (setting.VideoClip == 2)
                {
                    videoPlayer.clip = videoClipSad2;
                }
                break;
            default:
                break;
        }

        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = videoMaterialTexture;
        videoPlayer.targetMaterialRenderer = videoScreen;
        videoPlayer.targetMaterialProperty = "_MainTex";
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);

        videoPlayer.Play();

        counter++;

        switch (emotion)
        {
            case Emotion.Anger:
                if (setting.VideoClip == 1)
                {
                    yield return StartCoroutine(Sleep(183));
                }
                else if (setting.VideoClip == 2)
                {
                    yield return StartCoroutine(Sleep(224));
                }
                break;
            case Emotion.Exciting:
                if (setting.VideoClip == 1)
                {
                    yield return StartCoroutine(Sleep(165));
                }
                else if (setting.VideoClip == 2)
                {
                    yield return StartCoroutine(Sleep(258));
                }
                break;
            case Emotion.Happy:
                if (setting.VideoClip == 1)
                {
                    yield return StartCoroutine(Sleep(221));
                }
                else if (setting.VideoClip == 2)
                {
                    yield return StartCoroutine(Sleep(248));
                }
                break;
            case Emotion.Sad:
                if (setting.VideoClip == 1)
                {
                    yield return StartCoroutine(Sleep(237));
                }
                else if (setting.VideoClip == 2)
                {
                    yield return StartCoroutine(Sleep(200));
                }
                break;
            default:
                break;
        }

        yield return StartCoroutine(ScreenSetups());

        nextStep = NextStep.Manikin;
        yield return StartCoroutine(Then());
    }

    IEnumerator PlayImage()
    {
        switch (emotion)
        {
            case Emotion.Anger:
                if (setting.VideoClip == 1)
                {
                    imageScreen.material = imageAngry1;
                }
                else if (setting.VideoClip == 2)
                {
                    imageScreen.material = imageAngry2;
                }
                break;
            case Emotion.Exciting:
                if (setting.VideoClip == 1)
                {
                    imageScreen.material = imageExciting1;
                }
                else if (setting.VideoClip == 2)
                {
                    imageScreen.material = imageExciting2;
                }
                break;
            case Emotion.Happy:
                if (setting.VideoClip == 1)
                {
                    imageScreen.material = imageHappy1;
                }
                else if (setting.VideoClip == 2)
                {
                    imageScreen.material = imageHappy2;
                }
                break;
            case Emotion.Sad:
                if (setting.VideoClip == 1)
                {
                    imageScreen.material = imageSad1;
                }
                else if (setting.VideoClip == 2)
                {
                    imageScreen.material = imageSad2;
                }
                break;
            default:
                break;
        }

        yield return StartCoroutine(ScreenSetups(false, true));

        counter++;

        yield return null;
    }

    IEnumerator PlayAudio()
    {
        yield return StartCoroutine(ScreenSetups());

        switch (emotion)
        {
            case Emotion.Anger:
                if (setting.VideoClip == 1)
                {
                    audioSource.clip = audioAngry1;
                }
                else if (setting.VideoClip == 2)
                {
                    audioSource.clip = audioAngry2;
                }
                break;
            case Emotion.Exciting:
                if (setting.VideoClip == 1)
                {
                    audioSource.clip = audioExciting1;
                }
                else if (setting.VideoClip == 2)
                {
                    audioSource.clip = audioExciting2;
                }
                break;
            case Emotion.Happy:
                if (setting.VideoClip == 1)
                {
                    audioSource.clip = audioHappy1;
                }
                else if (setting.VideoClip == 2)
                {
                    audioSource.clip = audioHappy2;
                }
                break;
            case Emotion.Sad:
                if (setting.VideoClip == 1)
                {
                    audioSource.clip = audioSad1;
                }
                else if (setting.VideoClip == 2)
                {
                    audioSource.clip = audioSad2;
                }
                break;
            default:
                break;
        }
        audioSource.Play(0);

        counter++;

        yield return null;
    }

    IEnumerator Then()
    {
        Debug.Log(counter);

        switch (counter) // Reach end of each REST round, then entering into the next phase
        {
            case 10:
                methodCounter++;
                StartCoroutine(SetNextStep());
                break;
            case 20:
                // Finish the pilot experiment
                //nextStep = NextStep.Finish;

                methodCounter++;
                StartCoroutine(SetNextStep());
                break;
            case 30:
                methodCounter++;
                StartCoroutine(SetNextStep());
                break;
            case 40:
                // Finish the experiment
                nextStep = NextStep.Finish;
                break;
            default:
                break;
        }

        Debug.Log("-----------------------: " + nextStep);

        switch (nextStep)
        {
            case NextStep.Video:
                yield return StartCoroutine(PlayVideo());
                break;
            case NextStep.Rest:
                yield return StartCoroutine(ScreenSetups(false, false, false, false, MainScreenSetup.RestText()));

                yield return StartCoroutine(Sleep(30)); // 30s break

                nextStep = NextStep.Manikin;
                counter++;
                yield return StartCoroutine(Then());
                break;
            case NextStep.Image:
                yield return StartCoroutine(PlayImage());
                yield return StartCoroutine(Sleep(20)); // 20s display time

                yield return StartCoroutine(ScreenSetups());

                nextStep = NextStep.Manikin;
                yield return StartCoroutine(Then());
                break;
            case NextStep.Audio:
                yield return StartCoroutine(ScreenSetups(false, false, false, false, MainScreenSetup.AudioText()));
                yield return StartCoroutine(PlayAudio());
                yield return StartCoroutine(Sleep(5)); // Duration of the Audio: 5s

                yield return StartCoroutine(ScreenSetups());

                nextStep = NextStep.Manikin;
                yield return StartCoroutine(Then());
                break;
            case NextStep.AbR:
                nextStep = NextStep.Manikin;

                yield return StartCoroutine(ScreenSetups(false, false, false, false, MainScreenSetup.AbRText(emotion.ToString())));

                yield return StartCoroutine(Sleep(120));

                yield return StartCoroutine(ScreenSetups(false, false, false, false, MainScreenSetup.AbRText(emotion.ToString()), false, true));
                break;
            case NextStep.Manikin:
                nextStep = NextStep.Rest;

                yield return StartCoroutine(ScreenSetups(false, false, true, false, MainScreenSetup.ManikinText()));
                break;
            case NextStep.Finish:
                finishCounter = 0;
                yield return StartCoroutine(Finish());
                break;
            default:
                break;
        }

        yield return null;
    }

    IEnumerator Finish()
    {
        switch (finishCounter)
        {
            case 0:
                StartCoroutine(ScreenSetups(false, false, false, false, "Please rate your sense of being in this office space, on the following scale from 1 to 7, where 7 represents your normal experience of being in a place. \r\n\r\nI had a sense of “being there” in this office space:", false, false, false, true, "Not at all", "Very much"));
                //LabelLeft.Text = "Not at all";
                //LabelRight.Text = "Very much";
                break;
            case 1:
                StartCoroutine(ScreenSetups(false, false, false, false, "To what extent were there times during the experience when this office space was the reality for you? \r\n\r\nThere were times during the experience when this office space was the reality for me... ", false, false, false, true, "At no time", "Almost all the time"));
                //LabelLeft.Text = "At no time";
                //LabelRight.Text = "Almost all the time";
                break;
            case 2:
                StartCoroutine(ScreenSetups(false, false, false, false, "When you think back about your experience, do you think of this office space more as images that you saw, or more as somewhere that you visited? \r\n\r\nThis office space seems to me to be more like...", false, false, false, true, "Images that I saw", "Somewhere that I visited"));
                //LabelLeft.Text = "Images that I saw";
                //LabelRight.Text = "Somewhere that I visited";
                break;
            case 3:
                StartCoroutine(ScreenSetups(false, false, false, false, "During the time of the experience, which was strongest on the whole, your sense of being in this office space, or of being elsewhere? \r\n\r\nI had a stronger sense of...", false, false, false, true, "Being elsewhere", "Being in this office space"));
                //LabelLeft.Text = "Being elsewhere";
                //LabelRight.Text = "Being in this office space";
                break;
            case 4:
                StartCoroutine(ScreenSetups(false, false, false, false, "Consider your memory of being in this office space. How similar in terms of the structure of the memory is this to the structure of the memory of other places you have been today? By ‘structure of the memory’ consider things like the extent to which you have a visual memory of the office space, whether that memory is in color, the extent to which the memory seems vivid or realistic, its size, location in your imagination, the extent to which it is panoramic in your imagination, and other such structural elements. \r\n\r\nI think of this office space as a place in a way similar to other places that I've been today...", false, false, false, true, "Not at all", "Very much so"));
                //LabelLeft.Text = "Not at all";
                //LabelRight.Text = "Very much so";
                break;
            case 5:
                StartCoroutine(ScreenSetups(false, false, false, false, "During the time of the experience, did you often think to yourself that you were actually in this office space? \r\n\r\nDuring the experience I often thought that I was really sitting in this office space...", false, false, false, true, "Not very often", "Very much so"));
                //LabelLeft.Text = "Not very often";
                //LabelRight.Text = "Very much so";
                break;
            default:
                break;
        }

        yield return null;
    }

    public void OnClickButtonSUS()
    {
        var selectedToggleSUS = susGroup.ActiveToggles().FirstOrDefault();

        if (selectedToggleSUS)
        {
            Debug.Log(selectedToggleSUS.name);

            var sus = new SUS(setting.ID, finishCounter, int.Parse(selectedToggleSUS.name));
            sus.InsertResult(connString);
            susGroup.SetAllTogglesOff();
            finishCounter++;
            StartCoroutine(Finish());
        }

        if (finishCounter == 6)
        {
            StartCoroutine(ScreenSetups(false, false, false, false, "", false, false, true));
        }
    }

    IEnumerator ScreenSetups(bool videoScreenOn = false, bool imageScreenOn = false, bool manikinOn = false, bool buttonStartExperimentOn = false, string topText = "", bool avatar = false, bool buttonAbRNextOn = false, bool finishTextOn = false, bool susOn = false, string labelLeft = "", string labelRight = "")
    {
        if (videoPlayer != null) videoPlayer.Stop();
        if (audioSource != null) audioSource.Stop();
        videoScreen.enabled = videoScreenOn;
        imageScreen.enabled = imageScreenOn;

        StartCoroutine(ManikinSetups(manikinOn));

        buttonStartExperiment.gameObject.SetActive(buttonStartExperimentOn);
        this.topText.text = topText;

        this.avatar.SetActive(false);

        buttonAbRNext.gameObject.SetActive(buttonAbRNextOn);

        this.finishText.gameObject.SetActive(finishTextOn);

        StartCoroutine(SUSSetups(susOn, labelLeft, labelRight));

        yield return null;
    }

    IEnumerator ManikinSetups(bool manikinOn)
    {
        v1.gameObject.SetActive(manikinOn);
        v2.gameObject.SetActive(manikinOn);
        v3.gameObject.SetActive(manikinOn);
        v4.gameObject.SetActive(manikinOn);
        v5.gameObject.SetActive(manikinOn);
        v6.gameObject.SetActive(manikinOn);
        v7.gameObject.SetActive(manikinOn);
        v8.gameObject.SetActive(manikinOn);
        v9.gameObject.SetActive(manikinOn);

        a1.gameObject.SetActive(manikinOn);
        a2.gameObject.SetActive(manikinOn);
        a3.gameObject.SetActive(manikinOn);
        a4.gameObject.SetActive(manikinOn);
        a5.gameObject.SetActive(manikinOn);
        a6.gameObject.SetActive(manikinOn);
        a7.gameObject.SetActive(manikinOn);
        a8.gameObject.SetActive(manikinOn);
        a9.gameObject.SetActive(manikinOn);

        d1.gameObject.SetActive(manikinOn);
        d2.gameObject.SetActive(manikinOn);
        d3.gameObject.SetActive(manikinOn);
        d4.gameObject.SetActive(manikinOn);
        d5.gameObject.SetActive(manikinOn);
        d6.gameObject.SetActive(manikinOn);
        d7.gameObject.SetActive(manikinOn);
        d8.gameObject.SetActive(manikinOn);
        d9.gameObject.SetActive(manikinOn);

        buttonSubmitManikin.gameObject.SetActive(manikinOn);

        yield return null;
    }

    IEnumerator SUSSetups(bool susOn, string labelLeft, string labelRight)
    {
        sus1.gameObject.SetActive(susOn);
        sus2.gameObject.SetActive(susOn);
        sus3.gameObject.SetActive(susOn);
        sus4.gameObject.SetActive(susOn);
        sus5.gameObject.SetActive(susOn);
        sus6.gameObject.SetActive(susOn);
        sus7.gameObject.SetActive(susOn);

        buttonSUS.gameObject.SetActive(susOn);

        this.labelLeft.text = labelLeft;
        this.labelRight.text = labelRight;

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

    IEnumerator SetNextStep()
    {

        switch (sequences[setting.Sequence, methodCounter])
        {
            case 0:
                emotion = Emotion.Sad;
                nextStep = NextStep.Video;
                method = Method.Video;
                break;
            case 1:
                emotion = Emotion.Anger;
                nextStep = NextStep.Audio;
                method = Method.Audio;
                break;
            case 2:
                emotion = Emotion.Happy;
                nextStep = NextStep.Image;
                method = Method.Image;
                break;
            case 3:
                emotion = Emotion.Exciting;
                nextStep = NextStep.AbR;
                method = Method.AbR;
                break;
            case 4:
                emotion = Emotion.Anger;
                nextStep = NextStep.AbR;
                method = Method.AbR;
                break;
            case 5:
                emotion = Emotion.Happy;
                nextStep = NextStep.Video;
                method = Method.Video;
                break;
            case 6:
                emotion = Emotion.Exciting;
                nextStep = NextStep.Audio;
                method = Method.Audio;
                break;
            case 7:
                emotion = Emotion.Sad;
                nextStep = NextStep.Image;
                method = Method.Image;
                break;
            case 8:
                emotion = Emotion.Happy;
                nextStep = NextStep.Audio;
                method = Method.Audio;
                break;
            case 9:
                emotion = Emotion.Exciting;
                nextStep = NextStep.Image;
                method = Method.Image;
                break;
            case 10:
                emotion = Emotion.Sad;
                nextStep = NextStep.AbR;
                method = Method.AbR;
                break;
            case 11:
                emotion = Emotion.Anger;
                nextStep = NextStep.Video;
                method = Method.Video;
                break;
            case 12:
                emotion = Emotion.Exciting;
                nextStep = NextStep.Image;
                method = Method.Image;
                break;
            case 13:
                emotion = Emotion.Sad;
                nextStep = NextStep.AbR;
                method = Method.AbR;
                break;
            case 14:
                emotion = Emotion.Anger;
                nextStep = NextStep.Video;
                method = Method.Video;
                break;
            case 15:
                emotion = Emotion.Happy;
                nextStep = NextStep.Audio;
                method = Method.Audio;
                break;
            default:
                break;
        }
        yield return null;
    }
}
