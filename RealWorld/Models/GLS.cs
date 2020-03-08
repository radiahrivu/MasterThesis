using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealWorld.Models
{
    public class GLS
    {
        public Emotions Emotion { get; set; }
        public Methods Method { get; set; }

        public enum Emotions
        {
            Sad,
            Anger,
            Happy,
            Exciting
        }

        public enum Methods
        {
            Video,
            AbR,
            Image,
            Audio
        }
    }
}
