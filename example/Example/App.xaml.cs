using System;
using Example.Features.Main;
using FutureFlag;
using NodaTime;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Example
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            
            FutureFlagConfiguration.Configure(config =>
            {
                // here you can override how your application will acquire "Now"
                // using nodatime to acquire "Now"
                config.NowProvider(GetNodaNow); 
                
                // here you can override how your application will acquire "UtcNow"
                // using nodatime to acquire "UtcNow"
                config.UtcNowProvider(GetNodaUtcNow); 
            });
            
            MainPage = new MainPage();
        }

        private DateTime GetNodaUtcNow() 
            => SystemClock.Instance.GetCurrentInstant().ToDateTimeUtc();

        private DateTime GetNodaNow() 
            => SystemClock.Instance.GetCurrentInstant().ToDateTimeUtc().ToLocalTime();
    }
}