using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SAaCSimLabs.Lab3.Components
{
    class Queue : IComponent
    {
        /// <summary>
        /// Unique identifier of queue
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Queue size-1, since one last element 
        /// stored in ProcessingRequest
        /// </summary>
        private readonly int _queueSize;

        /// <summary>
        /// Last component in queue
        /// </summary>
        private Request _processingRequest;

        /// <summary>
        /// Queue state = requests in queue
        /// </summary>
        public int CurrentState
        {
            get
            {
                int count = ProcessingRequest != null ? 1 : 0;
                count += RequestsQueue.Count;
                return count;
            }
        }

        public int SumOfSizes { get; private set; }
        public int MaxProbabilityState { get; set; }
        public IComponent[] NextComponents { get; set; }
        public int PositionInStruct { get; set; }

        /// <summary>
        /// Last component of queue
        /// </summary>
        public Request ProcessingRequest
        {
            get => _processingRequest;
            set
            {
                // Request enters queue

                bool requestPassedToNextProcess = false;

                if (RequestsQueue.Count == 0)
                {
                    // Queue is empty
                    IComponent nextComponent =
                        NextComponents.FirstOrDefault(component => component.ProcessingRequest == null);

                    if (nextComponent != null)
                    {
                        // There are empty channels connected
                        // pass request to them
                        requestPassedToNextProcess = true;
                        nextComponent.ProcessingRequest = value;
                        _processingRequest = null;
                    }
                }

                if (!requestPassedToNextProcess)
                {
                    // Queue is empty but all connected channels are busy

                    if (RequestsQueue.Count == _queueSize)
                    {
                        // There are no space in buffer
                        // store request in this props back field
                        _processingRequest = value;
                    }
                    else
                    {
                        // There are space in queue

                        if (RequestsQueue.Count < _queueSize)
                        {
                            // Add request in buffer
                            RequestsQueue.Enqueue(value);
                            _processingRequest = null;
                        }
                        else
                        {
                            // This should never happen
                            throw new ConstraintException($"Somehow queue is overflowed (Max = {_queueSize}, Current = {RequestsQueue.Count})");
                        }
                    }
                }
            } 
        }

        /// <summary>
        /// Queue buffer
        /// </summary>
        public Queue<Request> RequestsQueue { get; set; }

        /// <summary>
        /// Create queue
        /// </summary>
        /// <param name="id">Unique identifier of queue</param>
        /// <param name="positionInStruct">Position in system</param>
        /// <param name="queueSize">Size of queue</param>
        public Queue(int id, int positionInStruct, int queueSize)
        {
            _id = id;
            PositionInStruct = positionInStruct;
            RequestsQueue = new Queue<Request>();
            _queueSize = queueSize - 1;
            
            MaxProbabilityState = queueSize;
        }

        /// <summary>
        /// Try to push requests in connected channels
        /// if there any
        /// </summary>
        public void Process()
        {
            foreach (Request request in RequestsQueue)
            {
                request.TimeInQueue++;
                SumOfSizes++;
            }

            if (ProcessingRequest != null)
            {
                ProcessingRequest.TimeInQueue++;
                SumOfSizes++;
            }


            if (RequestsQueue.Count > 0)
            {
                IComponent nextComponent =
                    NextComponents.FirstOrDefault(component => component.ProcessingRequest == null);

                if (nextComponent != null)
                {
                    nextComponent.ProcessingRequest = RequestsQueue.Dequeue();

                    if (ProcessingRequest != null && RequestsQueue.Count < _queueSize)
                    {
                        RequestsQueue.Enqueue(ProcessingRequest);
                        ProcessingRequest = null;
                    }
                }
            }
            else
            {
                // Happens when queue size is 1 which means ProcessingRequest is queue
                if (ProcessingRequest != null)
                {
                    IComponent nextComponent =
                        NextComponents.FirstOrDefault(component => component.ProcessingRequest == null);

                    if (nextComponent != null)
                    {
                        nextComponent.ProcessingRequest = ProcessingRequest;
                        ProcessingRequest = null;
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"Id: {_id}, Queue size: {_queueSize + 1}";
        }
    }
}
