

namespace BookHub.Data.Entities
{
    
        public class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string ISBN { get; set; }
            public string Category { get; set; }
            public int AvailableCopies { get; set; }
            public  bool  IsDeleted { get; set; } = false;
    }
}

