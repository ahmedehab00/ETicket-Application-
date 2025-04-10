
using eTickets.Data.Data;
using eTickets.Data.Data.Base;
using eTickets.Data.Data.ViewModels;
using eTickets.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.service.service
{
    public class MovieService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MovieService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var NewMovie = new Movie()
            {
                name = data.name,
                description = data.description,
                price = data.price,
                ImageUrl = data.ImageUrl,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId,
            };
            await _context.Movies.AddAsync(NewMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)

            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = NewMovie.id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);

            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var MovieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.id == id);

            return MovieDetails;

        }
        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }
      

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.id == data.Id);
            if (dbMovie != null)
            {

                dbMovie.name = data.name;
                dbMovie.description = data.description;
                dbMovie.price = data.price;
                dbMovie.ImageUrl = data.ImageUrl;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();

            }
            // Remove existing actors
            var existingActorDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorDb);
            await _context.SaveChangesAsync();
            //Add Movie Actors
            foreach (var actorId in data.ActorIds)

            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);

            }
            await _context.SaveChangesAsync();

        }
    }
}
