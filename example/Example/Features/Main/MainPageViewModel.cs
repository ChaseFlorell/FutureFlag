using System.ComponentModel;
using System.Runtime.CompilerServices;
using FutureFlag;
using Xamarin.Forms;

namespace Example.Features.Main
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly string _prefix;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            _prefix = Device.RuntimePlatform == Device.iOS ? "CFBundleVersion is {0}" : "Android VersionName is {0}";
        }
        
        public string VersionString => string.Format(_prefix, ((VersionFutureFlag)Application.Current.Resources["VersionFlag"]).ActualVersion);

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}