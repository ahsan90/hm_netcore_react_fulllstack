using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class TestController : BaseApiController
    {
        private readonly DataContext _context;
        public TestController(DataContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Test>> Get()
        {
            var tests = await _context.Tests.ToListAsync();
            return Ok(tests);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> Get(int id)
        {
            var test = await _context.Tests.FindAsync(id);
            return Ok(test);
        }
    }
}