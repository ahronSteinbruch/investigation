using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation
{
    internal class SensorPulse : Sensor
    {
        int lifeAmount;
        public SensorPulse(int lifeAmount, SensorType sensoreNum) : base(sensoreNum)
        {
            this.lifeAmount = lifeAmount;
        }
        public void Activate()
        {
            Console.WriteLine($"i am Sensore pulse");
            lifeAmount--;
        }

    }
}
