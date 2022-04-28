using System;
using System.Collections.Generic;

namespace AmiSoftCShare.Models
{
    public partial class Vehiculo
    {
        public uint Id { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string NumeroMotor { get; set; }
        public uint? ColorId { get; set; }
        public uint PropietarioId { get; set; }
        public bool? Estado { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Color Color { get; set; }
        public virtual Propietario Propietario { get; set; }
        public virtual Caso Caso { get; set; }
    }
}
