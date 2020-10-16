using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SAaCSimLabs.Lab4
{
    class MassServiceSystem
    {
        private readonly Random _rndRequestsArrival = new Random(); 
        private readonly Random _rndProcessingTime = new Random();

        private Queue<Request> Queue { get; set; }
        private List<Channel> Channels { get; set; }

        public int Hours { get; set; }
        public int ChannelsCount { get; set; }
        public int QueueSize { get; set; } 
        public int RequestsPerHour { get; set; }
        public double AvgRequestServiceTime { get; set; }
        public double RequestWorth { get; set; }
        public double ChannelFee { get; set; }
        public double QueueFee { get; set; }
        
        public List<Request> Requests { get; }
        public double PureProfit { get; private set; }

        public MassServiceSystem(int hours, int requestsPerHour, double avgRequestServiceTime, double requestWorth, 
        	double channelFee, int channels, int queueSize = 0, double queueFee = 0)
        {
            Hours = hours;
            RequestsPerHour = requestsPerHour;
            AvgRequestServiceTime = avgRequestServiceTime;
            RequestWorth = requestWorth;
            ChannelFee = channelFee;
            ChannelsCount = channels;
            QueueSize = queueSize;
            QueueFee = queueFee;

            Requests = new List<Request>();
            Channels = new List<Channel>();
            Queue = new Queue<Request>();
        }

        /// <summary>
        /// Start system
        /// </summary>
        public void Start()
        {
            Requests.Clear();
            Channels.Clear();
            Queue.Clear();

            for (int i = 0; i < ChannelsCount; i++)
            {
                Channels.Add(new Channel());
            }

            // First request creation
            int currentMinute = 0;
            Request generatedRequest = GenerateRequest(currentMinute);
            
            // Stepping by minutes 
            while (currentMinute < Hours * 60)
            {
                // Find channel that will first finish processing request
                Channel nextFreeChannel = GetNextFreeChannel();

                if (generatedRequest.ArrivalTime > nextFreeChannel.FinishProcessingTime)
                {
                    // if channel finish sooner than request will arrive 
                    // than we move to channel's finish processing time
                    currentMinute = nextFreeChannel.FinishProcessingTime.Value;
                    nextFreeChannel.FinishProcessing();

                    // if there are something in queue
                    if (Queue.Count > 0)
                    {
                        // add this to freed channel
                        nextFreeChannel.ProcessRequest(Queue.Dequeue(), currentMinute);
                    }
                }
                else
                {
                    // other possibillity is request will arrive sooner 
                    // than channel finish processing in that  case
                    // 1. move to request arrival time

                    currentMinute = generatedRequest.ArrivalTime;
                    Channel freeChannel = GetFreeChannel();

                    // 2. check if any channel is free
                    if (freeChannel != null)
                    {
                        // if there are free channels and queue is empty
                        if (Queue.Count == 0)
                        {
                            // move request to channel
                            freeChannel.ProcessRequest(generatedRequest, currentMinute);
                        }
                        else
                        {
                            // move request from queue to channel
                            // and 
                            // move arrived request to queue
                            freeChannel.ProcessRequest(Queue.Dequeue(), currentMinute);
                            TryEnqueue(generatedRequest);
                        }
                    }
                    else
                    {
                        // no free channel = try add to queue
                        TryEnqueue(generatedRequest);
                    }

                    generatedRequest = GenerateRequest(currentMinute);
                }
            }

            // Calc statistics 
            double queueFee = QueueFee * QueueSize * Hours;
            double channelsFee = ChannelFee * ChannelsCount * Hours;

            PureProfit = Channels.Sum(channel => channel.Profit) - queueFee - channelsFee;
        }

        /// <summary>
        /// Try adding request in queue 
        /// if queue is full or there is no queue at all
        /// discard request
        /// </summary>
        /// <param name="request">Request to enqueue</param>
        private void TryEnqueue(Request request)
        {
            if (QueueSize > Queue.Count)
            {
                Queue.Enqueue(request);
            }
            else
            {
                request.State = RequestState.Discarded;
            }
        }

        /// <summary>
        /// Get channel that currently NOT processing any request
        /// </summary>
        /// <returns>Free channel</returns>
        private Channel GetFreeChannel()
        {
            return Channels.FirstOrDefault(channel => channel.ProcessingRequest == null);
        }


        /// <summary>
        /// Get channel that will process his request first
        /// </summary>
        /// <returns>First channel to free</returns>
        private Channel GetNextFreeChannel()
        {
            Channel nextFreeChannel = Channels[0];

            foreach(Channel channel in Channels)
            {
                if (nextFreeChannel.FinishProcessingTime > channel.FinishProcessingTime)
                {
                    nextFreeChannel = channel;
                }
            }

            return nextFreeChannel;
        }

        /// <summary>
        /// Generate request
        /// AKA
        /// Calc next request arrival time
        /// </summary>
        /// <param name="currentMinute">System current minute</param>
        /// <returns>Generated request</returns>
        private Request GenerateRequest(int currentMinute)
        {
            int minutesToProcess = CalculateProcessingTime();
            int timeOfArrival = CalculteArrivingTime() + currentMinute;
            Request request = new Request(timeOfArrival, minutesToProcess, RequestWorth);
            Requests.Add(request);

            return request;
        }

        /// <summary>
        /// Calc request minutes to arrive
        /// </summary>
        /// <returns>Minutes for request arrival</returns>
        private int CalculteArrivingTime()
        {
            double processingTime = -1/(double)RequestsPerHour * Math.Log(_rndRequestsArrival.NextDouble());

            return (int)(processingTime * 60);
        }

        /// <summary>
        /// Calc request processing time
        /// </summary>
        /// <returns>Minutes for request to process</returns>
        private int CalculateProcessingTime()
        {
            double processingTime = -AvgRequestServiceTime * Math.Log(_rndProcessingTime.NextDouble());

            return (int)(processingTime * 60);
        }
    }
}
