using System.ComponentModel.DataAnnotations;

namespace BookHub.Data.MappingProfiles.Inputs
{
    public class AddBookDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [StringLength(100, ErrorMessage = "Author cannot exceed 100 characters")]
        public string Author { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [StringLength(20, ErrorMessage = "ISBN cannot exceed 20 characters")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Available Copies cannot be negative")]
        public int AvailableCopies { get; set; }
    }
}
