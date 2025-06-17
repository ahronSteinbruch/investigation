namespace investigation
{
    public abstract class SensorWithAgent : Sensor
    {
        protected IranianAgent Agent;  

        protected SensorWithAgent(SensorType type, IranianAgent agent)
            : base(type)
        {
            Agent = agent;
        }

        public abstract override void Activate();
    }
}
