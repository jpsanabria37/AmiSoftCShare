using System;
using System.Collections.Generic;

namespace AmiSoftCShare.Models
{
    public partial class DebajoCapo
    {
        public uint Id { get; set; }
        public uint ControlcalidadId { get; set; }
        public uint CasoId { get; set; }
        public bool AceiteMotor { get; set; }
        public bool LiquidoFrenos { get; set; }
        public bool CircuitoRefrigeracionEstanquidad { get; set; }
        public bool CajaCambios { get; set; }
        public bool CircuitoDireccionAsistida { get; set; }
        public bool BateriaFijacionAjustesTerminales { get; set; }
        public bool LimpiaParabrisasDelanteroTrasero { get; set; }
        public bool TensionCorreasAccesorios { get; set; }
        public string Observaciones { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Caso Caso { get; set; }
        public virtual ControlCalidade Controlcalidad { get; set; }
    }
}
