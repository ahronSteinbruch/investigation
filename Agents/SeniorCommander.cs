using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace investigation
{
    public class SeniorCommander : IranianAgent,ICounterAttacker 
    {
        private readonly int AttackInterval = 3;
        public SeniorCommander() : base(IranAgentRank.Senior_Commander) { }

        public void CounterAttack()
        {
            RmRandAttachdeSens();
            RmRandAttachdeSens();
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
