using AutoMapper;
using FinanceController.Domain.Commands.Bills;
using FinanceController.Domain.Commands.Users;
using FinanceController.Domain.Entities;
using FinanceController.Domain.Queries.Bills;
using FinanceController.Domain.Queries.BillsTypes;

namespace FinanceController.Domain.Api.Utils;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User
        CreateMap<CreateUserCommand, User>().ReverseMap();
        
        // Bills
        CreateMap<BillsDto, Bill>().ReverseMap();
        CreateMap<UpdateBillCommand, Bill>().ReverseMap();
        
        // Bills Types
        CreateMap<BillTypeDto, BillType>().ReverseMap();
    }
}
