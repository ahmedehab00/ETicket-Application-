using eTickets.service.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etickets.Service.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IActorsService Actors { get; }
        IMoviesService Movies { get; }
        ICinemaService Cinemas { get; }
        IProducerService Producers { get; }
        IOrderService Orders { get; }

        Task<int> Complete();
    }

}

