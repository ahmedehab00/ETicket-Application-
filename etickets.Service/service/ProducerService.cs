

using eTickets.Data.Data;
using eTickets.Data.Data.Base;
using eTickets.Data.Models;

namespace eTickets.service.service
{
    public class ProducerService:EntityBaseRepository<Producer>,IProducerService
    {
        public ProducerService(AppDbContext context):base(context)
        {
        }
        
    }
}
