using System;
using AppStudio.Common;
using Windows.ApplicationModel;

namespace Kalanjali2k15.ViewModels
{
    public class AboutThisAppViewModel : ObservableBase
    {
        public string Publisher
        {
            get
            {
                return "Principal SMVIT";
            }
        }

        public string AppVersion
        {
            get
            {
                return string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
            }
        }

        public string AboutText
        {
            get
            {
                return "Everything you need to know about the fest in a quick and simple app.  Use this a" +
    "pp to get details about the fest.";
            }
        }
    }
}

