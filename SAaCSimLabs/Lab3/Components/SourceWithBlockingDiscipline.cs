using System.Linq;

namespace SAaCSimLabs.Lab3.Components
{
    class SourceWithBlockingDiscipline : Source
    {

        /// <summary>
        /// State of source
        /// 0 - Blocked;
        /// 1 - generating if not fixed time;
        /// Tacts before request generates if fixed time
        /// </summary>
        public override int CurrentState 
        {
            get
            {
                if (ProcessingRequest != null)
                {
                    return 0;
                }

                if (_fixedTime != null)
                {
                    return tactWorked % _fixedTime.Value;
                }

                return 1;
            }
        }

        /// <summary>
        /// How many tacts this source was blocked
        /// </summary>
        public int TactsSourceBlocked { get; set; }

        /// <summary>
        /// Create fixed time source with blocking discipline
        /// </summary>
        /// <param name="id">Unique identifier of source</param>
        /// <param name="mSS">System in which this source works</param>
        /// <param name="positionInStruct">Position in system</param>
        /// <param name="fixedTime">Tacts before request generates</param>
        public SourceWithBlockingDiscipline(int id, MassServiceSystem mSS, int positionInStruct, int fixedTime)
            : base(id, mSS, positionInStruct, fixedTime)
        {
            MaxProbabilityState = fixedTime;
        }

        /// <summary>
        /// Create filtering source with blocking discipline
        /// </summary>
        /// <param name="id">Unique identifier of source</param>
        /// <param name="mSS">System in which this source works</param>
        /// <param name="positionInStruct">Position in system</param>
        /// <param name="ρ">Probability of not generating a request</param>
        public SourceWithBlockingDiscipline(int id, MassServiceSystem mSS, int positionInStruct, double ρ)
            : base(id, mSS, positionInStruct, ρ)
        {
            MaxProbabilityState = 1;
        }

        /// <summary>
        /// Generates requests
        /// </summary>
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

                if (ProcessingRequest != null && ProcessingRequest.State == RequestState.Pending)
                {
                    TactsSourceBlocked++;
                }
            }
        }
    }
}
