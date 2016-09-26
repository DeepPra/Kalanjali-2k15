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
    public class EventListDAY1Config : SectionConfigBase<LocalStorageDataConfig, EventListDAY11Schema>
    {
        public override DataProviderBase<LocalStorageDataConfig, EventListDAY11Schema> DataProvider
        {
            get
            {
                return new LocalStorageDataProvider<EventListDAY11Schema>();
            }
        }

        public override LocalStorageDataConfig Config
        {
            get
            {
                return new LocalStorageDataConfig
                {
                    FilePath = "/Assets/Data/EventListDAY1.json"
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("EventListDAY1ListPage");
            }
        }

        public override ListPageConfig<EventListDAY11Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<EventListDAY11Schema>
                {
                    Title = "Event list-DAY 1",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Name.ToSafeString();
                        viewModel.SubTitle = item.Reference.ToSafeString();
                        viewModel.Description = "";
                        viewModel.Image = item.Image.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("EventListDAY1DetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<EventListDAY11Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, EventListDAY11Schema>>();

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

				var actions = new List<ActionConfig<EventListDAY11Schema>>
				{
                    ActionConfig<EventListDAY11Schema>.Link("MoreInfo", (item) => item.MoreInfo.ToSafeString()),
				};

                return new DetailPageConfig<EventListDAY11Schema>
                {
                    Title = "Event list-DAY 1",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Event list-DAY 1"; }
        }

    }
}
