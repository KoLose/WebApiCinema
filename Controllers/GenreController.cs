using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.Requests;

namespace WebAPI.Controllers;

public class GenreController
{
    private readonly IGenresService _genresService;
    
    public GenreController(IGenresService genresService)
    {
        _genresService = genresService;
    }

    [HttpGet]
    [Route("GetAllGenres")]
    public async Task<IActionResult> GetAllGenresAsync()
    {
        return await _genresService.GetAllGenresAsync();
    }

    [HttpPost]
    [Route("PostGenre")]
    public async Task<IActionResult> PostGenreAsync(CreateNewGenre newGenre)
    {
        return await _genresService.PostGenreAsync(newGenre);
    }
}