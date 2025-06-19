
namespace investigation
{
    internal class OrganizationLeader : IranianAgent, ICounterAttacker
    {
        private readonly int AttackInterval = 3;
        public OrganizationLeader() : base(IranAgentRank.Organization_Leader) { }

        public void CounterAttack()
        {
            RmSensor(0);
        }

        public bool ShouldAttack()
        {
            return TurnCounter % AttackInterval == 0 && !this.Shell;
        }

        public override void TurnHendler(Sensor s)
        {
            TurnCounter++;
            TryAttachedsens(s);
            if (ShouldAttack()) CounterAttack();
            if (TurnCounter == 10)
            {
                startAgein();
                TurnCounter = 0;
            }
        }
        private void RmRandAttachdeSens()
        {
            int idx = (int)rand.Next(this.Attachedsensors.Count);
            RmSensor(idx);
        }
    }
}    
    

