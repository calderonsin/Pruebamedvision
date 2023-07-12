using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pruebamedvision.Models;
using Pruebamedvision.Data;

namespace Pruebamedvision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly PruebatecnicaDbContext dbContext;

        public PersonaController(PruebatecnicaDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        [HttpGet]
        public async Task<IActionResult> GetPersonas()
        {
            return Ok(await dbContext.Personas.Include(persona => persona.Citas).ToListAsync());



        }
        [HttpPost]
        public async Task<IActionResult> AddPersona(PersonaRequest personarequest)
        {
            var persona = new Persona()
            {
                Id = Guid.NewGuid(),
                Email = personarequest.Email,
                FullName = personarequest.FullName,
                Phone = personarequest.Phone          

            };
            await dbContext.Personas.AddAsync(persona);
            await dbContext.SaveChangesAsync();

            return Ok(persona);
        }
    }
}
