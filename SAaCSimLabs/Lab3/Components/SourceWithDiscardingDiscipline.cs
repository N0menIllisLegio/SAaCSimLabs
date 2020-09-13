using System.Linq;

namespace SAaCSimLabs.Lab3.Components
{
    class SourceWithDiscardingDiscipline : Source
    {
        public override int CurrentState 
        { 
            get
            {
                if (_fixedTime == null)
                {
                    return 0;
                }

                return tactWorked % _fixedTime.Value;
            } 
        }

        public SourceWithDiscardingDiscipline(MassServiceSystem mSS, int positionInStruct, double ρ)
            : base(mSS, positionInStruct, ρ)
        {
            // Its just generating
            MaxProbabilityState = 0;
        }

        public SourceWithDiscardingDiscipline(MassServiceSystem mSS, int positionInStruct, int fixedTime)
            : base(mSS, positionInStruct, fixedTime)
        {
            // int time = fixedTime
            // 0 - here you cant block request will discard | -1 ? 
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
