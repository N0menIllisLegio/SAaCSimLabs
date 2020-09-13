namespace SAaCSimLabs.Lab3
{
    enum RequestState
    {
        Discarded,
        Processing,
        Pending,
        Completed,
    }

    class Request
    {
        public RequestState State;
        public int ExistingTime;
        public int TimeInQueue;
        public int CreationTact;

        public void TactsPassed(int ticks = 1)
        {
            if (State == RequestState.Processing || State == RequestState.Pending)
            {
                ExistingTime = ExistingTime + ticks;
            }
        }
    }
}
