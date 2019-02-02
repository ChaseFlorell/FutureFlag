using Example.Futures.Main;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Example
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }
    }
}