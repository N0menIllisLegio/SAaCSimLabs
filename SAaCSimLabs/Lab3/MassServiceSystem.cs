using SAaCSimLabs.Lab3.Components;
using System.Collections.Generic;
using System.Linq;

namespace SAaCSimLabs.Lab3
{
    class MassServiceSystem
    {
        public int ExecutionTime { get; set; }
        public List<Request> Requests { get; }

        // Start from 1 not from 0
        public int Tact { get; private set; }
        public IComponent[] Components { get; private set; }



        public MassServiceSystem(int executionTime)
        {
            Requests = new List<Request>();
            ExecutionTime = executionTime;
        }

        public void SetComponents(params IComponent[] components)
        {
            LinkComponents(components);
            Components = components.OrderByDescending(component => component.PositionInStruct).ToArray();
        }

        public void Execute()
        {
            Requests.Clear();

            for (Tact = 1; Tact < ExecutionTime; Tact++)
            {
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
    }
}
