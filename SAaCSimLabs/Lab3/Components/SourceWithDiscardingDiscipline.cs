using System.Linq;

namespace SAaCSimLabs.Lab3.Components
{
    class SourceWithDiscardingDiscipline : Source
    {
        /// <summary>
        /// State of source
        /// 0 if not fixed time (always generating);
        /// Tacts before request generates if fixed time
        /// </summary>
        public override int CurrentState 
        { 
            get
            {
                if (_fixedTime == null)
                {
                    return 0;
                }

                return tactsBeforeRequest;
            } 
        }

        /// <summary>
        /// Create filtering source with discarding discipline
        /// </summary>
        /// <param name="id">Unique identifier of source</param>
        /// <param name="mSS">System in which this source works</param>
        /// <param name="positionInStruct">Position in system</param>
        /// <param name="ρ">Probability of not generating a request</param>
        public SourceWithDiscardingDiscipline(int id, MassServiceSystem mSS, int positionInStruct, double ρ)
            : base(id, mSS, positionInStruct, ρ)
        {
            MaxProbabilityState = 0;
        }

        /// <summary>
        /// Create fixed time source with discarding discipline
        /// </summary>
        /// <param name="id">Unique identifier of source</param>
        /// <param name="mSS">System in which this source works</param>
        /// <param name="positionInStruct">Position in system</param>
        /// <param name="fixedTime">Tacts before request generates</param>
        public SourceWithDiscardingDiscipline(int id, MassServiceSystem mSS, int positionInStruct, int fixedTime)
            : base(id, mSS, positionInStruct, fixedTime)
        {
            MaxProbabilityState = fixedTime - 1;
        }

        /// <summary>
        /// Generates requests
        /// </summary>
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
