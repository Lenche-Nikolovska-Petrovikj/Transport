using Application.ViewModels;
using AutoMapper;
using Infrastructure.Data.Models;


namespace Application.Mappers
{
    public class TransportProfile: Profile
    {
        public TransportProfile()
        {
            CreateMap<Transport, TransportViewModel>().ReverseMap();
            CreateMap<User, RegisterViewModel>().ReverseMap();
            CreateMap<User, SignInViewModel>().ReverseMap();
        }
    }
}
