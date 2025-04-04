using System.Net;
using Domain.Entites;
using Domain.Responces;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Services;

public class StudentGroupService(DataContext context) : IStudentGroupService
{
    public async Task<Response<List<StudentGroup>>> GetAllAsync()
    {
        var studentGroups = await context.StudentGroups.ToListAsync();
        return new Response<List<StudentGroup>>(studentGroups);
    }

    public async Task<Response<StudentGroup>> GetByIdAsync(int id)
    {
        var studentGroup = await context.StudentGroups.FindAsync(id);
        
        return studentGroup == null 
            ? new Response<StudentGroup>(HttpStatusCode.BadRequest, "StudentGroup not found") 
            : new Response<StudentGroup>(studentGroup);
    }

    public async Task<Response<StudentGroup>> CreateAsync(StudentGroup studentGroup) 
    {
        await context.StudentGroups.AddAsync(studentGroup);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<StudentGroup>(HttpStatusCode.BadRequest, "StudentGroup not created") 
            : new Response<StudentGroup>(studentGroup);
    }

    public async Task<Response<StudentGroup>> UpdateAsync(StudentGroup studentGroup)
    {
        context.StudentGroups.Update(studentGroup);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<StudentGroup>(HttpStatusCode.BadRequest, "StudentGroup not updated") 
            : new Response<StudentGroup>(studentGroup);
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var studentGroup = await context.StudentGroups.FindAsync(id);

        if (studentGroup == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "StudentGroup not found");
        }

        context.Remove(studentGroup);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<string>(HttpStatusCode.BadRequest, "StudentGroup not deleted") 
            : new Response<string>("StudentGroup deleted successfully");
        
    }
}