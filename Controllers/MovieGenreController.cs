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
}