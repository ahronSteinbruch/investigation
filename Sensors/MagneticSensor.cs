
namespace investigation
{
    internal class MagneticSensor : SensorWithAgent
    {
        private int Shell_used = 0;

        public MagneticSensor(SensorType type,IranianAgent agent)
            : base(type, agent) { }

        public override void Activate()
        {
            BlockCounterAttack();
            Shell_used++;
        }

        public void BlockCounterAttack()
        {
                Agent.Shell = Shell_used < 2 ? true : false;       
        }
    }
}
