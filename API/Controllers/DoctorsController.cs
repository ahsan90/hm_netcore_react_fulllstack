
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Doctors;
//using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DoctorsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetDoctors()
        {
            return await Mediator.Send(new List.Query());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(Doctor doctor)
        {
            return Ok(await Mediator.Send(new Create.Command { Doctor = doctor }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditDoctor(Guid id, Doctor doctor)
        {
            doctor.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Doctor = doctor }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}