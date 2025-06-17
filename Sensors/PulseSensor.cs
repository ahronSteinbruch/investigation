
namespace investigation
{
    internal class PulseSensor : Sensor, IDurability
    {
        private int lifeAmount = 3;

        public PulseSensor(SensorType  type) : base(type) { }

        public override void Activate()
        {
            Console.WriteLine("I am Sensor Pulse");
            lifeAmount--;
        }

        public bool IsBroke()
        {
            return lifeAmount <= 0;
        }
    }
}
