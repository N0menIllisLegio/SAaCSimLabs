namespace SAaCSimLabs.Lab3.Components
{
    interface IComponent
    {
        public IComponent[] NextComponents { get; set; }
        public int PositionInStruct { get; set; }
        public Request ProcessingRequest { get; set; }
        public void Process();
    }
}
