using CINEMA_MANAGEMENT_SYSTEM.Repo.Implmentation;

namespace CINEMA_MANAGEMENT_SYSTEM.Repo.Interfaces
{
    public interface IUnitOfWork
    {
        GenreCustomRepo GenreCustomRepo { get; }
        CustomerCustomRepo CustomerCustomRepo { get; }
        MovieCustomRepo MovieCustomRepo { get; }
        BookingCustomRepo BookingCustomRepo { get; }
        Task SaveChangesAsync();
    }
}
