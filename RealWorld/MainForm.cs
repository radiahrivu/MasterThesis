using RealWorld.Helpers;
using RealWorld.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        // 0 = Video, 1 = AbR, 2 = Image, 3 = Audio
        int[,] sequence = new int[,] { { 0, 1, 2, 3 }, { 0, 1, 3, 2 }, { 0, 2, 1, 3 }, { 0, 2, 3, 1 }, { 0, 3, 1, 2 }, { 0, 3, 2, 1 }, { 1, 0, 2, 3 }, { 1, 0, 3, 2 }, { 1, 2, 0, 3 }, { 1, 2, 3, 0 }, { 1, 3, 0, 2 }, { 1, 3, 2, 0 }, { 2, 0, 1, 3 }, { 2, 0, 3, 1 }, { 2, 1, 0, 3 }, { 2, 1, 3, 0 }, { 2, 3, 1, 0 }, { 2, 3, 0, 1 }, { 3, 0, 1, 2 }, { 3, 0, 2, 1 }, { 3, 1, 0, 2 }, { 3, 1, 2, 0 }, { 3, 2, 0, 1 }, { 3, 2, 1, 0 } };

        int[,] pilotSequence = new int[,] { { 0, 1 }, { 1, 0 } };

        string connString;
        int userId;

        ExperimentSetting setting;

        NextStep nextStep;
        int counter = 0;
        int methodCounter = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ScreenSetups(false, false, false, true, MainScreenSetup.StartingText());

            // tochange
            //connString = "URI=file:" + Application.dataPath + "/MT_Ruoyu.sqlite";
            connString = "URI=file:C:/Ruoyu/MT002/Assets" + "/Test_DB.sqlite";

            // tochange
            userId = 2;

            setting = new ExperimentSetting();
            setting = setting.GetExperimentSettingByUserId(connString, userId);
        }

        private void ButtonStartExperiment_Click(object sender, EventArgs e)
        {
            counter = 0;
            nextStep = (NextStep)pilotSequence[setting.Sequence, methodCounter];
            Then();
        }

        private void ButtonSubmitManikin_Click(object sender, EventArgs e)
        {
            var result = new ExperimentResult(userId, setting.ID, pilotSequence[setting.Sequence, methodCounter], 0, 0, 0, counter);

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

            switch ((Method)pilotSequence[setting.Sequence, methodCounter])
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
            ScreenSetups(true);

            var path = @"C:\Ruoyu\MT002\Assets\Videos\";

            switch ((Emotion)setting.Emotion)
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

        async void Then()
        {
            Trace.TraceInformation(counter.ToString());

            switch (counter) // Reach end of each REST round, then entering into the next phase
            {
                case 10:
                    methodCounter++;
                    nextStep = (NextStep)pilotSequence[setting.Sequence, methodCounter];
                    break;
                case 20:
                    // Finish the pilot experiment
                    nextStep = NextStep.Finish;

                    //methodCounter++;
                    //nextStep = (NextStep)pilotSequence[setting.Sequence, methodCounter];
                    break;
                case 30:
                    methodCounter++;
                    nextStep = (NextStep)pilotSequence[setting.Sequence, methodCounter];
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
                    PlayVideo();
                    break;
                case NextStep.Rest:
                    ScreenSetups(false, false, false, false, MainScreenSetup.RestText());

                    await Task.Delay(30 * 1000); // 30s break

                    nextStep = NextStep.Manikin;
                    counter++;
                    Then();
                    break;
                //case NextStep.Image:
                //    PlayImage();
                //    Sleep(60); // 60s display time

                //    ScreenSetups();

                //    nextStep = NextStep.Manikin;
                //    Then();
                //    break;
                //case NextStep.Audio:
                //    PlayAudio();
                //    leep(187); // Duration of the Audio: 187s

                //    ScreenSetups();

                //    nextStep = NextStep.Manikin;
                //    Then();
                //    break;
                case NextStep.AbR:
                    nextStep = NextStep.Manikin;
                    ScreenSetups(false, false, false, false, MainScreenSetup.AbRText(((Emotion)setting.Emotion).ToString()));

                    await Task.Delay(120 * 1000); // 120s break

                    ScreenSetups(false, false, false, false, MainScreenSetup.AbRText(((Emotion)setting.Emotion).ToString()), false, true);
                    break;
                case NextStep.Manikin:
                    ScreenSetups(false, false, true, false, MainScreenSetup.ManikinText());
                    break;
                case NextStep.Finish:
                    ScreenSetups(false, false, false, false, "", false, false, true);
                    break;
                default:
                    break;
            }
        }

        private void ScreenSetups(bool videoScreenOn = false, bool imageScreenOn = false, bool manikinOn = false, bool buttonStartExperimentOn = false, string topText = "", bool avatar = false, bool buttonAbRNextOn = false, bool finishTextOn = false)
        {
            VideoPlayer.Visible = videoScreenOn;

            //if (audioSource != null) audioSource.Stop();
            //videoScreen.enabled = videoScreenOn;
            //imageScreen.enabled = imageScreenOn;

            ManikinSetups(manikinOn);

            ButtonStartExperiment.Visible = buttonStartExperimentOn;
            LabelTopText.Text = topText;

            LayoutPanel.Visible = topText.Length > 0 ? true : false;

            //this.avatar.SetActive(false);

            ButtonAbRNext.Visible = buttonAbRNextOn;

            LabelFinishText.Visible = finishTextOn;
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
    }
}
