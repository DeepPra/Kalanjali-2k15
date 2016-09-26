using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.LocalStorage;
using Kalanjali2k15;
using Kalanjali2k15.Sections;
using Kalanjali2k15.ViewModels;

namespace Kalanjali2k15.Views
{
    public sealed partial class EventListDAY2ListPage : PageBase
    {
        public ListViewModel<LocalStorageDataConfig, EventListDAY21Schema> ViewModel { get; set; }

        public EventListDAY2ListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, EventListDAY21Schema>(new EventListDAY2Config());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
