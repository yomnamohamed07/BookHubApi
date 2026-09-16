



namespace BookHub.Data.MappingProfiles.Inputs
{


    namespace BookHub.Data.MappingProfiles.Outputs
    {
        public class BookShowDto
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string ISBN { get; set; }
            public string Category { get; set; }
            public int AvailableCopies { get; set; }
        }
    }
}
