using RealWorld.Helpers;
using RealWorld.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealWorld
{
    public partial class MainForm : Form
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

        string connString;
        int userId;

        ExperimentSetting setting;

        NextStep nextStep;
        Emotion emotion;
        Method method;
        int counter = 0;
        int methodCounter = 0;
        int finishCounter = 0;

        /* Env on lab desktop */
        //private string baseUri = @"C:\Projects\Ruoyu MT\MasterThesis\VR\Assets\";

        /* Env on Ruoyu's Laptop */
        private string baseUri = @"C:\Ruoyu\MasterThesis\VR\Assets\";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ScreenSetups(false, false, false, true, MainScreenSetup.StartingText());
            // to change

            /* Test Env on Ruoyu's Laptop */
            //connString = "URI=file:C:/Ruoyu/MasterThesis/VR/Assets/DB" + "/Test.sqlite";

            /* Production Env on Ruoyu's Laptop */
            connString = "URI=file:C:/Ruoyu/MasterThesis/VR/Assets/DB" + "/Production.sqlite";

            /* Production Env on lab desktop */
            //connString = "URI=file:C:/Projects/Ruoyu MT/MasterThesis/VR/Assets/DB" + "/Production.sqlite";

            // to change
            userId = 34;

            setting = new ExperimentSetting();
            setting = setting.GetExperimentSettingByUserId(connString, userId);
        }

        private void ButtonStartExperiment_Click(object sender, EventArgs e)
        {
            counter = 0;
            SetNextStep();
            Then();
        }

        private void ButtonSubmitManikin_Click(object sender, EventArgs e)
        {
            var result = new ExperimentResult(userId, setting.ID, (int)method, 0, 0, 0, counter, (int)emotion);

            var radios = new List<RadioButton>();

            foreach (var control in valenceGroup.Controls)
            {
                if (control is RadioButton radio && radio.Checked)
                {
                    result.ValenceScale = int.Parse(radio.Text);
                    radios.Add(radio);
                }
            }

            foreach (var control in arousalGroup.Controls)
            {
                if (control is RadioButton radio && radio.Checked)
                {
                    result.ArousalScale = int.Parse(radio.Text);
                    radios.Add(radio);
                }
            }

            foreach (var control in dominanceGroup.Controls)
            {
                if (control is RadioButton radio && radio.Checked)
                {
                    result.DominanceScale = int.Parse(radio.Text);
                    radios.Add(radio);
                }
            }

            if (radios.Count != 3)
            {
                ScreenSetups(false, false, true, false, MainScreenSetup.ManikinErrorText());
                return;
            }

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

            foreach (var radio in radios)
            {
                radio.Checked = false;
            }

            nextStep = NextStep.Rest;
            counter++;
            Then();
        }

        private void ButtonAbRNext_Click(object sender, EventArgs e)
        {
            counter++;
            Then();
        }

        void PlayVideo()
        {
            var path = baseUri + @"Videos\";

            switch (emotion)
            {
                case Emotion.Anger:
                    if (setting.VideoClip == 1)
                    {
                        VideoPlayer.URL = path + "angry1";
                    }
                    else if (setting.VideoClip == 2)
                    {
                        VideoPlayer.URL = path + "angry2";
                    }
                    break;
                case Emotion.Exciting:
                    if (setting.VideoClip == 1)
                    {
                        VideoPlayer.URL = path + "exciting1";
                    }
                    else if (setting.VideoClip == 2)
                    {
                        VideoPlayer.URL = path + "exciting2";
                    }
                    break;
                case Emotion.Happy:
                    if (setting.VideoClip == 1)
                    {
                        VideoPlayer.URL = path + "happy1";
                    }
                    else if (setting.VideoClip == 2)
                    {
                        VideoPlayer.URL = path + "happy2";
                    }
                    break;
                case Emotion.Sad:
                    if (setting.VideoClip == 1)
                    {
                        VideoPlayer.URL = path + "sad1";
                    }
                    else if (setting.VideoClip == 2)
                    {
                        VideoPlayer.URL = path + "sad2";
                    }
                    break;
                default:
                    break;
            }

            VideoPlayer.URL += ".mp4";
            VideoPlayer.Ctlcontrols.play();
            counter++;
        }

        void PlayImage()
        {
            var path = baseUri + @"Images\";

            switch (emotion)
            {
                case Emotion.Anger:
                    if (setting.VideoClip == 1)
                    {
                        imageBox.Image = Image.FromFile(path + "angry1.bmp");
                    }
                    else if (setting.VideoClip == 2)
                    {
                        imageBox.Image = Image.FromFile(path + "angry2.bmp");
                    }
                    break;
                case Emotion.Exciting:
                    if (setting.VideoClip == 1)
                    {
                        imageBox.Image = Image.FromFile(path + "exciting1.bmp");
                    }
                    else if (setting.VideoClip == 2)
                    {
                        imageBox.Image = Image.FromFile(path + "exciting2.bmp");
                    }
                    break;
                case Emotion.Happy:
                    if (setting.VideoClip == 1)
                    {
                        imageBox.Image = Image.FromFile(path + "happy1.bmp");
                    }
                    else if (setting.VideoClip == 2)
                    {
                        imageBox.Image = Image.FromFile(path + "happy2.bmp");
                    }
                    break;
                case Emotion.Sad:
                    if (setting.VideoClip == 1)
                    {
                        imageBox.Image = Image.FromFile(path + "sad1.bmp");
                    }
                    else if (setting.VideoClip == 2)
                    {
                        imageBox.Image = Image.FromFile(path + "sad2.bmp");
                    }
                    break;
                default:
                    break;
            }
        }

        void PlayAudio()
        {
            var path = baseUri + @"Audios\";

            var player = new SoundPlayer();

            switch (emotion)
            {
                case Emotion.Anger:
                    if (setting.VideoClip == 1)
                    {
                        player.SoundLocation = path + "angry1.wav";
                    }
                    else if (setting.VideoClip == 2)
                    {
                        player.SoundLocation = path + "angry2.wav";
                    }
                    break;
                case Emotion.Exciting:
                    if (setting.VideoClip == 1)
                    {
                        player.SoundLocation = path + "exciting1.wav";
                    }
                    else if (setting.VideoClip == 2)
                    {
                        player.SoundLocation = path + "exciting2.wav";
                    }
                    break;
                case Emotion.Happy:
                    if (setting.VideoClip == 1)
                    {
                        player.SoundLocation = path + "happy1.wav";
                    }
                    else if (setting.VideoClip == 2)
                    {
                        player.SoundLocation = path + "happy2.wav";
                    }
                    break;
                case Emotion.Sad:
                    if (setting.VideoClip == 1)
                    {
                        player.SoundLocation = path + "sad1.wav";
                    }
                    else if (setting.VideoClip == 2)
                    {
                        player.SoundLocation = path + "sad2.wav";
                    }
                    break;
                default:
                    break;
            }
            player.Play();
        }

        void Finish()
        {
            switch (finishCounter)
            {
                case 0:
                    ScreenSetups(false, false, false, false, "Please rate your sense of being in this office space, on the following scale from 1 to 7, where 7 represents your normal experience of being in a place. \r\n\r\nI had a sense of “being there” in this office space:", false, false, false, true);
                    LabelLeft.Text = "Not at all";
                    LabelRight.Text = "Very much";
                    break;
                case 1:
                    ScreenSetups(false, false, false, false, "To what extent were there times during the experience when this office space was the reality for you? \r\n\r\nThere were times during the experience when this office space was the reality for me... ", false, false, false, true);
                    LabelLeft.Text = "At no time";
                    LabelRight.Text = "Almost all the time";
                    break;
                case 2:
                    ScreenSetups(false, false, false, false, "When you think back about your experience, do you think of this office space more as images that you saw, or more as somewhere that you visited? \r\n\r\nThis office space seems to me to be more like...", false, false, false, true);
                    LabelLeft.Text = "Images that I saw";
                    LabelRight.Text = "Somewhere that I visited";
                    break;
                case 3:
                    ScreenSetups(false, false, false, false, "During the time of the experience, which was strongest on the whole, your sense of being in this office space, or of being elsewhere? \r\n\r\nI had a stronger sense of...", false, false, false, true);
                    LabelLeft.Text = "Being elsewhere";
                    LabelRight.Text = "Being in this office space";
                    break;
                case 4:
                    ScreenSetups(false, false, false, false, "Consider your memory of being in this office space. How similar in terms of the structure of the memory is this to the structure of the memory of other places you have been today? By ‘structure of the memory’ consider things like the extent to which you have a visual memory of the office space, whether that memory is in color, the extent to which the memory seems vivid or realistic, its size, location in your imagination, the extent to which it is panoramic in your imagination, and other such structural elements. \r\n\r\nI think of this office space as a place in a way similar to other places that I've been today...", false, false, false, true);
                    LabelLeft.Text = "Not at all";
                    LabelRight.Text = "Very much so";
                    break;
                case 5:
                    ScreenSetups(false, false, false, false, "During the time of the experience, did you often think to yourself that you were actually in this office space? \r\n\r\nDuring the experience I often thought that I was really sitting in this office space...", false, false, false, true);
                    LabelLeft.Text = "Not very often";
                    LabelRight.Text = "Very much so";
                    break;
                default:
                    break;
            }
        }

        private void ButtonSUS_Click(object sender, EventArgs e)
        {
            var r = new RadioButton();
            var c = false;

            foreach (var control in PanelSUS.Controls)
            {
                if (control is RadioButton radio && radio.Checked)
                {
                    r = radio;
                    c = true;
                    var sus = new SUS(setting.ID, finishCounter, int.Parse(radio.Text));
                    sus.InsertResult(connString);
                }
            }
            if (!c)
            {
                return;
            }
            r.Checked = false;
            finishCounter++;
            Finish();

            if (finishCounter == 6)
            {
                ScreenSetups(false, false, false, false, "", false, false, true);
            }
        }

        async void Then()
        {
            Trace.TraceInformation(counter.ToString());

            switch (counter) // Reach end of each REST round, then entering into the next phase
            {
                case 10:
                    methodCounter++;
                    SetNextStep();
                    break;
                case 20:
                    // Finish the pilot experiment
                    // nextStep = NextStep.Finish;
                    methodCounter++;
                    SetNextStep();
                    break;
                case 30:
                    methodCounter++;
                    SetNextStep();
                    break;
                case 40:
                    // Finish the experiment
                    nextStep = NextStep.Finish;
                    break;
                default:
                    break;
            }

            Trace.TraceInformation(nextStep.ToString());

            switch (nextStep)
            {
                case NextStep.Video:
                    ScreenSetups(true);
                    PlayVideo();
                    break;
                case NextStep.Rest:
                    ScreenSetups(false, false, false, false, MainScreenSetup.RestText());

                    await Task.Delay(30 * 1000); // 30s break

                    nextStep = NextStep.Manikin;
                    counter++;
                    Then();
                    break;
                case NextStep.Image:
                    ScreenSetups(false, true);
                    PlayImage();
                    await Task.Delay(20 * 1000); // 20s display time

                    ScreenSetups();

                    nextStep = NextStep.Manikin;
                    counter++;
                    Then();
                    break;
                case NextStep.Audio:
                    ScreenSetups(false, false, false, false, MainScreenSetup.AudioText());
                    PlayAudio();
                    await Task.Delay(5 * 1000);

                    nextStep = NextStep.Manikin;
                    counter++;
                    Then();
                    break;
                case NextStep.AbR:
                    nextStep = NextStep.Manikin;
                    ScreenSetups(false, false, false, false, MainScreenSetup.AbRText(emotion.ToString()));

                    await Task.Delay(120 * 1000);

                    ScreenSetups(false, false, false, false, MainScreenSetup.AbRText(emotion.ToString()), false, true);
                    break;
                case NextStep.Manikin:
                    ScreenSetups(false, false, true, false, MainScreenSetup.ManikinText());
                    break;
                case NextStep.Finish:
                    finishCounter = 0;
                    Finish();
                    break;
                default:
                    break;
            }
        }

        private void ScreenSetups(bool videoScreenOn = false, bool imageScreenOn = false, bool manikinOn = false, bool buttonStartExperimentOn = false, string topText = "", bool avatar = false, bool buttonAbRNextOn = false, bool finishTextOn = false, bool susOn = false)
        {
            VideoPlayer.Visible = videoScreenOn;

            //if (audioSource != null) audioSource.Stop();
            //videoScreen.enabled = videoScreenOn;
            imageBox.Visible = imageScreenOn;

            ManikinSetups(manikinOn);

            ButtonStartExperiment.Visible = buttonStartExperimentOn;
            LabelTopText.Text = topText;

            LayoutPanel.Visible = topText.Length > 0 ? true : false;

            //this.avatar.SetActive(false);

            ButtonAbRNext.Visible = buttonAbRNextOn;

            LabelFinishText.Visible = finishTextOn;

            PanelSUS.Visible = susOn;
            ButtonSUS.Visible = susOn;
        }

        private void ManikinSetups(bool manikinOn)
        {
            valenceGroup.Visible = manikinOn;
            arousalGroup.Visible = manikinOn;
            dominanceGroup.Visible = manikinOn;
            ButtonSubmitManikin.Visible = manikinOn;
        }

        private void VideoPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1) // Stopped
            {
                //VideoPlayer.Hide();

                ScreenSetups();

                nextStep = NextStep.Manikin;
                Then();
            }
            if (e.newState == 3)//Playing
            {
                VideoPlayer.Ctlenabled = false;
                VideoPlayer.Dock = DockStyle.Fill;
                VideoPlayer.uiMode = "none";
                VideoPlayer.stretchToFit = true;
            }
        }

        private void SetNextStep()
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
        }
    }
}
