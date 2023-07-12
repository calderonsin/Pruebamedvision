using Microsoft.Extensions.Hosting;

namespace Pruebamedvision.Models
{
    public class Persona
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }

        public ICollection<Cita> Citas { get; } = new List<Cita>();
    }



    public class PersonaRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }

        public ICollection<Cita> Citas { get; } = new List<Cita>();
    }
}
