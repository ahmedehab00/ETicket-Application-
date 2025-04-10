

using eTickets.Data.Data;
using eTickets.Data.Data.Base;
using eTickets.Data.Models;

namespace eTickets.service.service
{
    public class CinemaService : EntityBaseRepository<Cinema> , ICinemaService
    {
        public CinemaService(AppDbContext context):base(context) { }
      
    }
}
