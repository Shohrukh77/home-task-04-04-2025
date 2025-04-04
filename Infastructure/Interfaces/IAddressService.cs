using Domain.Entites;
using Domain.Responces;

namespace Infastructure.Interfaces;

public interface IAddressService
{
    public Task<Response<List<Address>>> GetAllAsync();
    public Task<Response<Address>> GetByIdAsync(int id);
    public Task<Response<Address>> CreateAsync(Address student);
    public Task<Response<Address>> UpdateAsync(Address student);
    public Task<Response<string>> DeleteAsync(int id);
}