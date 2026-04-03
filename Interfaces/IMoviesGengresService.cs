using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;

namespace WebAPI.Interfaces;

public interface IMoviesGengresService
{
    Task<IActionResult> GetAllMoviesAsync();
    Task<IActionResult> PostMovieAsync(CreateNewMovie newMovie);
}