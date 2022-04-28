using System;
using System.Collections.Generic;

namespace AmiSoftCShare.Models
{
    public partial class Lugare
    {
        public Lugare()
        {
            Casos = new HashSet<Caso>();
        }

        public uint Id { get; set; }
        public string Barrio { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Localidad { get; set; }
        public bool? Estado { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Caso> Casos { get; set; }
    }
}
