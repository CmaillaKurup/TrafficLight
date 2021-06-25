using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TraficLight
{
    class TrafficLightController
    {
        public event EventHandler LightChanged;
        public TrafficLightController()
        {
            Thread trafficLight = new Thread(TurnLightOn);
            trafficLight.Start();
        }

        TrafficLight tl = new TrafficLight(false, false, false);

        public void TurnLightOn()
        {
            while (true)
            {
                if (tl.red != true)
                {
                    tl.red = true;
                    Thread.Sleep(5000);
                    LightChanged?.Invoke(this, new TrafficLightEventArgs(tl));
                    tl.red = false;
                }
                if (tl.yellow != true)
                {
                    tl.yellow = true;
                    Thread.Sleep(5000);
                    LightChanged?.Invoke(this, new TrafficLightEventArgs(tl));
                    tl.yellow = false;
                }
                if (tl.green != true)
                {
                    tl.green = true;
                    Thread.Sleep(1000);
                    LightChanged?.Invoke(this, new TrafficLightEventArgs(tl));
                    tl.green = false;
                }
            }
        }
        
        public void TurnLightOff(TrafficLight t)
        {
            if (t.red)
            {
                tl.green = false;
                tl.yellow = false;
                LightChanged?.Invoke(this, new TrafficLightEventArgs(tl));
            }
            if (t.yellow)
            {
                tl.red = false;
                tl.green = false;
                LightChanged?.Invoke(this, new TrafficLightEventArgs(tl));
            }
            if (t.green)
            {
                tl.red = false;
                tl.yellow = false;
                LightChanged?.Invoke(this, new TrafficLightEventArgs(tl));
            }
        }       
    }
}