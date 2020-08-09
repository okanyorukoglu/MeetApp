using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace MeetApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : Controller
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
             var value = await _context.Values.FirstOrDefaultAsync(x =>x.Id == id);
             return Ok(value);
        }



    }
}