using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pruebamedvision.Data;
using Pruebamedvision.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pruebamedvision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly PruebatecnicaDbContext dbContext;

        public CitaController(PruebatecnicaDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetCitas()
        {
            var citas = await dbContext.Citas.ToListAsync();

            return Ok(citas) ;
            
        }

        // GET api/<ValuesController>/5
        [HttpGet("{fecha:datetime}")]
        public async Task<IActionResult> GetCitasByDate([FromRoute] DateTime fecha)
        {
            
            
            var citas = await dbContext.Citas.Where(cita => cita.Fecha == fecha).Include(cita=> cita.MotivoCitas).ToListAsync();
            if (citas == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(citas);
            }


        }

        // POST api/<ValuesController>
        [HttpPost]

        public async Task<IActionResult> AddCita(CitaRequest citarequest)
        {
            var personarequest = await dbContext.Personas.FindAsync(citarequest.PersonaId);
            
            var cita = new Cita()
            {
                Id = Guid.NewGuid(),
                observaciones = citarequest.observaciones,
                Fecha = citarequest.Fecha,
                Phone = citarequest.Phone,
                PersonaId = citarequest.PersonaId,
                Persona = personarequest
                
            };
            if (personarequest != null) {
                await dbContext.Citas.AddAsync(cita);
                personarequest.Citas.Add(cita);
                await dbContext.SaveChangesAsync();            }
               

            return Ok(cita);
        }
    }
}
