using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation
{

    public abstract class Sensor
    {
        public SensorType Type { get; }
        public Sensor(SensorType type) => Type = type;

        public virtual void Activate() { }
    }
}