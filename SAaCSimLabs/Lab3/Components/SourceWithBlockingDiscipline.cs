using System.Linq;

namespace SAaCSimLabs.Lab3.Components
{
    class SourceWithBlockingDiscipline : Source
    {
        public SourceWithBlockingDiscipline(MassServiceSystem mSS, int positionInStruct, int fixedTime)
            : base(mSS, positionInStruct, fixedTime)
        {
            // 0 - Blocked, 1...fixedTime - Time for request to appear
            MaxProbabilityState = fixedTime;
        }

        public SourceWithBlockingDiscipline(MassServiceSystem mSS, int positionInStruct, double ρ)
            : base(mSS, positionInStruct, ρ)
        {
            // 0 - blocked, 1 - generating
            MaxProbabilityState = 1;
        }

        public override void Process()
        {
            if (ProcessingRequest != null || RequestCreated())
            {
                Request request = ProcessingRequest ?? new Request {CreationTact =  _massServiceSystem.Tact, ExistingTime =  0};
                IComponent nextComponent = NextComponents.FirstOrDefault(component => component.ProcessingRequest == null);

                if (request != ProcessingRequest)
                {
                    _massServiceSystem.Requests.Add(request);
                }

                if (nextComponent == null)
                {
                    request.State = RequestState.Pending;
                    ProcessingRequest = request;
                }
                else
                {
                    request.State = RequestState.Processing;
                    nextComponent.ProcessingRequest = request;
                    ProcessingRequest = null;
                }
            }
        }
    }
}
