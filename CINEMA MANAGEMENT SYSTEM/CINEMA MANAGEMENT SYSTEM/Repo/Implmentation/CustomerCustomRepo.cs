using CINEMA_MANAGEMENT_SYSTEM.Data;
using CINEMA_MANAGEMENT_SYSTEM.Models;
using CINEMA_MANAGEMENT_SYSTEM.Repo.Interfaces;

namespace CINEMA_MANAGEMENT_SYSTEM.Repo.Implmentation
{
    public class CustomerCustomRepo : GenericRepo<Customer>, ICustomer
    {
        private readonly My_AppContext _context;
        public CustomerCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }
    }
}
