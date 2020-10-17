using System;

namespace SAaCSimLabs.Lab3.Components
{
    abstract class Source : IComponent
    {
        /// <summary>
        /// Unique identifier of source
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Probability of not generating a request
        /// </summary>
        private readonly double _ρ;

        /// <summary>
        /// Tacts to generate request
        /// </summary>
        protected readonly int? _fixedTime;

        /// <summary>
        /// Tacts before component generate request
        /// </summary>
        protected int tactsBeforeRequest;

        /// <summary>
        /// System in which this component works
        /// </summary>
        protected readonly MassServiceSystem _massServiceSystem;
        protected readonly Random _rnd = new Random();

        public virtual int CurrentState { get; }
        public int MaxProbabilityState { get; set; }
        public IComponent[] NextComponents { get; set; }
        public int PositionInStruct { get; set; }
        public Request ProcessingRequest { get; set; }

        protected Source(int id, MassServiceSystem mSS, int positionInStruct, double ρ)
        {
            _id = id;
            _ρ = ρ;
            PositionInStruct = positionInStruct;
            _massServiceSystem = mSS;
        }

        protected Source(int id, MassServiceSystem mSS, int positionInStruct, int fixedTime)
        {
            _id = id;
            _fixedTime = fixedTime;
            PositionInStruct = positionInStruct;
            _massServiceSystem = mSS;
            tactsBeforeRequest = fixedTime;
        }

        /// <summary>
        /// Tries to create request
        /// </summary>
        /// <returns>True - request created, otherwise - false</returns>
        protected bool RequestCreated()
        {
            if (_fixedTime != null)
            {
                if (--tactsBeforeRequest == 0)
                {
                    tactsBeforeRequest = _fixedTime.Value;
                    return true;
                }

                return false;
            }

            return _rnd.NextDouble() > _ρ;
        }

        /// <summary>
        /// Generates requests
        /// </summary>
        public abstract void Process();

        public override string ToString()
        {
            string output;

            if (_fixedTime != null)
            {
                output = $"Id: {_id}, Fixed time: {_fixedTime.Value}";
            }
            else
            {
                output = $"Id: {_id}, ρ: {_ρ}";
            }

            return output;
        }
    }
}
