using Microsoft.AspNetCore.JsonPatch;
using ProtivitiTest.WebAPI.DTOs;
using ProtivitiTest.WebAPI.Models;
using System.Collections.Generic;

namespace ProtivitiTest.WebAPI.Repositories.CustomerRepo
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomer();
        Task<CustomerDto> GetCustomerById(Guid id);
        Task<CustomerDto> UpdateCustomer(Guid id, JsonPatchDocument<Customer> patchDoc);
        Task<IEnumerable<CustomerDto>> GetAllCustomerByAge(int age);
        Task<Customer> CreateCustomer(CustomerDto customerDto);
        Task<bool> Complete();
        bool HasChanges();
    }
}
