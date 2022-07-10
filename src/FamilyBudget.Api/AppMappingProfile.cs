using AutoMapper;
using FamilyBudget.Api.ViewModels;
using FamilyBudget.Domain.Entities;

namespace FamilyBudget.Api;

public sealed class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<Income, IncomeView>().ReverseMap();
        CreateMap<Expenditure, ExpenditureView>().ReverseMap();
        CreateMap<FinancialPeriod, FinancialPeriodView>().ReverseMap();
    }
}