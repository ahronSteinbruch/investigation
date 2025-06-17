namespace investigation
{
    public class Investigator
    {
        private readonly List<IranianAgent> agents;
        private int currentAgentIndex = 0;
      

        public Investigator()
        {
            agents = new List<IranianAgent>
            {
                new FootSoldier(),
                new SquadLeader(),
                new SeniorCommander(),
                new OrganizationLeader()
            };
        }

        public void StartInvestigation()
        {
            while (currentAgentIndex < agents.Count)
            {
                var agent = agents[currentAgentIndex];
                Console.Clear();
                Console.WriteLine($"\n=== Investigation: {agent.GetType().Name} ===");

                while (!agent.IsExposed())
                {
                    ShowMenu(agent);
                    if (!int.TryParse(Console.ReadLine(), out int choice)) continue;
                    if (!Enum.IsDefined(typeof(SensorType), choice)) continue;

                    var selectedType = (SensorType)choice;
                    var sensor = SensorFactory.CreateSensor(selectedType,agent);

                    agent.TryAttachedsens(sensor);
                }
                Console.WriteLine("[✔] Agent exposed! Press Enter to continue...");
                Console.ReadLine();
                currentAgentIndex++;
            }

            Console.WriteLine("[🏆] Congratulations! All agents exposed.");
        }

        private void ShowMenu(IranianAgent agent)
        {
            Console.Clear();
            Console.WriteLine($"Investigating: {agent.GetType().Name}");
            Console.WriteLine($"Correct sensors: {(int)agent.Rank}/{agent.Attachedsensors.Count}");

            Console.WriteLine("Select sensor to attach:");
            foreach (var st in Enum.GetValues(typeof(SensorType)))
                Console.WriteLine($"{(int)st} - {st}");
            Console.Write("Your choice: ");
        }


    }
}
