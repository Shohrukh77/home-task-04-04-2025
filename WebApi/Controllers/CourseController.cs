using Domain.Entites;
using Domain.Responces;
using Infastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CourseController(ICourseService courseService)
{
    [HttpGet]
    public async Task<Response<List<Course>>> Get()
    {
        var courses = await courseService.GetAllAsync();
        return courses;
    }

    [HttpPost]
    public async Task<Response<Course>> Post(Course course)
    {
        var result = await courseService.CreateAsync(course);
        return result;
    }

    [HttpPut]
    public async Task<Response<Course>> Put(Course course)
    {
        var result = await courseService.UpdateAsync(course);
        return result;
    }

    [HttpDelete("{id:int}")]
    public async Task<Response<string>> Delete(int id)
    {
        var result = await courseService.DeleteAsync(id);
        return result;
    }
}