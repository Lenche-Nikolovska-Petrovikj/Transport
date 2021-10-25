using Application.ViewModels;
using System;


namespace Application.Interfaces
{
    public interface ITransportService
    {
        TransportListViewModel GetTransports();
        TransportViewModel GetTransportById(Guid id);
        TransportViewModel AddTransport(TransportViewModel transportRequest);
        void Delete(Guid id);
    }
}
