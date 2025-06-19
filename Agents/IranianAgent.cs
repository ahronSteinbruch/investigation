
namespace investigation
{
    public class IranianAgent
    {
        // rank
        public IranAgentRank Rank;
        public int TurnCounter;
        public bool Shell = false;
        protected Random rand = new Random();

        public List<Sensor> Attachedsensors;
        public Dictionary<SensorType, int> ExposeSensors { get; private set; }


        public IranianAgent(IranAgentRank rank)
        {
            this.Rank = rank;
            startAgein();
        }

        public virtual void TurnHendler(Sensor s)
        {
            Console.WriteLine(TurnCounter);
            TurnCounter++;
            TryAttachedsens(s);
            if (TurnCounter == 10)
            {
                startAgein();
                TurnCounter = 0;
            }
            CallSensors();
        }

        // init the ExposedSencors add random req sensors type 
        private void InitExposedSencors()
        {
            for (int i = 0; i < (int)Rank; i++)
            {
                SensorType randomType = GetRandomSensorType();

                if (ExposeSensors.ContainsKey(randomType))
                    ExposeSensors[randomType]++;
                else
                    ExposeSensors[randomType] = 1;
            }
        }
        protected void addSensor(Sensor s)
        {
            Attachedsensors.Add(s);
            ExposeSensors[s.Type]--;
        }

        public void startAgein()
        {
            Attachedsensors = new();
            ExposeSensors = new();
            InitExposedSencors();
            TurnCounter = 0;
        }

        protected SensorType GetRandomSensorType()
        {
            var values = Enum.GetValues(typeof(SensorType));
            return (SensorType)values.GetValue(rand.Next(values.Length));
        }

        public void TryAttachedsens(Sensor s)
        {
            if (ExposeSensors.ContainsKey(s.Type) && ExposeSensors[s.Type] > 0)
            {
                Console.WriteLine("congrets your in the right wey");
                addSensor(s);
            }
            else Console.WriteLine("try agein in your next torn");
        }
        public bool IsExposed()
        {
            return Attachedsensors.Count == (int)Rank;
        }
        public void CallSensors()
        {
            for (int i = Attachedsensors.Count - 1; i >= 0; i--)
            {
                Sensor s = Attachedsensors[i];

                s.Activate();

                if (s is IDurability durabilitySensor && durabilitySensor.IsBroke())
                {
                    RmSensor(i);

                    Console.WriteLine($"{s.Type} has broken and was removed.");
                }
            }
        }

        public void RmSensor(int idx)
        {
            if(Attachedsensors.Count > 0)
            {
                ExposeSensors[Attachedsensors[idx].Type]++;
                Attachedsensors.RemoveAt(idx);
            }
        }
        
    }
}
