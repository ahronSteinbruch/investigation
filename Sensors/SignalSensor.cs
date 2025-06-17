
namespace investigation
{
    internal class SignalSensor : SensorWithAgent
    {
        public SignalSensor(SensorType type, IranianAgent agent)
            : base(type, agent) { }

        public override void Activate()
        {
            Console.WriteLine($"📡 Signal Sensor: Agent Rank is {Agent.Rank}");
        }
    }
}
