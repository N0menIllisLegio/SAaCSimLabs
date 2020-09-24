using System;

namespace SAaCSimLabs.Lab3.Components
{
    class Channel : IComponent
    {
        protected readonly Random _rnd = new Random();

        /// <summary>
        /// Probability of not processing a request
        /// </summary>
        private readonly double _π;

        /// <summary>
        /// Unique identifier of channel
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// State of channel
        /// 1 - Processing request;
        /// 0 - Free channel
        /// </summary>
        public virtual int CurrentState => ProcessingRequest != null ? 1 : 0;

        public int MaxProbabilityState { get; set; }
        public IComponent[] NextComponents { get; set; }
        public int PositionInStruct { get; set; }
        public Request ProcessingRequest { get; set; }

        /// <summary>
        /// How many tacts this channel was processing requests
        /// </summary>
        public int TactsChannelProcessed { get; set; }

        /// <summary>
        /// Create final channel
        /// </summary>
        /// <param name="id">Unique identifier of channel</param>
        /// <param name="positionInStruct">Position in system</param>
        /// <param name="π">Probability to NOT process a request</param>
        public Channel(int id, int positionInStruct, double π)
        {
            _id = id;
            PositionInStruct = positionInStruct;
            _π = π;
            ProcessingRequest = null;
            MaxProbabilityState = 1;
        }

        /// <summary>
        /// Process request
        /// </summary>
        public virtual void Process()
        {
            if (ProcessingRequest != null)
            {
                if (RequestProcessed())
                {
                    ProcessingRequest.State = RequestState.Completed;
                    ProcessingRequest = null;
                }
            }
        }

        /// <summary>
        /// Tries to process request
        /// </summary>
        /// <returns>True - request processed, otherwise - false</returns>
        protected bool RequestProcessed()
        {
            TactsChannelProcessed++;

            return _rnd.NextDouble() > _π;
        }

        public override string ToString()
        {
            return $"Id: {_id}, π: {_π}";
        }
    }
}
