using System.ComponentModel.DataAnnotations;

namespace Mission6_staufjon.Models
{
    public class MovieCollection
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required]
        // build fk relationship
        public int CategoryId { get; set; }
        public Category Category { get; set; } 

        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool  Edited {get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }

    }
}
