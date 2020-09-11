using SAaCSimLabs.Lab3.Components;
using System.Collections.Generic;
using System.Linq;

namespace SAaCSimLabs.Lab3
{
    struct StateInfo
    {
        public int[] State { get; set; }
        public int Times { get; set; }
    }

    class MassServiceSystem
    {
        public int ExecutionTime { get; set; }
        public List<Request> Requests { get; }

        // Start from 1 not from 0
        public int Tact { get; private set; }
        public IComponent[] Components { get; private set; }

        public List<StateInfo> ProbabilityStatesInfos { get; private set; }

        public MassServiceSystem(int executionTime)
        {
            Requests = new List<Request>();
            ExecutionTime = executionTime;
            ProbabilityStatesInfos = new List<StateInfo>();
        }

        public void SetComponents(params IComponent[] components)
        {
            Components = components.OrderByDescending(component => component.PositionInStruct).ToArray();
            LinkComponents(components);
        }

        public void Execute()
        {
            Requests.Clear();

            for (Tact = 1; Tact < ExecutionTime; Tact++)
            {
                var state = GetCurrentStateOfSystem();
                UpdateStates(state);

                foreach (IComponent component in Components)
                {
                    component.Process();
                }

                Requests.ForEach(x => x.TactsPassed());
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
                    Times = 0
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
