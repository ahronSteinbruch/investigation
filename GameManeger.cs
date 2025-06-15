using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation
{
    internal class GameManeger
    {
        public bool InvestigerTorn = true;
        public IranianAgent agent = new IranianAgent(IranAgentRank.Intermediate);

        public void pley()
        {
            Console.WriteLine("choos a sensor ");

            foreach (SensorType type in Enum.GetValues(typeof(SensorType)))
                Console.WriteLine($"for {type} choos {(int)type}");

            if (int.TryParse(Console.ReadLine(), out int choosed))
                Console.WriteLine($"You chose: {choosed}");
            else
                Console.WriteLine("Invalid number.");

            Sensor s = new Sensor((SensorType)choosed);
            InvestigerTorn = agent.Exposed(s);
            
        }

    }
}
