using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Data.Models;
using System;
using System.Collections.Generic;


namespace Application.Services
{
    public class TransportService : ITransportService
    {
        private readonly ITransportRepository _transportRepository;
        private readonly IMapper _mapper;
        public TransportService(ITransportRepository transportRepository, IMapper mapper)
        {
            _transportRepository = transportRepository;
            _mapper = mapper;
        }

        public TransportViewModel AddTransport(TransportViewModel transportRequest)
        {
            var transport = _mapper.Map<Transport>(transportRequest);
            var addedTransport = _transportRepository.Add(transport);

            return _mapper.Map<TransportViewModel>(addedTransport);
        }

        public TransportViewModel GetTransportById(Guid id)
        {
            var transportVm = _mapper.Map<TransportViewModel>(_transportRepository.GetById(id));

            return transportVm;
        }

        public TransportListViewModel GetTransports()
        {
            var transports = _transportRepository.GetAll();
            var transporstViewModel = _mapper.Map<IEnumerable<TransportViewModel>>(transports);

            return new TransportListViewModel()
            {
                Transports = transporstViewModel,
               
            };
        }
        public void Delete(Guid id)
        {
            var transport = _mapper.Map<Transport>(_transportRepository.GetById(id));
            _transportRepository.Delete(transport);
        }

    }
}
