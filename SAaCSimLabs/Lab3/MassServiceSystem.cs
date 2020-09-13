using SAaCSimLabs.Lab3.Components;
using System.Collections.Generic;
using System.Linq;

namespace SAaCSimLabs.Lab3
{
    struct StateInfo
    {
        public int[] State { get; set; }
        public int Times { get; set; }

        public override string ToString()
        {
            string output = "";

            for (int i = State.Length - 1; i >= 0; i--)
            {
                output += $"{State[i]}";
            }

            output += $" - {Times}";
            
            return output;
        }
    }

    class MassServiceSystem
    {
        private int _requestsInSystem;

        public int ExecutionTime { get; set; }

        public int Tact { get; private set; }
        public List<Request> Requests { get; }
        public IComponent[] Components { get; private set; }

        #region StatisticsProps

        public List<StateInfo> ProbabilityStatesInfos { get; }

        public double AbsoluteBandwidth { get; private set; }
        public double DeclineProbability { get; private set; }
        public double AvgTimeOfRequestInSystem { get; private set; }
        public double AvgRequestsInSystem { get; private set; }
        public double RelativeBandwidth { get; private set; }
        public double AvgTimeOfRequestInQueue { get; private set; }
        public List<double[]> CoefsOfChannelCapacity { get; }
        public List<double[]> BlockingProbability { get; }
        public List<double[]> AvgQueueLength { get; }

        #endregion

        public MassServiceSystem(int executionTime)
        {
            Requests = new List<Request>();
            ExecutionTime = executionTime;
            ProbabilityStatesInfos = new List<StateInfo>();
            CoefsOfChannelCapacity = new List<double[]>();
            BlockingProbability = new List<double[]>();
            AvgQueueLength = new List<double[]>();
        }

        public void SetComponents(params IComponent[] components)
        {
            // Add validating of system
            Components = components.OrderByDescending(component => component.PositionInStruct).ToArray();
            LinkComponents(components);
        }

        public void Execute()
        {
            Requests.Clear();
            ProbabilityStatesInfos.Clear();

            //UpdateStates(GetCurrentStateOfSystem());

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

        private void CalculateStatistics()
        {
            //А – абсолютная пропускная способность(среднее число заявок, 
            //   обслуживаемых системой в единицу времени, т.е.интенсивность потока заявок на выходе системы);
            AbsoluteBandwidth = Requests.Count(x => x.State == RequestState.Completed) / (double)Tact;

            //Ротк – вероятность отказа(вероятность того, что заявка, 
            //   сгенерированная источником, не будет в конечном итоге обслужена системой);
            DeclineProbability = Requests.Count(x => x.State == RequestState.Discarded) / (double)Requests.Count;

            //Wс – среднее время пребывания заявки в системе;
            AvgTimeOfRequestInSystem = Requests.Sum(x => x.ExistingTime) / (double)Requests.Count(x => 
                x.State != RequestState.Discarded);

            //Lc – среднее число заявок, находящихся в системе;
            AvgRequestsInSystem = _requestsInSystem / (double)Tact;

            //Q – относительная пропускная способность(вероятность того, что 
            //   заявка, сгенерированная источником, будет в конечном итоге обслужена системой);
            RelativeBandwidth = Requests.Count(x => x.State == RequestState.Completed) / (double) Requests.Count;

            //Wоч – среднее время пребывания заявки в очереди;
            AvgTimeOfRequestInQueue = Requests.Sum(x => x.TimeInQueue) / (double)Requests.Count(x => x.State != RequestState.Temp);

            List<double[]> tactsChannelProcessing = new List<double[]>();
            List<double[]> tactsComponentBlocking = new List<double[]>();
            List<double[]> sizesOfQueues = new List<double[]>();

            foreach (IComponent component in Components)
            {
                if (component is Channel channel1)
                {
                    double[] channelInfo = new double[3];

                    channelInfo[0] = channel1.PositionInStruct;
                    channelInfo[1] = channel1._π;
                    channelInfo[2] = channel1.TactsChannelProcessing;

                    tactsChannelProcessing.Add(channelInfo);
                }
                else if (component.GetType() == typeof(ChannelWithBlockingDiscipline))
                {
                    double[] channelInfo = new double[3];
                    ChannelWithBlockingDiscipline channel = component as ChannelWithBlockingDiscipline;
                    channelInfo[0] = component.PositionInStruct;
                    channelInfo[1] = channel._π;
                    channelInfo[2] = channel.TactsChannelBlocking;

                    tactsComponentBlocking.Add(channelInfo);
                }
                else if (component.GetType() == typeof(SourceWithBlockingDiscipline))
                {
                    double[] channelInfo = new double[3];
                    SourceWithBlockingDiscipline source = component as SourceWithBlockingDiscipline;
                    channelInfo[0] = component.PositionInStruct;
                    
                    if (source._fixedTime != null)
                    {
                        channelInfo[1] = source._fixedTime.Value;
                    }
                    else
                    {
                        channelInfo[1] = source._ρ;
                    }
                    
                    channelInfo[2] = source.TactsChannelBlocking;

                    tactsComponentBlocking.Add(channelInfo);
                }
                else if (component.GetType() == typeof(Queue))
                {
                    double[] queueInfo = new double[3];
                    Queue queue = component as Queue;

                    queueInfo[0] = queue.PositionInStruct;
                    queueInfo[1] = queue._queueSize;
                    queueInfo[2] = queue.SumOfSizes;

                    sizesOfQueues.Add(queueInfo);
                }
            }

            CoefsOfChannelCapacity.Clear();
            BlockingProbability.Clear();
            AvgQueueLength.Clear();
            
            //Kкан – коэффициент загрузки канала (вероятность занятости канала).
            // The problem is that I am not 100% sure that its exectly last channel
            // and there can be more than 1 channel => idk is this 1 combined result or separete for each channel

            // tacts processing / Tact
            // var CoefOfChannelCapacity = tactsChannelProcessing / (double)Tact;
            
            foreach (double[] channelInfo in tactsChannelProcessing)
            {
                channelInfo[2] = channelInfo[2] / Tact;
                CoefsOfChannelCapacity.Add(channelInfo);
            }

            //Рбл – вероятность блокировки(вероятность застать источник или канал в состоянии блокировки);
            //
            
            foreach (double[] componentInfo in tactsComponentBlocking)
            {
                componentInfo[2] = componentInfo[2] / Tact;
                BlockingProbability.Add(componentInfo);
            }

            //Lоч – средняя длина очереди;
            //Requests.Count(x => x.TimeInQueue > 0) / (double) Requests.Count; // ?
            
            foreach (double[] queueInfo in sizesOfQueues)
            {
                queueInfo[2] = queueInfo[2] / Tact;
                AvgQueueLength.Add(queueInfo);
            }
        }

        private void LinkComponents(params IComponent[] components)
        {
            foreach (IComponent component in components)
            {
                component.NextComponents =
                    components.Where(cmp => cmp.PositionInStruct == component.PositionInStruct + 1).ToArray();
            }
        }

        private int[] GetCurrentStateOfSystem()
        {
            int[] state = new int[Components.Length];

            for (int i = 0; i < Components.Length; i++)
            {
                state[i] = Components[i].CurrentState;
            }

            return state;
        }

        private void UpdateStates(int[] newState)
        {
            bool arraysMatches(int[] array1, int[] array2)
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
