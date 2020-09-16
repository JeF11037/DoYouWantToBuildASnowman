using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DoYouWantToBuildASnowman
{
    public partial class MainPage : ContentPage
    {
        int mainphase;
        bool mainphasecomplete = false;
        int secphase;

        double value = 12.0;

        Random rnd = new Random();

        public MainPage()
        {
            InitializeComponent();
            MainActivity();
        }

        private async void FaceAnimation()
        {
            if (!mainphasecomplete) { if (temp.Value < 10.0) { mainphase = rnd.Next(3, 6); } else if (temp.Value > 10.0 && temp.Value < 25.0) { mainphase = rnd.Next(2, 4); } else { mainphase = 1; } secphase = 1; mainphasecomplete = true; }

            switch (mainphase)
            {
                case 1:
                    if (secphase == 1) { face.Text = "✖  ✖"; secphase = 2; }
                    else if (secphase == 2) { face.Text = "✖  ✖"; ; secphase = 3; }
                    else if (secphase == 3) { face.Text = "✖  ✖"; secphase = 4; }
                    else if (secphase == 4) { face.Text = "✖  ✖"; secphase = 5; }
                    else if (secphase == 5) { face.Text = "✖  ✖"; mainphasecomplete = false; }
                    break;
                case 2:
                    if (secphase == 1) { face.Text = "◕  ◕"; secphase = 2; }
                    else if (secphase == 2) { face.Text = "◑  ◑"; secphase = 3; }
                    else if (secphase == 3) { face.Text = "◔  ◔"; secphase = 4; }
                    else if (secphase == 4) { face.Text = "◯ ◯"; mainphasecomplete = false; }
                    break;
                case 3:
                    if (secphase == 1) { face.Text = "◕  ◕"; secphase = 2; }
                    else if (secphase == 2) { face.Text = " ◕  ◕"; secphase = 3; }
                    else if (secphase == 3) { face.Text = "  ◕  ◕"; secphase = 4; }
                    else if (secphase == 4) { face.Text = " ◕  ◕"; secphase = 5; }
                    else if (secphase == 5) { face.Text = "◕  ◕"; mainphasecomplete = false; }
                    break;
                case 4:
                    if (secphase == 1) { face.Text = "♡  ♡"; secphase = 2; }
                    else if (secphase == 2) { face.FontSize = 19; secphase = 3; }
                    else if (secphase == 3) { face.FontSize = 20; secphase = 4; }
                    else if (secphase == 4) { face.FontSize = 19; secphase = 5; }
                    else if (secphase == 5) { face.FontSize = 18; mainphasecomplete = false; }
                    break;
                case 5:
                    if (secphase == 1) { face.Text = "^  ^"; secphase = 2; }
                    else if (secphase == 2) { face.Text = "^  ^"; secphase = 3; }
                    else if (secphase == 3) { face.Text = "^  ^"; secphase = 4; }
                    else if (secphase == 4) { face.Text = "^  ^"; secphase = 5; }
                    else if (secphase == 5) { face.Text = "^  ^"; mainphasecomplete = false; }
                    break;
            }
        }

        void CheckTemp()
        {
            if(temp.Value > 25.0) { if (bm.HeightRequest > 0) { bm.HeightRequest -= 10; } } else { if(bm.HeightRequest != 80) { bm.HeightRequest += 10; } }
            if (temp.Value > 27.0) { if (cr.HeightRequest > 0) { cr.HeightRequest -= 10; } } else { if (cr.HeightRequest != 60) { cr.HeightRequest += 10; } }
            if (temp.Value > 30.0) { if (tp.HeightRequest > 0) { tp.HeightRequest -= 10; } } else { if (tp.HeightRequest != 40) { tp.HeightRequest += 10; } }
        }

        private async void MainActivity()
        {
            while (true)
            {
                await Task.Delay(300);
                te.Text = Convert.ToString(value) + ":00";
                if (value < 20) { main.Opacity = value / 12; } else { main.Opacity = 12 / value; }

                if (value < 12.0 || value > 20.0) { temp.Value -= rnd.NextDouble(); } else { temp.Value += rnd.NextDouble(); }
                temptext.Text = Convert.ToString(Math.Round(temp.Value, 1)) + "℃";

                FaceAnimation();
                CheckTemp();
            }
        }

        private void time_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double tpvalue = e.NewValue;
            value = tpvalue;
        }
    }
}
