/*using investigation;

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
                    //if (!Enum.IsDefined(typeof(SensorType), choice)) continue;

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
            Console.WriteLine($"Investigating: {agent.GetType().Name}");
            Console.WriteLine($"Correct sensors: {(int)agent.Rank}/{agent.Attachedsensors.Count}");

            Console.WriteLine("Select sensor to attach:");
            foreach (var st in Enum.GetValues(typeof(SensorType)))
                Console.WriteLine($"{(int)st} - {st}");
            Console.Write("Your choice: ");
        }


    }
}
*/

using DataAccess;
using investigation;

namespace investigation
{
    public class Investigator
    {
        private readonly List<IranianAgent> agents;
        private int currentAgentIndex = 0;
        private int totalTurns = 0;
        private int currentUserId; 
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
            ScoreHandler.ShowTopScores();

            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            // --- START: טיפול במשתמש ---
            var user = UserDataAccess.GetUserByUsername(username);

            if (user == null)
            {
                int newUserId = UserDataAccess.AddUser(username);
                Console.WriteLine($"[+] New user '{username}' created with ID: {newUserId}");
                currentUserId = newUserId;
            }
            else
            {
                Console.WriteLine($"[✔] Welcome back, {username}!");
                currentUserId = user.Id;
            }

            // --- END: טיפול במשתמש ---

            while (currentAgentIndex < agents.Count)
            {
                var agent = agents[currentAgentIndex];
                Console.Clear();
                Console.WriteLine($"\n=== Investigation: {agent.GetType().Name} ===");

                while (!agent.IsExposed())
                {
                    ShowMenu(agent);

                    string input = Console.ReadLine();

                    // בדיקה אם הקלט הוא מספר תקין
                    if (!int.TryParse(input, out int choice))
                    {
                        Console.WriteLine("[⚠] Invalid input. Please enter a number.");
                        continue;
                    }

                    // בדיקה אם הבחירה היא סוג סנסור תקין
                    if (!Enum.IsDefined(typeof(SensorType), choice))
                    {
                        Console.WriteLine("[⚠] Invalid sensor type. Please choose from the list.");
                        continue;
                    }

                    var selectedType = (SensorType)choice;
                    var sensor = SensorFactory.CreateSensor(selectedType, agent);

                    agent.TurnHendler(sensor);
                    totalTurns++;
                }

                Console.WriteLine("[✔] Agent exposed! Press Enter to continue...");
                Console.ReadLine();
                currentAgentIndex++;
            }

            Console.WriteLine($"[🏆] Congratulations! All agents exposed in {totalTurns} turns.");
            ScoreHandler.SaveScoreIfQualifies(username, totalTurns, currentUserId); 
        }

        private void ShowMenu(IranianAgent agent)
        {
            Console.WriteLine($"Investigating: {agent.GetType().Name}");
            Console.WriteLine($"Correct sensors: {(int)agent.Rank}/{agent.Attachedsensors.Count}");
            Console.WriteLine($"Total turns so far: {totalTurns}");

            Console.WriteLine("Select sensor to attach:");
            foreach (var st in Enum.GetValues(typeof(SensorType)))
                Console.WriteLine($"{(int)st} - {st}");
            Console.Write("Your choice: ");
        }
    }
}
