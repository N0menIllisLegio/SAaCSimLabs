using System.Linq;

namespace SAaCSimLabs.Lab3.Components
{
    class ChannelWithDiscardingDiscipline : Channel
    {
        /// <summary>
        /// Create channel with discarding discipline
        /// </summary>
        /// <param name="id">Unique identifier of channel</param>
        /// <param name="positionInStruct">Position in system</param>
        /// <param name="π">Probability of not processing a request</param>
        public ChannelWithDiscardingDiscipline(int id, int positionInStruct, double π) 
            : base(id, positionInStruct, π) { }

        /// <summary>
        /// Process request
        /// </summary>
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
                }

                ProcessingRequest = null;
            }
        }
    }
}
