using System;
using System.Collections.Generic;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.LocalStorage;
using Kalanjali2k15.Config;
using Kalanjali2k15.ViewModels;

namespace Kalanjali2k15.Sections
{
    public class EventListDAY2Config : SectionConfigBase<LocalStorageDataConfig, EventListDAY21Schema>
    {
        public override DataProviderBase<LocalStorageDataConfig, EventListDAY21Schema> DataProvider
        {
            get
            {
                return new LocalStorageDataProvider<EventListDAY21Schema>();
            }
        }

        public override LocalStorageDataConfig Config
        {
            get
            {
                return new LocalStorageDataConfig
                {
                    FilePath = "/Assets/Data/EventListDAY2.json"
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("EventListDAY2ListPage");
            }
        }

        public override ListPageConfig<EventListDAY21Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<EventListDAY21Schema>
                {
                    Title = "Event list-DAY 2",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Name.ToSafeString();
                        viewModel.SubTitle = item.Reference.ToSafeString();
                        viewModel.Description = "";
                        viewModel.Image = "";

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("EventListDAY2DetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<EventListDAY21Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, EventListDAY21Schema>>();

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Name.ToSafeString();
                    viewModel.Title = item.Reference.ToSafeString();
                    viewModel.Description = item.Description.ToSafeString();
                    viewModel.Image = "";
                    viewModel.Content = null;
                });

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "Rules";
                    viewModel.Title = "";
                    viewModel.Description = item.Specification.ToSafeString();
                    viewModel.Image = "";
                    viewModel.Content = null;
                });

				var actions = new List<ActionConfig<EventListDAY21Schema>>
				{
				};

                return new DetailPageConfig<EventListDAY21Schema>
                {
                    Title = "Event list-DAY 2",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Event list-DAY 2"; }
        }

    }
}
