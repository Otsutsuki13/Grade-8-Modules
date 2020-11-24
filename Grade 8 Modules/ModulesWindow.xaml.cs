using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Threading;

namespace Grade_8_Modules
{
    /// <summary>
    /// Interaction logic for ModulesWindow.xaml
    /// </summary>
    public partial class ModulesWindow : Window
    {
        DispatcherTimer Timer = new DispatcherTimer();
        public ModulesWindow()
        {
            InitializeComponent();
        }
        private void AnimationLoad()
        {
            DoubleAnimation da = new DoubleAnimation();
            da.Duration = TimeSpan.FromSeconds(1);
            da.From = 0;
            da.To = 364;
            Anime.BeginAnimation(HeightProperty, da);
            DoubleAnimation ad = new DoubleAnimation();
            ad.Duration = TimeSpan.FromSeconds(1);
            ad.From = 0;
            ad.To = 800;
            Anime.BeginAnimation(WidthProperty, ad);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.Duration = TimeSpan.FromSeconds(.5);
            da.From = 364;
            da.To = 0;
            Anime.BeginAnimation(HeightProperty, da);

            var timer1 = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer1.Start();
            timer1.Tick += (obj, args) =>
            {
                timer1.Stop();
            };

            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 1);
            Timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Stop();

            var timer1 = new DispatcherTimer { Interval = TimeSpan.FromSeconds(.5) };
            timer1.Start();
            timer1.Tick += (obj, args) =>
            {
                timer1.Stop();
                Environment.Exit(0);
                Application.Current.Shutdown();
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AnimationLoad();
        }
    }
}
