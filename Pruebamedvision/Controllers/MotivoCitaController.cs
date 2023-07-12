using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pruebamedvision.Data;
using Pruebamedvision.Models;
using Microsoft.AspNetCore.Authorization;

namespace Pruebamedvision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class MotivoCitaController : ControllerBase
    {
        private readonly PruebatecnicaDbContext dbContext;

        public MotivoCitaController(PruebatecnicaDbContext dbContext)
        {
            this.dbContext = dbContext;

        }


        [HttpPost]
        public async Task<IActionResult> AddMotivoCita(MotivoCitaRequest motivocitarequest)
        {
            var citarequest = await dbContext.Citas.FindAsync(motivocitarequest.CitaId);

            var motivocita = new MotivoCita()
            {
                Id = Guid.NewGuid(),
                Detalle = motivocitarequest.Detalle,
                CitaId = motivocitarequest.CitaId

            };
            if (citarequest != null)
            {
                await dbContext.MotivoCitas.AddAsync(motivocita);
                citarequest.MotivoCitas.Add(motivocita);
                await dbContext.SaveChangesAsync();
            }


            return Ok(motivocita);
        }


        [HttpGet("{id:Guid}")]
        public  ActionResult<int> GetCitasByDate([FromRoute] Guid id)
        {
            int count =  dbContext.Citas.Where(cita => cita.MotivoCitas.Any(Motivocita => Motivocita.Id == id)).Count();
            return Ok(count);
            


        }
    }
}
