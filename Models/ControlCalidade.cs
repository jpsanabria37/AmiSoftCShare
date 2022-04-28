using System;
using System.Collections.Generic;

namespace AmiSoftCShare.Models
{
    public partial class ControlCalidade
    {
        public ControlCalidade()
        {
            Alumbrados = new HashSet<Alumbrado>();
            DebajoCapos = new HashSet<DebajoCapo>();
            Estanqueidads = new HashSet<Estanqueidad>();
            Instrumentos = new HashSet<Instrumento>();
            PresionLlanta = new HashSet<PresionLlanta>();
            Puerta = new HashSet<Puerta>();
        }

        public uint Id { get; set; }
        public uint CasoId { get; set; }
        public uint UsuarioId { get; set; }
        public DateTime FechaComienzo { get; set; }
        public DateTime? FechProximoServicio { get; set; }
        public int Kilometraje { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Caso Caso { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Alumbrado> Alumbrados { get; set; }
        public virtual ICollection<DebajoCapo> DebajoCapos { get; set; }
        public virtual ICollection<Estanqueidad> Estanqueidads { get; set; }
        public virtual ICollection<Instrumento> Instrumentos { get; set; }
        public virtual ICollection<PresionLlanta> PresionLlanta { get; set; }
        public virtual ICollection<Puerta> Puerta { get; set; }
    }
}
