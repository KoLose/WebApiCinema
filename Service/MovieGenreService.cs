using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DatabaseContext;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Requests;

namespace WebAPI.Service;

public class MovieGenreService : IMoviesGengresService
{
    private readonly ContextDb _context;
    
    public MovieGenreService(ContextDb context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> GetAllMoviesAsync()
    {
        var movies = await _context.Movies
            .Include(m => m.Genre)
            .Select(m => new 
                {
                    m.MovieID,
                    m.Title,
                    m.Description,
                    m.ReleaseDate,
                    m.Rating,
                    m.ImageUrl,
                    Genre = m.Genre.Name  
                }).
            ToListAsync();
        
        return new OkObjectResult(new
        {
            data = new
            {
                movies = movies
            },
            status = true
        });
    }

    public async Task<IActionResult> PostMovieAsync(CreateNewMovie newMovie)
    {
        var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Name == newMovie.Name);
        if (genre == null)
        {
            return new OkObjectResult(new
            {
                status = false
            });
        }
        var movie = new Movie()
        { 
            Title = newMovie.Title, 
            Description = newMovie.Description, 
            ReleaseDate = newMovie.ReleaseDate, 
            Rating = newMovie.Rating,
            ImageUrl = newMovie.ImageUrl,
            Genre_ID = genre.GenreID
        };
        
        await _context.AddAsync(movie); 
        await _context.SaveChangesAsync();
        
        return new OkObjectResult(new 
        { 
            status = true
        });
    }
}