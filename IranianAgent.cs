using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation
{
    internal class IranianAgent
    {
        public IranAgentRank rank;

        List<Sensor> sensors;
        public List<SensorType> RekSensors { get; private set; }
        public Dictionary<SensorType, int> ExposedSencors { get; private set; }


        public IranianAgent(IranAgentRank rank)
        {
            sensors = new List<Sensor>();
            RekSensors = new List<SensorType>();
            ExposedSencors = new();

            for (int i = 0; i < (int)rank; i++)
            {
                SensorType randomType = GetRandomSensorType(new Random());
                RekSensors.Add(randomType);

                if (ExposedSencors.ContainsKey(randomType))
                    ExposedSencors[randomType]++;
                else
                    ExposedSencors[randomType] = 1;
            }
        }

        SensorType GetRandomSensorType(Random rand)
        {
            var values = Enum.GetValues(typeof(SensorType));
            return (SensorType)values.GetValue(rand.Next(values.Length));
        }

        public Dictionary<SensorType,int> Exposed(Sensor s)
        {
            if (ExposedSencors.ContainsKey(s.Type) && ExposedSencors[s.Type] > 0)
            {
                ExposedSencors[s.Type]--;
            }
            return this.ExposedSencors;
        }

    }
}
