namespace SAaCSimLabs.Lab3.Components
{
    interface IComponent
    {
        public int CurrentState { get; }
        public int MaxProbabilityState { get; set; }
        public IComponent[] NextComponents { get; set; }
        public int PositionInStruct { get; set; }
        public Request ProcessingRequest { get; set; }
        public void Process();
    }
}
