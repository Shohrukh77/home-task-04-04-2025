using Domain.Entites;
using Domain.Responces;
using Infastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AddressController(IAddressService addressService)
{
    [HttpGet]
    public async Task<Response<List<Address>>> Get(int id)
    {
        var addresses =  await addressService.GetAllAsync();
        return addresses;
    }

    [HttpPost]
    public async Task<Response<Address>> Post(Address address)
    {
        var result = await addressService.CreateAsync(address);
        return result;
    }

    [HttpPut]
    public async Task<Response<Address>> Put(Address address)
    {
        var result = await addressService.UpdateAsync(address);
        return result;
    }

    [HttpGet("{id:int}")]
    public async Task<Response<string>> Delete(int id)
    {
        var result = await addressService.DeleteAsync(id);
        return result;
    }
}