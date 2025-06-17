using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation
{
    internal class AudioSensor : Sensor
    {
        public AudioSensor() : base(SensorType.Audio) { }

        public override void Activate()
        {
            Console.WriteLine("Audio Sensor activated");
        }
    }
}
