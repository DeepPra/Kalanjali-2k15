using Windows.UI.Xaml.Controls;
using Kalanjali2k15.ViewModels;

namespace Kalanjali2k15
{
    public sealed partial class AboutThisAppPage : Page
    {
        public AboutThisAppViewModel AboutModel { get; private set; }
        public AboutThisAppPage()
        {
            AboutModel = new AboutThisAppViewModel();
            this.InitializeComponent();
        }
    }
}

