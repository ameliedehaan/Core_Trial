using System;
using System.Collections.Generic;

namespace KunstBeach_ClassLibrary
{
    public partial class Work
    {
        public int WorkId { get; set; }
        public string WorkName { get; set; }
        public int ArtistId { get; set; }
        public int? WorkYear { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Place Place { get; set; }
    }
}