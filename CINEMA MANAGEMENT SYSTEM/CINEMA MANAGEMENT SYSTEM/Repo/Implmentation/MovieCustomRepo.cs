using CINEMA_MANAGEMENT_SYSTEM.Data;
using CINEMA_MANAGEMENT_SYSTEM.DTOs;
using CINEMA_MANAGEMENT_SYSTEM.Models;
using CINEMA_MANAGEMENT_SYSTEM.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CINEMA_MANAGEMENT_SYSTEM.Repo.Implmentation
{
    public class MovieCustomRepo : GenericRepo<Movie>, IMovie
    {
        private readonly My_AppContext _context;
        public MovieCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<MovieDTOEndPoint6>> EndPoint6(string title)
        {
            return await _context.Movies
                .Where(x => x.Title.Contains(title))
                .Select(x => new MovieDTOEndPoint6
                {
                    Id = x.Id,
                    Title = x.Title,
                    Director = x.Director,
                    AvailableSeats = x.AvailableSeats,
                    TicketPrice = x.TicketPrice
                }).ToListAsync();
        }
    }
}
