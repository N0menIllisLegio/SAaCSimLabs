using System.Linq;

namespace SAaCSimLabs.Lab3.Components
{
    class ChannelWithDiscardingDiscipline : Channel
    {
        public ChannelWithDiscardingDiscipline(int positionInStruct, double π) : base(positionInStruct, π)
        {
            // 0 - no requests, 1 - processing
            MaxProbabilityState = 1;
        }

        public override void Process()
        {
            if (ProcessingRequest != null && RequestProcessed())
            {
                IComponent nextComponent =
                    NextComponents.FirstOrDefault(component => component.ProcessingRequest == null);

                if (nextComponent == null)
                {
                    ProcessingRequest.State = RequestState.Discarded;
                }
                else
                {
                    nextComponent.ProcessingRequest = ProcessingRequest;
                    ProcessingRequest = null;
                }
            }
        }
    }
}
