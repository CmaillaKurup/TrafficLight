using System;
using System.Collections.Generic;
using System.Text;

namespace TraficLight 
{
    class TrafficLightEventArgs : EventArgs
    {
        public TrafficLight trafficLight { get; set; }

        public TrafficLightEventArgs(TrafficLight trafficLight)
        {
            this.trafficLight = trafficLight;
        }
    }
}