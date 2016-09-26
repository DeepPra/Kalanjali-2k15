using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Bing;
using Kalanjali2k15;
using Kalanjali2k15.Sections;
using Kalanjali2k15.ViewModels;

namespace Kalanjali2k15.Views
{
    public sealed partial class NewsListPage : PageBase
    {
        public ListViewModel<BingDataConfig, BingSchema> ViewModel { get; set; }

        public NewsListPage()
        {
            this.ViewModel = new ListViewModel<BingDataConfig, BingSchema>(new NewsConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
