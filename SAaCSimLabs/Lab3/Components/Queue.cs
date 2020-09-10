using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SAaCSimLabs.Lab3.Components
{
    class Queue : IComponent
    {
        private readonly int _queueSize;
        private Request _processingRequest;
        public int MaxProbabilityState { get; set; }
        public IComponent[] NextComponents { get; set; }
        public int PositionInStruct { get; set; }
        public System.Collections.Generic.Queue<Request> RequestsQueue { get; set; }

        public Request ProcessingRequest
        {
            get => _processingRequest;
            set
            {
                bool requestPassedToNextProcess = false;

                if (RequestsQueue.Count == 0)
                {
                    IComponent nextComponent =
                        NextComponents.FirstOrDefault(component => component.ProcessingRequest == null);

                    if (nextComponent != null)
                    {
                        requestPassedToNextProcess = true;
                        nextComponent.ProcessingRequest = value;
                        _processingRequest = null;
                    }
                }

                if (!requestPassedToNextProcess)
                {
                    if (RequestsQueue.Count == _queueSize)
                    {
                        _processingRequest = value;
                    }
                    else
                    {
                        if (RequestsQueue.Count < _queueSize)
                        {
                            RequestsQueue.Enqueue(value);
                            _processingRequest = null;
                        }
                        else
                        {
                            throw new ConstraintException($"Somehow queue is overflowed (Max = {_queueSize}, Current = {RequestsQueue.Count})");
                        }
                    }
                }
            } 
        }

        public Queue(int positionInStruct, int queueSize)
        {
            PositionInStruct = positionInStruct;
            RequestsQueue = new Queue<Request>();
            // One last element stored in ProcessingRequest
            _queueSize = queueSize - 1;
            
            MaxProbabilityState = queueSize;
        }

        public void Process()
        {
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
    }
}
