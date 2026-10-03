using CINEMA_MANAGEMENT_SYSTEM.DTOs;
using CINEMA_MANAGEMENT_SYSTEM.Models;

namespace CINEMA_MANAGEMENT_SYSTEM.Repo.Interfaces
{
    public interface IGenre : IGenericRepo<Genre>
    {
        Task<ICollection<EndPoint6DTO>> EndPoint6();

    }
}