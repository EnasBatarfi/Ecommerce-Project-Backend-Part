using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Helpers;
using Backend.Models;
using Backend.Dtos;
using Microsoft.IdentityModel.Tokens;
using SendGrid.Helpers.Errors.Model;

namespace Backend.Services;

public class AddressService
{
    private readonly AppDbContext _dbContext;

    public AddressService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<IEnumerable<Address>> GetAllAddressService(int currentPage, int pageSize)
    {
        var addresses = await _dbContext.Addresses
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return addresses;
    }
    public async Task<IEnumerable<Address>> GetAllCustomerAddressService(
     string customerId,
     int pageNumber,
     int pageSize
)
    {
        var query = _dbContext.Addresses.AsQueryable();
        var customerQuery = _dbContext.Customers.AsQueryable();
        var customer = await customerQuery.FirstOrDefaultAsync(c => c.CustomerId.ToString() == customerId);

        if (customer == null)
        {
            throw new NotFoundException($"No Customer Found With Id: {customerId}");
        }
        query = query.Where(p => p.CustomerId == customer.CustomerId);

        var addresses = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return addresses;
    }


    public async Task<Address?> GetAddressById(Guid addressId)
    {
        return await _dbContext.Addresses.FindAsync(addressId);
    }


    public async Task<Address> CreateAddressService(Address newAddress)
    {

        // Check if the address name already exists for the customer
        var existingAddress = await _dbContext.Addresses.FirstOrDefaultAsync(a => a.CustomerId == newAddress.CustomerId && a.Name == newAddress.Name);

        if (existingAddress != null)
        {
            // Address name already exists for the customer
            throw new Exception("Address name already exists for the customer.");
        }

        newAddress.AddressId = Guid.NewGuid();
        _dbContext.Addresses.Add(newAddress);
        await _dbContext.SaveChangesAsync();
        return newAddress;
    }


    public async Task<Address?> UpdateAddressService(Guid addressId, AddressDto updateAddress)
    {
        var existingAddress = await _dbContext.Addresses.FindAsync(addressId);

        if (existingAddress != null)
        {
            existingAddress.Name = updateAddress.Name.IsNullOrEmpty() ? existingAddress.Name : updateAddress.Name;
            existingAddress.AddressLine1 = updateAddress.AddressLine1.IsNullOrEmpty() ? existingAddress.AddressLine1 : updateAddress.AddressLine1;
            existingAddress.AddressLine2 = updateAddress.AddressLine2.IsNullOrEmpty() ? existingAddress.AddressLine2 : updateAddress.AddressLine2;
            existingAddress.Country = updateAddress.Country.IsNullOrEmpty() ? existingAddress.Country : updateAddress.Country;
            existingAddress.Province = updateAddress.Province.IsNullOrEmpty() ? existingAddress.Province : updateAddress.Province;
            existingAddress.City = updateAddress.City.IsNullOrEmpty() ? existingAddress.City : updateAddress.City;
            existingAddress.ZipCode = updateAddress.ZipCode.IsNullOrEmpty() ? existingAddress.ZipCode : updateAddress.ZipCode;
            await _dbContext.SaveChangesAsync();
        }

        return existingAddress;
    }


    public async Task<bool> DeleteAddressService(Guid addressId)
    {
        var addressToRemove = await _dbContext.Addresses.FindAsync(addressId);
        if (addressToRemove != null)
        {
            _dbContext.Addresses.Remove(addressToRemove);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<int> GetTotalAddressCount()
    {
        return await _dbContext.Addresses.CountAsync();
    }
    public async Task<int> GetTotalCustomerAddressCount(string customerId)
    {
        return await _dbContext.Addresses.CountAsync(a => a.CustomerId.ToString() == customerId);
    }
}