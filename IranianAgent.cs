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

        public List<SensorType> RekSensors;

        Dictionary<int, SensorType> ExposedSencors;


        public IranianAgent(IranAgentRank rank)
        {
            sensors = new List<Sensor>();
            RekSensors = new List<SensorType>();

            for (int i = 0; i < (int)rank; i++)
            {
                SensorType randomType = GetRandomSensorType(new Random());
                RekSensors.Add(randomType);
            }
        }

        SensorType GetRandomSensorType(Random rand)
        {
            var values = Enum.GetValues(typeof(SensorType));
            return (SensorType)values.GetValue(rand.Next(values.Length));
        }

    }
}
