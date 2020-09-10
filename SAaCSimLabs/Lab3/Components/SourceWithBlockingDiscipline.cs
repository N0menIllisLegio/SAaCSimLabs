using System.Linq;

namespace SAaCSimLabs.Lab3.Components
{
    class SourceWithBlockingDiscipline : Source
    {
        /// <summary>
        /// Constructor for sources with fixed time.
        /// </summary>
        /// <param name="positionInStruct">Position in structure (in struct with parallel elements, this elements will have same Position)</param>
        /// <param name="fixedTime">Fixed time of request to appear</param>
        public SourceWithBlockingDiscipline(MassServiceSystem mSS, int positionInStruct, int fixedTime) 
            : base(mSS, positionInStruct, fixedTime)
        { }

        /// <summary>
        /// Constructor for channels and sources with probability of filtering and appearing
        /// </summary>
        /// <param name="positionInStruct">Position in structure (in struct with parallel elements, this elements will have same Position)</param>
        /// <param name="ρ">Value ρ for source or π for channel</param>
        public SourceWithBlockingDiscipline(MassServiceSystem mSS, int positionInStruct, double ρ)
            : base(mSS, positionInStruct, ρ)
        { }

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
