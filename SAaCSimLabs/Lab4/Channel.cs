namespace SAaCSimLabs.Lab4
{
    class Channel
    {
        /// <summary>
        /// Channel profit
        /// </summary>
        public double Profit { get; private set; }

        /// <summary>
        /// When request will finish processing
        /// </summary>
        public int? FinishProcessingTime { get; private set; }

        /// <summary>
        /// Processing request
        /// </summary>
        public Request ProcessingRequest { get; private set; }

        public Channel()
        {
            ProcessingRequest = null;
            FinishProcessingTime = null;
        }

        /// <summary>
        /// Add request in channel for processing
        /// </summary>
        /// <param name="request">Request for processing</param>
        /// <param name="currentMinute">Current minute of system</param>
        public void ProcessRequest(Request request, int currentMinute)
        {
            FinishProcessingTime = request.MinutesToProcess + currentMinute;
            ProcessingRequest = request;
            ProcessingRequest.State = RequestState.Processing;
        }

        /// <summary>
        /// Call when FinishProcessingTime < system's time
        /// </summary>
        public void FinishProcessing()
        {
            if (ProcessingRequest != null)
            {
                Profit += ProcessingRequest.Worth;

                ProcessingRequest.State = RequestState.Completed;
                ProcessingRequest = null;

                FinishProcessingTime = null;
            }
        }
    }
}
