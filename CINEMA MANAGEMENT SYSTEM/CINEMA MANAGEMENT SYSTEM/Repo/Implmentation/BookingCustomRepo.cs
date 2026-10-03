using CINEMA_MANAGEMENT_SYSTEM.Data;
using CINEMA_MANAGEMENT_SYSTEM.Models;
using CINEMA_MANAGEMENT_SYSTEM.Repo.Interfaces;

namespace CINEMA_MANAGEMENT_SYSTEM.Repo.Implmentation
{
    public class BookingCustomRepo : GenericRepo<Booking>, IBooking
    {
        private readonly My_AppContext _context;
        public BookingCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }
    }
}
