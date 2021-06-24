using System;
using System.Collections.Generic;
using System.Text;

namespace TraficLight 
{
    class TrafficLightEventArgs : EventArgs
    {
        public TrafficLight on { get; set; }

        public TrafficLightEventArgs(TrafficLight on)
        {
            this.on = on;
        }
    }
}