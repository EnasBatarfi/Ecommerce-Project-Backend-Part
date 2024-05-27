using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

using Backend.Helpers;
using Backend.Models;
using Backend.Services;
using SendGrid.Helpers.Errors.Model;
using Backend.Dtos;

namespace Backend.Controllers;

[Authorize]
[Route("/api/addresses")]
public class AddressController : ControllerBase
{
    private readonly AddressService _addressService;

    public AddressController(AddressService addressService)
    {
        _addressService = addressService;
    }


    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllAddress([FromQuery] int currentPage = 1, [FromQuery] int pageSize = 3)
    {
        var addresses = await _addressService.GetAllAddressService(currentPage, pageSize);
        int totalCount = await _addressService.GetTotalAddressCount();

        if (totalCount < 1)
        {
            throw new NotFoundException("No Addresses To Display");
        }

        return ApiResponse.Success(
            addresses,
            "Addresses are returned successfully", new PaginationMeta
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = totalCount
            });

    }

    [Authorize]
    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetAllCustomerAddress(string customerId, [FromQuery] int currentPage = 1, [FromQuery] int pageSize = 3)
    {
        var addresses = await _addressService.GetAllCustomerAddressService(customerId, currentPage, pageSize);
        int totalCount = await _addressService.GetTotalCustomerAddressCount(customerId);

        if (totalCount < 1)
        {
            throw new NotFoundException("No Addresses To Display");
        }

        return ApiResponse.Success(
            addresses,
            "Addresses are returned successfully", new PaginationMeta
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = totalCount
            });

    }


    [Authorize]
    [HttpGet("{addressId}")]
    public async Task<IActionResult> GetAddress(string addressId)
    {
        if (!Guid.TryParse(addressId, out Guid addressIdGuid))
        {
            throw new ValidationException("Invalid address ID Format");
        }

        var address = await _addressService.GetAddressById(addressIdGuid) ?? throw new NotFoundException($"No Address Found With ID : ({addressIdGuid})");

        return ApiResponse.Success<Address>(
            address,
            "Address is returned successfully"
        );
    }


    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateAddress([FromBody] Address newAddress)
    {
        Console.WriteLine("dekjde" + newAddress.CustomerId);
        var createdAddress = await _addressService.CreateAddressService(newAddress) ?? throw new Exception("Error when creating new address");

        return ApiResponse.Created<Address>(createdAddress, "Address is created successfully");
    }


    [Authorize]
    [HttpPut("{addressId}")]
    public async Task<IActionResult> UpdateAddress(string addressId, AddressDto updateAddress)
    {
        if (!Guid.TryParse(addressId, out Guid addressIdGuid))
        {
            throw new ValidationException("Invalid Address ID Format");
        }

        var address = await _addressService.UpdateAddressService(addressIdGuid, updateAddress) ?? throw new NotFoundException("No Address Founded To Update");

        return ApiResponse.Success<Address>(
            address,
            "Address Is Updated Successfully"
        );
    }


    [Authorize]
    [HttpDelete("{addressId}")]
    public async Task<IActionResult> DeleteAddress(string addressId)
    {
        if (!Guid.TryParse(addressId, out Guid addressIdGuid))
        {
            throw new ValidationException("Invalid address ID Format");
        }

        var result = await _addressService.DeleteAddressService(addressIdGuid);
        if (!result)
        {
            throw new NotFoundException("The Address is not found to be deleted");
        }

        return ApiResponse.Success(" Address is deleted successfully");
    }
}