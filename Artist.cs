using System.Collections.Generic;

namespace multitracks.com-dotnet.Entities
{
    public class Artist
    {
        public int artistID { get; set; }
        public decimal dataCreation { get; set; }
        public string title { get; set; }
        public string biography { get; set; }
        public string imageURL { get; set; }
        public string heroURL { get; set; }
    }
}
