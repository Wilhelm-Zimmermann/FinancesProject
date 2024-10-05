using AutoMapper;
using FinanceController.Domain.Commands;
using FinanceController.Domain.Entities;
using FinanceController.Domain.Queries.Bills;

namespace FinanceController.Domain.Api.Utils;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserCommand, User>().ReverseMap();
        CreateMap<BillsDto, Bill>().ReverseMap();
    }
}
