using System;
using System.Collections.Generic;

namespace KunstBeach_ClassLibrary
{
    public partial class Place
    {
        public int PlaceId { get; set; }
        public int ArtistId { get; set; }
        public int WorkId { get; set; }
        public string PlaceName { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Work PlaceNavigation { get; set; }
    }
}