using System;

namespace SAaCSimLabs.Lab3.Components
{
    abstract class Source : IComponent
    {
        protected readonly Random _rnd = new Random();
        protected readonly double _ρ;
        protected readonly int? _fixedTime;
        protected int tactWorked;
        protected readonly MassServiceSystem _massServiceSystem;

        public int MaxProbabilityState { get; set; }
        public IComponent[] NextComponents { get; set; }
        public int PositionInStruct { get; set; }
        public Request ProcessingRequest { get; set; }


        protected Source(MassServiceSystem mSS, int positionInStruct, double ρ)
        {
            _ρ = ρ;
            PositionInStruct = positionInStruct;
            _massServiceSystem = mSS;
        }

        protected Source(MassServiceSystem mSS, int positionInStruct, int fixedTime)
        {
            _fixedTime = fixedTime;
            PositionInStruct = positionInStruct;
            _massServiceSystem = mSS;
        }
            
        protected bool RequestCreated()
        {
            if (_fixedTime != null)
            {
                tactWorked++;
                return tactWorked % _fixedTime.Value == 0;
            }

            return _rnd.NextDouble() > _ρ;
        }

        public abstract void Process();
    }
}
