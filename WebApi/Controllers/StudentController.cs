using Domain.Entites;
using Domain.Responces;
using Infastructure.Data;
using Infastructure.Interfaces;
using Infastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService studentService)
{
    [HttpGet]
    public async Task<Response<List<Student>>> GetAll()
    {
        var students = await studentService.GetAllAsync();
        return students;
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Student>> Get(int id)
    {
        var student = await studentService.GetByIdAsync(id);
        return student;
    }

    [HttpPost]
    public async Task<Response<Student>> Post(Student student)
    {
       var result = await studentService.CreateAsync(student);
       return result;
    }

    [HttpPut]
    public async Task<Response<Student>> Put(Student student)
    {
        var result = await studentService.UpdateAsync(student);
        return result;
    }

    [HttpDelete("{id:int}")]
    public async Task<Response<string>> Delete(int id)
    {
        var result = await studentService.DeleteAsync(id);
        return result;
    }
}