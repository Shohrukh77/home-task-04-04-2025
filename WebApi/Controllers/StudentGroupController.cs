using Domain.Entites;
using Domain.Responces;
using Infastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class StudentGroupController(IStudentGroupService  studentGroupService)
{
    [HttpGet]
    public async Task<Response<List<StudentGroup>>> GetAll()
    {
        var studentGroups = await studentGroupService.GetAllAsync();
        return studentGroups;
    }

    [HttpGet("{id:int}")]
    public async Task<Response<StudentGroup>> Get(int id)
    {
        var studentGroup = await studentGroupService.GetByIdAsync(id);
        return studentGroup;
    }

    [HttpPost]
    public async Task<Response<StudentGroup>> Post(StudentGroup studentGroup)
    {
        var result = await studentGroupService.CreateAsync(studentGroup);
        return result;
    }

    [HttpPut]
    public async Task<Response<StudentGroup>> Put(StudentGroup studentGroup)
    {
        var result = await studentGroupService.UpdateAsync(studentGroup);
        return result;
    }

    [HttpDelete("{id:int}")]
    public async Task<Response<string>> Delete(int id)
    {
        var result = await studentGroupService.DeleteAsync(id);
        return result;
    }
}