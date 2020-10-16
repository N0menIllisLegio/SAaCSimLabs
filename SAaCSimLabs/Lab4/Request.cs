namespace SAaCSimLabs.Lab4
{
    enum RequestState
    {
        Created,
        Discarded,
        InQueue,
        Processing,
        Completed
    }

    class Request
    {
        public int ArrivalTime { get; }
        public int MinutesToProcess { get; set; }
        public RequestState State { get; set; }
        public double Worth { get; }

        public Request(int arrivalTime, int processTime, double worth)
        {
            ArrivalTime = arrivalTime;
            State = RequestState.Created;
            Worth = worth;
            MinutesToProcess = processTime;
        }
    }
}
