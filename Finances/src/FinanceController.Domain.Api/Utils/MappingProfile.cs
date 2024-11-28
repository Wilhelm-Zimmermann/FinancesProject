using AutoMapper;
using FinanceController.Domain.Commands.Users;
using FinanceController.Domain.Entities;
using FinanceController.Domain.Queries.Bills;

namespace FinanceController.Domain.Api.Utils;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User
        CreateMap<CreateUserCommand, User>().ReverseMap();
        CreateMap<CreateUserFromRouteCommand, User>().ReverseMap();
        
        // Bills
        CreateMap<BillsDto, Bill>().ReverseMap();
    }
}
