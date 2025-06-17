
namespace investigation
{
    internal class ThermalSensor : SensorWithAgent
    {
        public ThermalSensor(SensorType type,IranianAgent agent)
            : base(type, agent) { }

        public override void Activate()
        {
            var secretList = Agent.ExposeSensors.Keys.ToList();

                var random = new Random();
                var revealed = secretList[random.Next(secretList.Count)];
                Console.WriteLine($"🕵️‍♂️ Thermal Sensor: Detected one correct sensor type: {revealed}");
            
        }
    }
}
