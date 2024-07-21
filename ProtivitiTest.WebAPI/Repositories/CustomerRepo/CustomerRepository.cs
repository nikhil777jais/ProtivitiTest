using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using ProtivitiTest.WebAPI.Data;
using ProtivitiTest.WebAPI.DTOs;
using ProtivitiTest.WebAPI.Models;
using ProtivitiTest.WebAPI.Services.AvatarService;
using System.Data;

namespace ProtivitiTest.WebAPI.Repositories.CustomerRepo
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqliteDbContext _context;
        private readonly IMapper _mapper;
        private readonly AvatarService _avatarService;

        public CustomerRepository(SqliteDbContext context, IMapper mapper, AvatarService avatarService)
        {
            _context = context;
            _mapper = mapper;
            _avatarService = avatarService;
        }

        public async Task<Customer> CreateCustomer(CustomerDto customerDto)
        {
            try
            {
                var avatar = await _avatarService.GetAvatarAsync(customerDto.FullName);
                var customer = _mapper.Map<Customer>(customerDto);
                customer.Avatar = avatar;
                await _context.Customers.AddAsync(customer);
                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomer()
        {
            try
            {
                return await _context.Customers.ProjectTo<CustomerDto>(_mapper.ConfigurationProvider).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomerByAge(int age)
        {
            try
            {
                var today = DateOnly.FromDateTime(DateTime.Today);
                var customers = await _context.Customers
                    .Where(c => today.Year - c.DateOfBirth.Year == age)
                    .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider).ToListAsync();
                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CustomerDto> GetCustomerById(Guid id)
        {
            try
            {
                var res = await _context.Customers.FindAsync(id);
                return _mapper.Map<CustomerDto>(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            _context.ChangeTracker.DetectChanges();
            var changes = _context.ChangeTracker.HasChanges();

            return changes;
        }

        public async Task<CustomerDto> UpdateCustomer(Guid id, JsonPatchDocument<Customer> patchDoc)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                // Keep a copy of the original FullName to check if it changes
                var originalFullName = customer.FullName;

                patchDoc.ApplyTo(customer);

                if (customer.FullName != originalFullName)
                {
                    customer.Avatar = await _avatarService.GetAvatarAsync(customer.FullName);
                }

                try
                {
                    await Complete();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
