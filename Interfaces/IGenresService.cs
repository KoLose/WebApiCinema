using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Requests;

namespace WebAPI.Interfaces;

public interface IGenresService
{
    Task<IActionResult> GetAllGenresAsync();
    Task<IActionResult> PostGenreAsync(CreateNewGenre newGenre);
}