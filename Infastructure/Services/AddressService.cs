using System.Net;
using Domain.Entites;
using Domain.Responces;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Services;

public class AddressService(DataContext context) : IAddressService
{
    public async Task<Response<List<Address>>> GetAllAsync()
    {
        var address = await context.Addresses.ToListAsync();
        return new Response<List<Address>>(address);
    }

    public async Task<Response<Address>> GetByIdAsync(int id)
    {
        var address = await context.Addresses.FindAsync(id);
        
        return address == null 
            ? new Response<Address>(HttpStatusCode.BadRequest, "address not found") 
            : new Response<Address>(address);
    }

    public async Task<Response<Address>> CreateAsync(Address address) 
    {
        await context.Addresses.AddAsync(address);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<Address>(HttpStatusCode.BadRequest, "address not created") 
            : new Response<Address>(address);
    }

    public async Task<Response<Address>> UpdateAsync(Address address)
    {
        context.Addresses.Update(address);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<Address>(HttpStatusCode.BadRequest, "address not updated") 
            : new Response<Address>(address);
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var address = await context.Addresses.FindAsync(id);

        if (address == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "address not found");
        }

        context.Remove(address);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<string>(HttpStatusCode.BadRequest, "address not deleted") 
            : new Response<string>("address deleted successfully");
        
    }
}