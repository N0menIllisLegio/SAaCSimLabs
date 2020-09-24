using SAaCSimLabs.Lab3.Components;
using System.Collections.Generic;
using System.Linq;

namespace SAaCSimLabs.Lab3
{
    struct StateInfo
    {
        /// <summary>
        /// System state
        /// </summary>
        public int[] State { get; set; }

        /// <summary>
        /// How many times system 
        /// was in this state
        /// </summary>
        public int Times { get; set; }

        public override string ToString()
        {
            string output = "";

            for (int i = State.Length - 1; i >= 0; i--)
            {
                output += $"{State[i]}";
            }
            
            return output;
        }
    }

    class MassServiceSystem
    {
        /// <summary>
        /// How many tacts system will work
        /// </summary>
        public int ExecutionTime { get; set; }

        /// <summary>
        /// Current tact of system
        /// </summary>
        public int Tact { get; private set; }

        /// <summary>
        /// Generated requests
        /// </summary>
        public List<Request> Requests { get; }

        /// <summary>
        /// Components of the system
        /// </summary>
        public IComponent[] Components { get; private set; }

        #region StatisticsProps

        /// <summary>
        /// System states
        /// </summary>
        public List<StateInfo> ProbabilityStatesInfos { get; }

        /// <summary>
        /// А – абсолютная пропускная способность(среднее число заявок, 
        ///   обслуживаемых системой в единицу времени, т.е.интенсивность потока заявок на выходе системы); 
        /// </summary>
        public double AbsoluteBandwidth { get; private set; }

        /// <summary>
        /// Q – относительная пропускная способность(вероятность того, что 
        ///   заявка, сгенерированная источником, будет в конечном итоге обслужена системой);
        /// </summary>
        public double RelativeBandwidth { get; private set; }

        /// <summary>
        /// Ротк – вероятность отказа(вероятность того, что заявка, 
        ///   сгенерированная источником, не будет в конечном итоге обслужена системой);
        /// </summary>
        public double DeclineProbability { get; private set; }


        private int _requestsInSystem;

        /// <summary>
        /// Lc – среднее число заявок, находящихся в системе;
        /// </summary>
        public double AvgRequestsInSystem { get; private set; }

        /// <summary>
        /// Wс – среднее время пребывания заявки в системе;
        /// </summary>
        public double AvgTimeOfRequestInSystem { get; private set; }

        /// <summary>
        /// Wоч – среднее время пребывания заявки в очереди;
        /// </summary>
        public double AvgTimeOfRequestInQueue { get; private set; }

        /// <summary>
        /// Kкан – коэффициент загрузки канала (вероятность занятости канала). 
        /// </summary>
        public List<KeyValuePair<string, double>> CoefsOfChannelCapacity { get; }

        /// <summary>
        /// Lоч – средняя длина очереди;  
        /// </summary>
        public List<KeyValuePair<string, double>> AvgQueueLength { get; }

        /// <summary>
        /// Рбл – вероятность блокировки
        ///     (вероятность застать источник или канал в состоянии блокировки); 
        /// </summary>
        public List<KeyValuePair<string, double>> BlockingProbability { get; }
        #endregion

        /// <summary>
        /// Create mass service system
        /// </summary>
        /// <param name="executionTime">How many tacts system will work</param>
        public MassServiceSystem(int executionTime)
        {
            Requests = new List<Request>();
            ExecutionTime = executionTime;

            ProbabilityStatesInfos = new List<StateInfo>();
            CoefsOfChannelCapacity = new List<KeyValuePair<string, double>>();
            AvgQueueLength = new List<KeyValuePair<string, double>>();
            BlockingProbability = new List<KeyValuePair<string, double>>();
        }

        /// <summary>
        /// Set system's components
        /// </summary>
        /// <param name="components">Channels, queues, sources</param>
        public void SetComponents(params IComponent[] components)
        {
            // Add validating of system
            Components = components.OrderByDescending(component => component.PositionInStruct).ToArray();
            LinkComponents(components);
        }

        /// <summary>
        /// Start system
        /// </summary>
        public void Start()
        {
            Requests.Clear();
            ProbabilityStatesInfos.Clear();

            for (Tact = 1; Tact < ExecutionTime; Tact++)
            {
                foreach (IComponent component in Components)
                {
                    component.Process();
                }

                foreach (Request request in Requests)
                {
                    request.TactsPassed();

                    if (request.State == RequestState.Pending || request.State == RequestState.Processing)
                    {
                        _requestsInSystem++;
                    }
                }

                UpdateStates(GetCurrentStateOfSystem());
            }

            CalculateStatistics();
        }

        /// <summary>
        /// Calculate system statistics
        /// </summary>
        private void CalculateStatistics()
        {
            CoefsOfChannelCapacity.Clear();
            BlockingProbability.Clear();
            AvgQueueLength.Clear();

            AbsoluteBandwidth = Requests.Count(x => x.State == RequestState.Completed) / (double)Tact;
            RelativeBandwidth = Requests.Count(x => x.State == RequestState.Completed) / (double)Requests.Count;
            DeclineProbability = 1 - RelativeBandwidth;
            AvgTimeOfRequestInQueue = Requests.Sum(x => x.State == RequestState.Completed ? x.TimeInQueue : 0) 
                / (double)Requests.Count(x=>x.State == RequestState.Completed);
            AvgTimeOfRequestInSystem = Requests.Sum(x => x.State == RequestState.Completed ? x.ExistingTime : 0) 
                / (double)Requests.Count(x=>x.State == RequestState.Completed);
            AvgRequestsInSystem = _requestsInSystem / (double)Tact;

            foreach (IComponent component in Components)
            {
                if (component is Channel channel)
                {
                    CoefsOfChannelCapacity.Add(new KeyValuePair<string, double>(channel.ToString(), 
                        channel.TactsChannelProcessed / (double)Tact));

                    if (component.GetType() == typeof(ChannelWithBlockingDiscipline))
                    {
                        ChannelWithBlockingDiscipline blockingChannel = component as ChannelWithBlockingDiscipline;
                        BlockingProbability.Add(new KeyValuePair<string, double>(blockingChannel.ToString(),
                            blockingChannel.TactsChannelBlocked / (double)Tact));
                    }
                }
                else if (component.GetType() == typeof(SourceWithBlockingDiscipline))
                {
                    SourceWithBlockingDiscipline source = component as SourceWithBlockingDiscipline;
                    BlockingProbability.Add(new KeyValuePair<string, double>(source.ToString(), 
                        source.TactsSourceBlocked / (double)Tact));

                }
                else if (component.GetType() == typeof(Queue))
                {
                    Queue queue = component as Queue;
                    AvgQueueLength.Add(new KeyValuePair<string, double>(queue.ToString(), 
                        queue.SumOfSizes / (double)Tact));
                }
            }
        }

        /// <summary>
        /// Connect components in one system
        /// </summary>
        /// <param name="components">Channels, queues, sources</param>
        private void LinkComponents(params IComponent[] components)
        {
            foreach (IComponent component in components)
            {
                component.NextComponents =
                    components.Where(cmp => cmp.PositionInStruct == component.PositionInStruct + 1).ToArray();
            }
        }

        /// <summary>
        /// Get system state
        /// </summary>
        /// <returns>System state</returns>
        private int[] GetCurrentStateOfSystem()
        {
            int[] state = new int[Components.Length];

            for (int i = 0; i < Components.Length; i++)
            {
                state[i] = Components[i].CurrentState;
            }

            return state;
        }

        /// <summary>
        /// Update system's states
        /// </summary>
        /// <param name="newState">Current system state</param>
        private void UpdateStates(int[] newState)
        {
            static bool arraysMatches(int[] array1, int[] array2)
            {
                if (array1.Length != array2.Length)
                {
                    return false;
                }

                for (int i = 0; i < array1.Length; i++)
                {
                    if (array1[i] != array2[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            int stateIndex = ProbabilityStatesInfos.FindIndex(state => arraysMatches(state.State, newState));
            if (stateIndex == -1)
            {
                StateInfo stateInfo = new StateInfo
                {
                    State = newState,
                    Times = 1
                };

                ProbabilityStatesInfos.Add(stateInfo);
            }
            else
            {
                StateInfo stateInfo = new StateInfo
                {
                    State = newState,
                    Times = ProbabilityStatesInfos[stateIndex].Times + 1
                };

                ProbabilityStatesInfos[stateIndex] = stateInfo;
            }
        }
    }
}
