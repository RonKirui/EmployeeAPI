using EmployeeAPI.Data;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly AppDbContext _db;

    public EmployeesController(AppDbContext db)
    {
        _db = db;
    }

    // GET api/employees
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _db.Employees.ToListAsync();
        return Ok(employees);
    }

    // GET api/employees/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var employee = await _db.Employees.FindAsync(id);

        if (employee is null)
            return NotFound();

        return Ok(employee);
    }

    // POST api/employees
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Employee employee)
    {
        _db.Employees.Add(employee);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
    }

    // PUT api/employees/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Employee updated)
    {
        var employee = await _db.Employees.FindAsync(id);

        if (employee is null)
            return NotFound();

        employee.Name       = updated.Name;
        employee.Email      = updated.Email;
        employee.Department = updated.Department;
        employee.Position   = updated.Position;

        await _db.SaveChangesAsync();
        return Ok(employee);
    }

    // DELETE api/employees/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var employee = await _db.Employees.FindAsync(id);

        if (employee is null)
            return NotFound();

        _db.Employees.Remove(employee);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}