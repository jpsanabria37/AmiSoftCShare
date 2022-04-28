using System;
using System.Collections.Generic;

namespace AmiSoftCShare.Models
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Propietarios = new HashSet<Propietario>();
            Usuarios = new HashSet<Usuario>();
        }

        public uint Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Propietario> Propietarios { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
