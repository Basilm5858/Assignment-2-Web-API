using CINEMA_MANAGEMENT_SYSTEM.Data;
using CINEMA_MANAGEMENT_SYSTEM.DTOs;
using CINEMA_MANAGEMENT_SYSTEM.Models;
using CINEMA_MANAGEMENT_SYSTEM.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CINEMA_MANAGEMENT_SYSTEM.Repo.Implmentation
{
    public class GenreCustomRepo : GenericRepo<Genre>, IGenre
    {
        private readonly My_AppContext _context;
        public GenreCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<EndPoint6DTO>> EndPoint6()
        {
            return await _context.Genres
                .Select(x => new EndPoint6DTO
                {
                    Id = x.Id,
                    Movies = x.Movies,
                    Name = x.Name
                }).ToListAsync();
        }
    }
}
