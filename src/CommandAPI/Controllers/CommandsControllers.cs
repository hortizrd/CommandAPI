using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Data;
using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandContext _repository;
        public CommandsController(ICommandContext repository) {
            _repository = repository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _repository.Command.ToListAsync();
            if (students == null) return NotFound();
            return Ok(students);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _repository.Command.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (student == null) return NotFound();
            return Ok(student);
        }

    }
}
