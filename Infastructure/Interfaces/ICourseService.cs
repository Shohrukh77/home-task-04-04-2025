using Domain.Entites;
using Domain.Responces;

namespace Infastructure.Interfaces;

public interface ICourseService
{
    public Task<Response<List<Course>>> GetAllAsync();
    public Task<Response<Course>> GetByIdAsync(int id);
    public Task<Response<Course>> CreateAsync(Course student);
    public Task<Response<Course>> UpdateAsync(Course student);
    public Task<Response<string>> DeleteAsync(int id);
}