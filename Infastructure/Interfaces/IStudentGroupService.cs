using Domain.Entites;
using Domain.Responces;

namespace Infastructure.Interfaces;

public interface IStudentGroupService
{
    public Task<Response<List<StudentGroup>>> GetAllAsync();
    public Task<Response<StudentGroup>> GetByIdAsync(int id);
    public Task<Response<StudentGroup>> CreateAsync(StudentGroup student);
    public Task<Response<StudentGroup>> UpdateAsync(StudentGroup student);
    public Task<Response<string>> DeleteAsync(int id);
}