using System;
using AppStudio.DataProviders;

namespace Kalanjali2k15.Sections
{
    /// <summary>
    /// Implementation of the EventListDAY21Schema class.
    /// </summary>
    public class EventListDAY21Schema : SchemaBase
    {

        public string Image { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public string Description { get; set; }

        public string Specification { get; set; }

        public string Moreinfo { get; set; }
    }
}