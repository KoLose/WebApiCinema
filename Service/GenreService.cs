using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DatabaseContext;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Requests;

namespace WebAPI.Service;

public class GenreService: IGenresService
{
    private readonly ContextDb _context;
    
    public GenreService(ContextDb context)
    {
        _context = context;
    }

    public async Task<IActionResult> GetAllGenresAsync()
    {
        var genres = await _context.Genres.ToListAsync();
        return new OkObjectResult(new
        {
            data = genres,
            status = true
        });
    }

    public async Task<IActionResult> PostGenreAsync(CreateNewGenre newGenre)
    {
        var genre = new Genre()
        {
            Name = newGenre.Name
        };
        
        await _context.AddAsync(genre);
        await _context.SaveChangesAsync();
        
        return new OkObjectResult(new
        {
            status = true
        });
    }
}