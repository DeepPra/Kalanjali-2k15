using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.LocalStorage;
using Kalanjali2k15;
using Kalanjali2k15.Sections;
using Kalanjali2k15.ViewModels;

namespace Kalanjali2k15.Views

{
    public sealed partial class EventListDAY1DetailPage : PageBase
    {
        private DataTransferManager _dataTransferManager;
        public DetailViewModel<LocalStorageDataConfig, EventListDAY11Schema> ViewModel { get; set; }

        public EventListDAY1DetailPage()
        {
            this.ViewModel = new DetailViewModel<LocalStorageDataConfig, EventListDAY11Schema>(new EventListDAY1Config());
            this.InitializeComponent();            
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync(navParameter as ItemViewModel);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;

            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            bool supportsHtml = true;
#if WINDOWS_PHONE_APP
            supportsHtml = false;
#endif
            ViewModel.ShareContent(args.Request, supportsHtml);
        }
    }
}
