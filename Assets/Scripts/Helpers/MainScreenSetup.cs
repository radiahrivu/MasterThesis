using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers
{
    public static class MainScreenSetup
    {
        public static string StartingText()
        {
            return "Welcome! Please observe and get familiar with the room and hit the \"Start Experiment\" button when you feel ready.";
        }

        public static string ManikinText()
        {
            return "Please evaluate your current emotion, with upper part as how negative or positive do you feel, and middle row as how strong your emotion is, the lower part indicates how much you can affect your emotion right now. To proceed further, please click \"Subimit my Selection\" button after selecting all 3 rows.";
        }

        public static string ManikinErrorText()
        {
            return "Please make sure you have selected one of the 9 choices per row and all 3 rows.";
        }

        public static string RestText()
        {
            return "Please take a rest (around 30 seconds) until our next question. During the break you should keep the VR headset on and look around or think about anything else.";
        }

        public static string AudioText()
        {
            return "Please listen to the audio source carefully.";
        }

        public static string AbRText(string emotion)
        {
            return "Please think of the " + emotion + " memory as we informed earlier, then you can share the memory or your feelings in this environment. What you said will not be listened or recorded by any party. Once you are done, please click the \"Next Step\" button which will appear in 2 minutes.";
        }

        public static string FinishText()
        {
            return "Thank you for participating our experiment, now you may let the experimenter know it is all finished.";
        }

        public static string SUSErrorText()
        {
            return "Please make sure you have selected one of the 7 choices.";
        }
    }
}
