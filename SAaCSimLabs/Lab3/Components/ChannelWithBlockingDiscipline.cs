using System.Linq;

namespace SAaCSimLabs.Lab3.Components
{
    class ChannelWithBlockingDiscipline : Channel
    {
        public override int CurrentState 
        {
            get
            {
                if (ProcessingRequest == null)
                {
                    return 0;
                }

                if (ProcessingRequest.State == RequestState.Processing)
                {
                    return 1;
                }

                return 2;
            }
        }

        public ChannelWithBlockingDiscipline(int positionInStruct, double π) : base(positionInStruct, π)
        {
            // 0 - no requests, 1 - one request, 2 - blocked
            MaxProbabilityState = 2;
        }

        public override void Process()
        {
            if (ProcessingRequest != null && (ProcessingRequest.State == RequestState.Pending || RequestProcessed()))
            {
                IComponent nextComponent = NextComponents.FirstOrDefault(component => component.ProcessingRequest == null);

                if (nextComponent == null)
                {
                    ProcessingRequest.State = RequestState.Pending;
                }
                else
                {
                    ProcessingRequest.State = RequestState.Processing;
                    nextComponent.ProcessingRequest = ProcessingRequest;
                    ProcessingRequest = null;
                }
            }
        }
    }
}
