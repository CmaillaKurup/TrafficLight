using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TraficLight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TrafficLightController tl = new TrafficLightController();
            tl.LightChanged += TrafficLightController;
        }

        //here I tell the application what to do in the event when a new event is taking place
        private void TrafficLightController(object sender, EventArgs e)
        {
            if (e is TrafficLightEventArgs)
            {
                if (((TrafficLightEventArgs)e).trafficLight.red)
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Red.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        Yellow.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 0));
                        Green.Fill = new SolidColorBrush(Color.FromRgb(0, 128, 0));
                    }));
                }
                if (((TrafficLightEventArgs)e).trafficLight.yellow)
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Yellow.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                        Red.Fill = new SolidColorBrush(Color.FromRgb(139, 0, 0));
                        Green.Fill = new SolidColorBrush(Color.FromRgb(0, 128, 0));
                    }));
                }
                if (((TrafficLightEventArgs)e).trafficLight.green)
                {  
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Green.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                        Red.Fill = new SolidColorBrush(Color.FromRgb(139, 0, 0));
                        Yellow.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 0));
                    }));
                }
            }
        }
    }
}
