namespace Pruebamedvision.Models
{
    public class MotivoCita


    {
        public Guid Id { get; set; }
        public string Detalle { get; set; }
        public ICollection<Cita> Citas { get; } = new List<Cita>();

        public Guid CitaId { get; set; } // Optional foreign key property


    }

    public class MotivoCitaRequest
    {
        public Guid CitaId { get; set; } // Optional foreign key property
        public string Detalle { get; set; }
        
    }
}
