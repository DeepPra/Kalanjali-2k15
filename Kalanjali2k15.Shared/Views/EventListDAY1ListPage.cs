using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.LocalStorage;
using Kalanjali2k15;
using Kalanjali2k15.Sections;
using Kalanjali2k15.ViewModels;

namespace Kalanjali2k15.Views
{
    public sealed partial class EventListDAY1ListPage : PageBase
    {
        public ListViewModel<LocalStorageDataConfig, EventListDAY11Schema> ViewModel { get; set; }

        public EventListDAY1ListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, EventListDAY11Schema>(new EventListDAY1Config());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
