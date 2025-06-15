using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation
{

    public enum SensorType
    {
        Record = 1,
        Thermal = 2,
        Gps = 3
    }
    public enum IranAgentRank
    {
        Beginner = 2,
        Intermediate = 4,
        Highest = 6
    }
    internal abstract class Sensor
    {
        public SensorType Type;

        public Sensor(SensorType sensoreNum)
        {
            this.Type = sensoreNum;
        }
        public void Activate()
        {
            Console.WriteLine($"i am a {this.Type} sensor"); 
        }
    }
}
