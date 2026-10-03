using CINEMA_MANAGEMENT_SYSTEM.DTOs;
using CINEMA_MANAGEMENT_SYSTEM.Models;

namespace CINEMA_MANAGEMENT_SYSTEM.Repo.Interfaces
{
    public interface IMovie : IGenericRepo<Movie>
    {
        Task<ICollection<MovieDTOEndPoint6>> EndPoint6(string title);
    }
}
