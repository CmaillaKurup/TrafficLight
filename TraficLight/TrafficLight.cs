using System;
using System.Collections.Generic;
using System.Text;

namespace TraficLight
{
    //this class is my lights 
    class TrafficLight
    {
        public bool red { get; set; }
        public bool yellow { get; set; }

        public bool green { get; set; }

        public TrafficLight(bool red, bool yellow, bool green)
        {
            this.red = red;
            this.yellow = yellow;
            this.green = green;
        }
    }
}
