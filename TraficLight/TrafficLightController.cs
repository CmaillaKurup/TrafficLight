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


        public void TurnLightOn()
        {
            TrafficLight tl = new TrafficLight(true, false, false);

            while (true)
            {
                LightChanged?.Invoke(this, new TrafficLightEventArgs(tl));

                if (tl.red == true)
                {
                    Thread.Sleep(1000);

                    tl.yellow = true;
                    //tl.red = false;
                }
                else if (tl.yellow == true)
                {                   
                    Thread.Sleep(1000);

                    tl.green = true;
                    //tl.yellow = false;
                }
                else if (tl.green == true)
                {
                    Thread.Sleep(1000);

                    tl.red = true;
                    //tl.green = false;
                    
                }
                else
                {
                    tl.red = false;
                    tl.yellow = false;
                    tl.green = false;
                }
            }
        }
    }
}