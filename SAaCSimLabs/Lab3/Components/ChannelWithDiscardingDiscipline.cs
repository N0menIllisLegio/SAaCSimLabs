using System.Linq;

namespace SAaCSimLabs.Lab3.Components
{
    class ChannelWithDiscardingDiscipline : Channel
    {
        public ChannelWithDiscardingDiscipline(int positionInStruct, double π) : base(positionInStruct, π)
        { }

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
