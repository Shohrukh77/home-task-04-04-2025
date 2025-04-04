using Domain.Entites;
using Domain.Responces;

namespace Infastructure.Interfaces;

public interface IStudentService
{
    public Task<Response<List<Student>>> GetAllAsync();
    public Task<Response<Student>> GetByIdAsync(int id);
    public Task<Response<Student>> CreateAsync(Student student);
    public Task<Response<Student>> UpdateAsync(Student student);
    public Task<Response<string>> DeleteAsync(int id);
}