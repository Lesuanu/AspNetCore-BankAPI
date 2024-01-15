using AutoMapper;
using BankManagement.Infrastructure.Models.BankCustomer;
using BankManagement.ViewModels;

namespace BankManagement.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
           CreateMap<BankCustomer1, BankCustomerDto>();
        }
    }
}
