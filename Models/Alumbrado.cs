using System;
using System.Collections.Generic;

namespace AmiSoftCShare.Models
{
    public partial class Alumbrado
    {
        public uint Id { get; set; }
        public uint ControlcalidadId { get; set; }
        public uint CasoId { get; set; }
        public bool LuzAltaBajaPosicion { get; set; }
        public bool DireccionalesRepetidoresEstacionarias { get; set; }
        public bool Stops { get; set; }
        public bool ReversaPlaca { get; set; }
        public bool Antiniebla { get; set; }
        public bool GuanteraLuzTechoBaul { get; set; }
        public string Observaciones { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Caso Caso { get; set; }
        public virtual ControlCalidade Controlcalidad { get; set; }
    }
}
