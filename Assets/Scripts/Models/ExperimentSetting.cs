using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class ExperimentSetting
    {
        public int ID { get; set; }
        public int ElicitMethodSquence { get; set; }
        public int ElicitEmotion { get; set; }
        public int TaskType { get; set; }
    }
}
