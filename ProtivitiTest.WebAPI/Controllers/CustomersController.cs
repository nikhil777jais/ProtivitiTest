using ProtivitiTest.WebAPI.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProtivitiTest.WebAPI.DTOs;
using ProtivitiTest.WebAPI.Models;
using ProtivitiTest.WebAPI.Repositories.CustomerRepo;
using System.Net;
using System;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace ProtivitiTest.WebAPI.Controllers
{
    public class CustomersController : BaseAPIController
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            try
            {
                var customers = await _customerRepository.GetAllCustomer();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message} \n Stack Trace:  {ex.StackTrace}");
            }
        }

        [HttpGet("{customerId:guid}")]
        public async Task<ActionResult> GetCustomersByGuid(Guid customerId)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerById(customerId);
                if (customer == null)
                    return NotFound();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message} \n Stack Trace:  {ex.StackTrace}");
            }
        }

        [HttpGet("{age:int}")]
        public async Task<ActionResult> GetCustomersAge(int age)
        {
            try
            {
                var customer = await _customerRepository.GetAllCustomerByAge(age);
                if (customer == null)
                    return NotFound();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message} \n Stack Trace:  {ex.StackTrace}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer(CustomerDto customerDto)
        {
            try
            {
                var customer = await _customerRepository.CreateCustomer(customerDto);
                if (!await _customerRepository.Complete())
                    return BadRequest();

                var customerToReturn = _mapper.Map<CustomerDto>(customer);
                return Created("", customerToReturn);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message} \n Stack Trace:  {ex.StackTrace}");
            }
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult> PatchCustomer(Guid id, [FromBody] JsonPatchDocument<Customer> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            try
            {
                var res = await _customerRepository.UpdateCustomer(id, patchDoc);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}