using System.Text.RegularExpressions;
using Domain.Responces;

namespace Infastructure.Interfaces;

public interface IGroupService
{
    public Task<Response<List<Group>>> GetAllAsync();
    public Task<Response<Group>> GetByIdAsync(int id);
    public Task<Response<Group>> CreateAsync(Group student);
    public Task<Response<Group>> UpdateAsync(Group student);
    public Task<Response<string>> DeleteAsync(int id);
}