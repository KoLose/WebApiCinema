using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;

namespace WebAPI.Interfaces;

public interface IMoviesGengresService
{
    Task<IActionResult> GetAllMoviesAsync();
    Task<IActionResult> PostMovieAsync(CreateNewMovie newMovie);
    Task<IActionResult> PatchMovieAsync(UpdateMovie updateMovie);
    Task<IActionResult> DeleteMovieAsync(DeleteMovie deleteMovie);
}