
namespace investigation
{
    internal class LightSensor : SensorWithAgent
    {
        IranianAgent Agent;
        public LightSensor(SensorType type, IranianAgent agent) : base(type, agent)
        {
            this.Agent = agent;
        }

        public override void Activate()
        {
            RevealInfo();
        }

        public void RevealInfo()
        {
            Console.WriteLine($"💡 Light Sensor: Agent Rank is {Agent.Rank}");
            Console.WriteLine($"💡 Also detected that the agent has {(int)Agent.Rank} sensors to reviled");
        }
    }
}
