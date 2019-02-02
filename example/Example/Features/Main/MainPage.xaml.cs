using FutureFlag;

namespace Example.Futures.Main
{
    public partial class MainPage 
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public string VersionString => new VersionHelper().Version.ToString();
    }
}
