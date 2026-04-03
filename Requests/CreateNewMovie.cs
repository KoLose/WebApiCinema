using WebAPI.Models;

namespace WebAPI.Requests;

public class CreateNewMovie
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Rating { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
}