using eTickets.Data.Data;
using eTickets.service.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etickets.Service.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IActorsService Actors { get; private set; }
        public IMoviesService Movies { get; private set; }
        public ICinemaService Cinemas { get; private set; }
        public IProducerService Producers { get; private set; }
        public IOrderService Orders { get; private set; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Actors = new ActorService(_context);
            Movies = new MovieService(_context);
            Cinemas = new CinemaService(_context);
            Producers = new ProducerService(_context);
            Orders = new OrderService(_context);
        }


        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

