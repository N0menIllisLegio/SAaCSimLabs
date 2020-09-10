using System;

namespace SAaCSimLabs.Lab3.Components
{
    class Channel : IComponent
    {
        protected readonly Random _rnd;
        protected double _π;

        public IComponent[] NextComponents { get; set; }
        public int PositionInStruct { get; set; }
        public Request ProcessingRequest { get; set; }

        public Channel(int positionInStruct, double π)
        {
            PositionInStruct = positionInStruct;
            _π = π;

            ProcessingRequest = null;
            _rnd = new Random();
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
