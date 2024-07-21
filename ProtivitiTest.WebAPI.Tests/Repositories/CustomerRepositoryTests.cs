using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProtivitiTest.WebAPI.Data;
using ProtivitiTest.WebAPI.DTOs;
using ProtivitiTest.WebAPI.Models;
using ProtivitiTest.WebAPI.Repositories.CustomerRepo;
using ProtivitiTest.WebAPI.Services.AvatarService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace ProtivitiTest.WebAPI.Tests.Repositories
{

    public class CustomerRepositoryTests
    {
        private readonly Mock<SqliteDbContext> _contextMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<AvatarService> _avatarServiceMock;
        private readonly CustomerRepository _customerRepository;
        public List<Customer> mockCustomers;

        public CustomerRepositoryTests()
        {
            _contextMock = new Mock<SqliteDbContext>();
            _mapperMock = new Mock<IMapper>();
            _avatarServiceMock = new Mock<AvatarService>();
            _customerRepository = new CustomerRepository(_contextMock.Object, _mapperMock.Object, _avatarServiceMock.Object);
        }

        [Fact]
        public async Task GetAllCustomer_ShouldReturnCustomers()
        {
            // Arrange
            var customers = new List<Customer>
            {
               new Customer { Id = Guid.NewGuid(), FullName = "John Doe", DateOfBirth = new DateOnly(1990, 1, 1), Avatar = "avatar1.png" },
               new Customer { Id = Guid.NewGuid(), FullName = "Jane Doe", DateOfBirth = new DateOnly(1992, 2, 2), Avatar = "avatar2.png" }
            }.AsQueryable();

            var customerDtos = new List<CustomerDto>
            {
                 new CustomerDto { Id = customers.ToList()[0].Id, FullName = "John Doe", DateOfBirth = new DateOnly(1990, 1, 1), Avatar = "avatar1.png" },
                 new CustomerDto { Id = customers.ToList()[1].Id, FullName = "Jane Doe", DateOfBirth = new DateOnly(1992, 2, 2), Avatar = "avatar2.png" }
            };

            var dbSetMock = new Mock<DbSet<Customer>>();
            dbSetMock.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customers.Provider);
            dbSetMock.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customers.Expression);
            dbSetMock.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customers.ElementType);
            dbSetMock.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(customers.GetEnumerator());

            _contextMock.Setup(c => c.Customers).Returns(dbSetMock.Object);
            _mapperMock.Setup(m => m.ConfigurationProvider).Returns(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
            }));

            // Act
            var result = await _customerRepository.GetAllCustomer();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task Complete_ShouldReturnTrue_WhenChangesSaved()
        {
            // Arrange
            _contextMock.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            // Act
            var result = await _customerRepository.Complete();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Complete_ShouldReturnFalse_WhenNoChangesSaved()
        {
            // Arrange
            _contextMock.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(0);

            // Act
            var result = await _customerRepository.Complete();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HasChanges_ShouldReturnTrue_WhenContextHasChanges()
        {
            // Arrange
            _contextMock.Setup(c => c.ChangeTracker.HasChanges()).Returns(true);

            // Act
            var result = _customerRepository.HasChanges();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasChanges_ShouldReturnFalse_WhenContextHasNoChanges()
        {
            // Arrange
            _contextMock.Setup(c => c.ChangeTracker.HasChanges()).Returns(false);

            // Act
            var result = _customerRepository.HasChanges();

            // Assert
            Assert.False(result);
        }
    }
}
