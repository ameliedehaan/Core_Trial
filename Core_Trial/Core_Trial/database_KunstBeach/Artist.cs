using System;
using System.Collections.Generic;

namespace KunstBeach_ClassLibrary
{
    public partial class Artist
    {
        public Artist()
        {
            Places = new HashSet<Place>();
            Works = new HashSet<Work>();
        }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int? ArtistBirth { get; set; }
        public int? ArtistDeath { get; set; }

        public virtual ICollection<Place> Places { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}