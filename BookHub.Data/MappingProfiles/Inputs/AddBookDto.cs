

namespace BookHub.Data.MappingProfiles.Inputs
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
        public int AvailableCopies { get; set; }
    }
}
