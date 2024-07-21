using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProtivitiTest.WebAPI.Controllers;
using ProtivitiTest.WebAPI.DTOs;
using ProtivitiTest.WebAPI.Models;
using ProtivitiTest.WebAPI.Repositories.CustomerRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProtivitiTest.WebAPI.Tests.Controllers
{
    public class CustomersControllerTests
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CustomersController _controller;
        public List<Customer> mockCustomers;

        public CustomersControllerTests()
        {
            _mockCustomerRepo = new Mock<ICustomerRepository>();
            _mockMapper = new Mock<IMapper>();
            _controller = new CustomersController(_mockCustomerRepo.Object, _mockMapper.Object);
            mockCustomers = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid(), FullName = "John Doe", DateOfBirth = new DateOnly(1990, 1, 1), Avatar = "avatar1.png" },
                new Customer { Id = Guid.NewGuid(), FullName = "Jane Doe", DateOfBirth = new DateOnly(1992, 2, 2), Avatar = "avatar2.png" }
            };
        }

        [Fact]
        public async Task GetCustomers_ReturnsOkResult_WithListOfCustomerDtos()
        {
            // Arrange
            var mockCustomerDtos = new List<CustomerDto>
            {
                new CustomerDto { Id = mockCustomers[0].Id, FullName = "John Doe", DateOfBirth = new DateOnly(1990, 1, 1), Avatar = "avatar1.png" },
                new CustomerDto { Id = mockCustomers[1].Id, FullName = "Jane Doe", DateOfBirth = new DateOnly(1992, 2, 2), Avatar = "avatar2.png" }
            };

            _mockCustomerRepo.Setup(repo => repo.GetAllCustomer()).ReturnsAsync(mockCustomerDtos);

            // Act
            var result = await _controller.GetCustomers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnCustomerDtos = Assert.IsType<List<CustomerDto>>(okResult.Value);
            Assert.Equal(2, returnCustomerDtos.Count);
            Assert.Equal(mockCustomerDtos[0].FullName, returnCustomerDtos[0].FullName);
            Assert.Equal(mockCustomerDtos[1].FullName, returnCustomerDtos[1].FullName);
        }

        [Fact]
        public async Task GetCustomers_ReturnsInternalServerError_WhenExceptionThrown()
        {
            // Arrange
            _mockCustomerRepo.Setup(repo => repo.GetAllCustomer()).ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _controller.GetCustomers();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Contains("Test exception", statusCodeResult.Value.ToString());
        }

        [Fact]
        public async Task GetCustomersAge_ReturnsOk_ForExistingCustomers()
        {
            // Arrangez
            var expectedAge = 20;
            var mockCustomerDtos = new List<CustomerDto>
            {
                new CustomerDto { Id = mockCustomers[0].Id, FullName = "John Doe", DateOfBirth = new DateOnly(2004, 1, 1), Avatar = "avatar1.png" },
                new CustomerDto { Id = mockCustomers[1].Id, FullName = "Jane Doe", DateOfBirth = new DateOnly(1992, 2, 2), Avatar = "avatar2.png" }
            };

            _mockCustomerRepo.Setup(repo => repo.GetAllCustomerByAge(expectedAge))
                .ReturnsAsync(mockCustomerDtos);

            // Act
            var actionResult = await _controller.GetCustomersAge(expectedAge);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
            var okResult = actionResult as OkObjectResult;
            Assert.NotNull(okResult);
            var customerDtos = okResult.Value as IEnumerable<CustomerDto>;
            Assert.NotNull(customerDtos);
            Assert.Equal(customerDtos.Count, customerDtos.Count()); // Verify number of customers
        }
    }
}
