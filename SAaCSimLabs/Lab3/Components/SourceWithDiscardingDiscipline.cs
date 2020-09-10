using System.Linq;

namespace SAaCSimLabs.Lab3.Components
{
    class SourceWithDiscardingDiscipline : Source
    {
        public SourceWithDiscardingDiscipline(MassServiceSystem mSS, int positionInStruct, double ρ)
            : base(mSS, positionInStruct, ρ)
        {
            // Its just generating
            MaxProbabilityState = 0;
        }

        public SourceWithDiscardingDiscipline(MassServiceSystem mSS, int positionInStruct, int fixedTime)
            : base(mSS, positionInStruct, fixedTime)
        {
            // 0 - is blocking, and here you cant block request will discard
            MaxProbabilityState = fixedTime - 1;
        }

        public override void Process()
        {
            if (RequestCreated())
            {
                Request request = new Request {CreationTact = _massServiceSystem.Tact, ExistingTime = 0};
                IComponent nextComponent =
                    NextComponents.FirstOrDefault(component => component.ProcessingRequest == null);

                if (nextComponent == null)
                {
                    request.State = RequestState.Discarded;
                }
                else
                {
                    request.State = RequestState.Processing;
                    nextComponent.ProcessingRequest = request;
                }

                _massServiceSystem.Requests.Add(request);
            }
        }
    }
}
