namespace WebAPI.Requests;

public class UpdateMovie
{
    public int MovieID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Rating { get; set; }
    public string ImageUrl { get; set; }
    public string GenreName { get; set; }
}