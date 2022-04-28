using System;
using System.Collections.Generic;

namespace AmiSoftCShare.Models
{
    public partial class Instrumento
    {
        public uint Id { get; set; }
        public uint ControlcalidadId { get; set; }
        public uint CasoId { get; set; }
        public bool IndicadoresAbordo { get; set; }
        public bool RelojAbordo { get; set; }
        public bool OrdenadorLimpiaParabrisas { get; set; }
        public bool VentilacionCalefaccionAireacondicionado { get; set; }
        public bool Bocina { get; set; }
        public bool EstadoLimpiaParabrisas { get; set; }
        public bool EspejosRetrovisores { get; set; }
        public bool ActivacionAlarmaSonora { get; set; }
        public string Observaciones { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Caso Caso { get; set; }
        public virtual ControlCalidade Controlcalidad { get; set; }
    }
}
