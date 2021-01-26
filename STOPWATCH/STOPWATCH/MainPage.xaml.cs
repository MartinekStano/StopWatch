using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace STOPWATCH
{
    public partial class MainPage : ContentPage
    {
        Stopwatch stopWatch;
        public MainPage()
        {
            InitializeComponent();
            stopWatch = new Stopwatch();

            lblStopWatch.Text = "00:00:00:0000";
        }

        private void buttonStart_Clicked(object sender, EventArgs e)
        {
            if(!stopWatch.IsRunning)
            { 
            stopWatch.Start();

            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                lblStopWatch.Text = stopWatch.Elapsed.ToString();
                if(!stopWatch.IsRunning)
                { 
                return false;
                }
                else
                {
                    return true;
                }
            }
            );
            }
        }

        private void buttonReset_Clicked(object sender, EventArgs e)
        {
            lblStopWatch.Text = "00:00:00:0000";
            buttonStart.Text = "Start";
            stopWatch.Reset();

        }

        private void buttonStop_Clicked(object sender, EventArgs e )
        {
            buttonStart.Text = "Resume";
            stopWatch.Stop();
        }
    }
}
