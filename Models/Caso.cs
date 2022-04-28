using System;
using System.Collections.Generic;

namespace AmiSoftCShare.Models
{
    public partial class Caso
    {
        public Caso()
        {
            Alumbrados = new HashSet<Alumbrado>();
            ControlCalidades = new HashSet<ControlCalidade>();
            DebajoCapos = new HashSet<DebajoCapo>();
            Estanqueidads = new HashSet<Estanqueidad>();
            Instrumentos = new HashSet<Instrumento>();
            PresionLlanta = new HashSet<PresionLlanta>();
            Puerta = new HashSet<Puerta>();
        }

        public uint Id { get; set; }
        public uint? LugarId { get; set; }
        public uint? VehiculoId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Lugare Lugar { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
        public virtual ICollection<Alumbrado> Alumbrados { get; set; }
        public virtual ICollection<ControlCalidade> ControlCalidades { get; set; }
        public virtual ICollection<DebajoCapo> DebajoCapos { get; set; }
        public virtual ICollection<Estanqueidad> Estanqueidads { get; set; }
        public virtual ICollection<Instrumento> Instrumentos { get; set; }
        public virtual ICollection<PresionLlanta> PresionLlanta { get; set; }
        public virtual ICollection<Puerta> Puerta { get; set; }
    }
}
