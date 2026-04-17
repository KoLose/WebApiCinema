using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.Requests;

namespace WebAPI.Controllers;

public class MovieGenreController
{
    private readonly IMoviesGengresService _movieGengreService;

    public MovieGenreController(IMoviesGengresService movieGengreService)
    {
        _movieGengreService = movieGengreService;
    }

    [HttpGet]
    [Route("GetAllMovies")]
    public async Task<IActionResult> GetMovieGenreAsync()
    {
        return await _movieGengreService.GetAllMoviesAsync();
    }

    [HttpPost]
    [Route("PostMovieGenre")]
    public async Task<IActionResult> PostMovieGenreAsync([FromBody]CreateNewMovie newMovie)
    {
        return await _movieGengreService.PostMovieAsync(newMovie);
    }

    [HttpPatch]
    [Route("PatchMovieGenre")]
    public async Task<IActionResult> PatchMovieGenreAsync([FromBody] UpdateMovie updateMovie)
    {
        return await _movieGengreService.PatchMovieAsync(updateMovie);
    }

    [HttpDelete]
    [Route("DeleteMovieGenre")]
    public async Task<IActionResult> DeleteMovieGenreAsync([FromBody] DeleteMovie deleteMovie)
    {
        return await _movieGengreService.DeleteMovieAsync(deleteMovie);
    }
}