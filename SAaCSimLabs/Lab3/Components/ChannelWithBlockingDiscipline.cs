using System.Linq;

namespace SAaCSimLabs.Lab3.Components
{
    class ChannelWithBlockingDiscipline : Channel
    {
        /// <summary>
        /// State of channel
        /// 2 - Channel is blocked;
        /// 1 - Processing request;
        /// 0 - Free channel
        /// </summary>
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

        /// <summary>
        /// How many tacts this channel was blocked
        /// </summary>
        public int TactsChannelBlocked { get; set; }

        /// <summary>
        /// Create channel with blocking discipline
        /// </summary>
        /// <param name="id">Unique identifier of channel</param>
        /// <param name="positionInStruct">Position in system</param>
        /// <param name="π">Probability of not processing a request</param>
        public ChannelWithBlockingDiscipline(int id, int positionInStruct, double π) 
            : base(id, positionInStruct, π)
        {
            MaxProbabilityState = 2;
        }

        /// <summary>
        /// Process request
        /// </summary>
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

                if (ProcessingRequest != null && ProcessingRequest.State == RequestState.Pending)
                {
                    TactsChannelBlocked++;
                }
            }
        }
    }
}
