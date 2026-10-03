using CINEMA_MANAGEMENT_SYSTEM.Data;
using CINEMA_MANAGEMENT_SYSTEM.Repo.Interfaces;

namespace CINEMA_MANAGEMENT_SYSTEM.Repo.Implmentation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly My_AppContext _context;
        public GenreCustomRepo GenreCustomRepo { get; }

        public CustomerCustomRepo CustomerCustomRepo { get; }

        public MovieCustomRepo MovieCustomRepo { get; }

        public BookingCustomRepo BookingCustomRepo { get; }
        public UnitOfWork(My_AppContext context, GenreCustomRepo genreCustomRepo,
            CustomerCustomRepo customerCustomRepo, MovieCustomRepo movieCustomRepo,
            BookingCustomRepo bookingCustomRepo)
        {
            _context = context;
            GenreCustomRepo = genreCustomRepo;
            CustomerCustomRepo = customerCustomRepo;
            MovieCustomRepo = movieCustomRepo;
            BookingCustomRepo = bookingCustomRepo;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
