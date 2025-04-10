
using eTickets.Data.Data.Base;
using eTickets.Data.Data.ViewModels;
using eTickets.Data.Models;
using System.Threading.Tasks;

namespace eTickets.service.service
{
    public interface IMoviesService :IEntityBaseRepository<Movie>
    {
        Task<Movie>GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
