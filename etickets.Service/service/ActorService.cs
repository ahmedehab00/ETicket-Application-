
using eTickets.Data.Data;
using eTickets.Data.Data.Base;
using eTickets.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.service.service
{
    public class ActorService : EntityBaseRepository<Actor>, IActorsService
    {

        public ActorService(AppDbContext context) : base(context) { }
    }
}
        