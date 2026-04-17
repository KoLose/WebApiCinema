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
            return new BadRequestObjectResult(new
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

    public async Task<IActionResult> PatchMovieAsync(UpdateMovie updateMovie)
    {
        if (updateMovie != null)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.MovieID == updateMovie.MovieID);
            movie.Title = updateMovie.Title;
            movie.Description = updateMovie.Description;
            movie.ReleaseDate = updateMovie.ReleaseDate;
            movie.Rating = updateMovie.Rating;
            movie.ImageUrl = updateMovie.ImageUrl;
            
            await _context.SaveChangesAsync();
            return new OkObjectResult(new
            {
                status = true
            });
        }
        return new BadRequestObjectResult(new
        {
            status = false
        });
    }

    public async Task<IActionResult> DeleteMovieAsync(DeleteMovie deleteMovie)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(m => m.MovieID == deleteMovie.MovieID);
        _context.Movies.Remove(movie); 
        await _context.SaveChangesAsync();
        return new OkObjectResult(new
        {
            status = true
        });
    }
}