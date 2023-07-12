using System.Reflection.Metadata;

namespace Pruebamedvision.Models
{
    public class Cita
    {
        public Guid Id { get; set; }
        public string observaciones { get; set; }
        public DateTime Fecha { get; set; }
        public long Phone { get; set; }

        public Guid PersonaId { get; set; } // Optional foreign key property
        public Persona Persona { get; set; } = null!; // Optional reference navigation to principal

        public ICollection<MotivoCita> MotivoCitas { get; } = new List<MotivoCita>();
    }

    public class CitaRequest    {
        public string observaciones { get; set; }
        public DateTime Fecha { get; set; }
        public long Phone { get; set; }

        public Guid PersonaId { get; set; } // Optional foreign key property

        public ICollection<MotivoCita> MotivoCitas { get; } = new List<MotivoCita>();
    }
}
