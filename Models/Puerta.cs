using System;
using System.Collections.Generic;

namespace AmiSoftCShare.Models
{
    public partial class Puerta
    {
        public uint Id { get; set; }
        public uint ControlcalidadId { get; set; }
        public uint CasoId { get; set; }
        public bool ControlPuertasCapoBaul { get; set; }
        public bool ControlCerraduras { get; set; }
        public string Observaciones { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Caso Caso { get; set; }
        public virtual ControlCalidade Controlcalidad { get; set; }
    }
}
