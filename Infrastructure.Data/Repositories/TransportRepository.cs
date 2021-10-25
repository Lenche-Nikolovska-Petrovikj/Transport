using Domain.Interfaces;
using Infrastructure.Data.Context;
using Infrastructure.Data.Models;
using Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data.Repositories
{
    public class TransportRepository : BaseRepository<Transport>, ITransportRepository
    {
        private readonly DbSet<Transport> _transports;
        public TransportRepository(TransportDbContext dbContext) : base(dbContext)
        {
            _transports = dbContext.Set<Transport>();
        }
    }
}
