namespace SAaCSimLabs.Lab3.Components
{
    /// <summary>
    /// Some component of mass service system
    /// </summary>
    interface IComponent
    {
        /// <summary>
        /// Unique identifier of component
        /// </summary>
        // public int Id { get; }

        /// <summary>
        /// Current state of component
        /// For example number of request in queue or 
        /// is channel blocked or pending or generating
        /// </summary>
        public int CurrentState { get; }

        /// <summary>
        /// Used to generate all probabilities (P)
        /// Channel: 0 - Free channel, 1 - Processing request
        /// MaxProbabilityState = 1 
        /// </summary>
        public int MaxProbabilityState { get; set; }

        /// <summary>
        /// Componets that goes after this compoent
        /// (connected to it)
        /// </summary>
        public IComponent[] NextComponents { get; set; }

        /// <summary>
        /// The idea was for parallel channel to have same position
        /// source(0)->queue(1)->channel(2)
        ///                    ->channel(2)
        /// </summary>
        public int PositionInStruct { get; set; }

        /// <summary>
        /// Currently processing request 
        /// </summary>
        public Request ProcessingRequest { get; set; }

        /// <summary>
        /// What component do. 
        /// </summary>
        public void Process();
    }
}
