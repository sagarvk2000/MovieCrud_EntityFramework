using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCrud_EF.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Mname { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string? Genre { get; set; }
        [Required]
        public string? StarsName { get; set; }
        [ScaffoldColumn(false)]
        public int IsActive { get; set; }
    }
}
