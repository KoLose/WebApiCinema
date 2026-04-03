using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class Genre
{
    [Key]
    public int GenreID { get; set; }
    public string Name { get; set; }
}