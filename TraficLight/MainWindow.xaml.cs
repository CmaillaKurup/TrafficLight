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

        private void TrafficLightController(object sender, EventArgs e)
        {
            if (e is TrafficLightEventArgs)
            {
                    TurnOff(e);

                if (((TrafficLightEventArgs)e).on.red)
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Red.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    }));
                }
                if (((TrafficLightEventArgs)e).on.yellow)
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Yellow.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                    }));
                }
                if (((TrafficLightEventArgs)e).on.green)
                {
                  
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Green.Fill = new SolidColorBrush(Color.FromRgb(0, 128, 0));
                    }));
                }
            }
        }
        
        private void TurnOff(EventArgs e)
        {
            if (((TrafficLightEventArgs)e).on.Equals(true))
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Red.Fill = new SolidColorBrush(Color.FromRgb(255, 34, 1));
                }));

                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Yellow.Fill = new SolidColorBrush(Color.FromRgb(255, 62, 68));
                }));

                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Green.Fill = new SolidColorBrush(Color.FromRgb(255, 20, 27));
                }));
            }
            
            /*
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                Red.Fill = new SolidColorBrush(Color.FromRgb(255, 34, 1));
                Yellow.Fill = new SolidColorBrush(Color.FromRgb(255, 62, 68));
                Green.Fill = new SolidColorBrush(Color.FromRgb(255, 20, 27));
            }));
            */
        }
    }
}
