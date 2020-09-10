using System;

namespace SAaCSimLabs.Lab3.Components
{
    class Channel : IComponent
    {
        protected readonly Random _rnd = new Random();
        protected double _π;

        public int MaxProbabilityState { get; set; }
        public IComponent[] NextComponents { get; set; }
        public int PositionInStruct { get; set; }
        public Request ProcessingRequest { get; set; }

        public Channel(int positionInStruct, double π)
        {
            PositionInStruct = positionInStruct;
            _π = π;
            ProcessingRequest = null;
            // 0 - Free channel, 1 - Processing request
            MaxProbabilityState = 2;
        }

        public virtual void Process()
        {
            if (ProcessingRequest != null && RequestProcessed())
            {
                ProcessingRequest.State = RequestState.Completed;
                ProcessingRequest = null;
            }
        }

        protected bool RequestProcessed()
        {
            return _rnd.NextDouble() > _π;
        }
    }
}
