using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;


public class Movie
{
    [Key]
    public int MovieID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Rating { get; set; }
    public string ImageUrl { get; set; }
    
    [Required]
    [ForeignKey("Genre")]
    public int Genre_ID { get; set; }
    public Genre Genre { get; set; }
}