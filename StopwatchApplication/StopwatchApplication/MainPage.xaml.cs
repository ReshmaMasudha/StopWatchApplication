using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StopwatchApplication
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Stopwatch stopwatch;
        public MainPage()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            stopwatch.Reset();
            StopWatchLabel.Text = "00:00:00";

        }

        private void ButtonStart_Clicked(object sender, EventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                        StopWatchLabel.Text = stopwatch.Elapsed.ToString());

                    if (!stopwatch.IsRunning)
                        return false;
                    else
                        return true;

                });
            }
        }

        private void ButtonStop_Clicked(object sender, EventArgs e)
        {
            this.ButtonStart.Text = "Resume";
            stopwatch.Stop();
        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            this.ButtonStart.Text = "Start";
            StopWatchLabel.Text = "00:00:00";
            stopwatch.Reset();
        }
    }
}
