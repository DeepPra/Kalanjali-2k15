using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStudio.Common;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Html;
using AppStudio.DataProviders.Bing;
using AppStudio.DataProviders.Menu;
using AppStudio.DataProviders.LocalStorage;
using Kalanjali2k15.Sections;


namespace Kalanjali2k15.ViewModels
{
    public class MainViewModel : ObservableBase
    {
        public MainViewModel(int visibleItems)
        {
            PageTitle = "Kalanjali2k15";
            AboutUs = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new AboutUsConfig(), visibleItems);
            EventListDAY1 = new ListViewModel<LocalStorageDataConfig, EventListDAY11Schema>(new EventListDAY1Config(), visibleItems);
            EventListDAY2 = new ListViewModel<LocalStorageDataConfig, EventListDAY21Schema>(new EventListDAY2Config(), visibleItems);
            News = new ListViewModel<BingDataConfig, BingSchema>(new NewsConfig(), visibleItems);
            ContactUs = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new ContactUsConfig());
            Actions = new List<ActionInfo>();

            if (GetViewModels().Any(vm => !vm.HasLocalData))
            {
                Actions.Add(new ActionInfo
                {
                    Command = new RelayCommand(Refresh),
                    Style = ActionKnownStyles.Refresh,
                    Name = "RefreshButton",
                    ActionType = ActionType.Primary
                });
            }
        }

        public string PageTitle { get; set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> AboutUs { get; private set; }
        public ListViewModel<LocalStorageDataConfig, EventListDAY11Schema> EventListDAY1 { get; private set; }
        public ListViewModel<LocalStorageDataConfig, EventListDAY21Schema> EventListDAY2 { get; private set; }
        public ListViewModel<BingDataConfig, BingSchema> News { get; private set; }
        public ListViewModel<LocalStorageDataConfig, MenuSchema> ContactUs { get; private set; }

        public RelayCommand<INavigable> SectionHeaderClickCommand
        {
            get
            {
                return new RelayCommand<INavigable>(item =>
                    {
                        NavigationService.NavigateTo(item);
                    });
            }
        }

        public DateTime? LastUpdated
        {
            get
            {
                return GetViewModels().Select(vm => vm.LastUpdated)
                            .OrderByDescending(d => d).FirstOrDefault();
            }
        }

        public List<ActionInfo> Actions { get; private set; }

        public bool HasActions
        {
            get
            {
                return Actions != null && Actions.Count > 0;
            }
        }

        public async Task LoadDataAsync()
        {
            var loadDataTasks = GetViewModels().Select(vm => vm.LoadDataAsync());

            await Task.WhenAll(loadDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private async void Refresh()
        {
            var refreshDataTasks = GetViewModels()
                                        .Where(vm => !vm.HasLocalData)
                                        .Select(vm => vm.LoadDataAsync(true));

            await Task.WhenAll(refreshDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private IEnumerable<DataViewModelBase> GetViewModels()
        {
            yield return AboutUs;
            yield return EventListDAY1;
            yield return EventListDAY2;
            yield return News;
            yield return ContactUs;
        }
    }
}
