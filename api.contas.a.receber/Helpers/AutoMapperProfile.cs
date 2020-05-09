using AutoMapper;
using WebapiContas.Models;
using WebapiContas.Models.Models;

namespace WebapiContas.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<UserModel, Client>();
            CreateMap<Client, ClientModel>();
            CreateMap<Order, OrderModel>();
        }
            
    }
}
