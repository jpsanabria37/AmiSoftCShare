using System;
using System.Collections.Generic;

namespace AmiSoftCShare.Models
{
    public partial class Color
    {
        public Color()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public uint Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
