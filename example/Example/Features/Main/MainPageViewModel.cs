using System.ComponentModel;
using System.Runtime.CompilerServices;
using FutureFlag;
using Xamarin.Forms;

namespace Example.Features.Main
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly VersionFutureFlag _versionFutureFlag;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            _versionFutureFlag =  (VersionFutureFlag)Application.Current.Resources["VersionFlag"];
        }
        
        public string VersionString => $"{_versionFutureFlag.VersionSource}: {_versionFutureFlag.ActualVersion}";

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}