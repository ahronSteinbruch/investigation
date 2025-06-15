using System;


namespace investigation
{

   
    class Program
    {
        public static void testBaseAgent()
        {
            IranianAgent agent = new IranianAgent(IranAgentRank.Intermediate);

            Console.WriteLine("Iranian Agent Created with Rank: " + agent.rank);
            Console.WriteLine("Randomly Selected Sensors:");

            foreach (var sensorType in agent.RekSensors)
            {
                Console.WriteLine("- " + sensorType);
            }

            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            GameManeger maneger = new GameManeger();
            while (true)
            {
            if (maneger.InvestigerTorn)
                maneger.pley();              
            }
        }   
    }
}
