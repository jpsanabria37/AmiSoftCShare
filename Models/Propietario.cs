﻿using System;
using System.Collections.Generic;

namespace AmiSoftCShare.Models
{
    public partial class Propietario
    {
        public Propietario()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public uint Id { get; set; }
        public string NombreCompleto { get; set; }
        public uint? TipoDocumentoId { get; set; }
        public string NumeroDocumento { get; set; }
        public string TelefonoCelular { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoTrabajo { get; set; }
        public string EmailPersonal { get; set; }
        public string EmailEmpresa { get; set; }
        public string DireccionCasa { get; set; }
        public string DireccionTrabajo { get; set; }
        public bool? Estado { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
