using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AmiSoftCShare.Models
{
    public partial class amisoftdatabaseContext : DbContext
    {
        public amisoftdatabaseContext()
        {
        }

        public amisoftdatabaseContext(DbContextOptions<amisoftdatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumbrado> Alumbrados { get; set; }
        public virtual DbSet<Caso> Casos { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<ControlCalidade> ControlCalidades { get; set; }
        public virtual DbSet<DebajoCapo> DebajoCapos { get; set; }
        public virtual DbSet<Estanqueidad> Estanqueidads { get; set; }
        public virtual DbSet<Instrumento> Instrumentos { get; set; }
        public virtual DbSet<Lugare> Lugares { get; set; }
        public virtual DbSet<Migration> Migrations { get; set; }
        public virtual DbSet<PresionLlanta> PresionLlantas { get; set; }
        public virtual DbSet<Propietario> Propietarios { get; set; }
        public virtual DbSet<Puerta> Puertas { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<RolUsuario> RolUsuarios { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=amisoftdatabase;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.33-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Alumbrado>(entity =>
            {
                entity.ToTable("alumbrados");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CasoId, "alumbrados_caso_id_foreign");

                entity.HasIndex(e => e.ControlcalidadId, "alumbrados_controlcalidad_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Antiniebla).HasColumnName("antiniebla");

                entity.Property(e => e.CasoId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("caso_id");

                entity.Property(e => e.ControlcalidadId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("controlcalidad_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.DireccionalesRepetidoresEstacionarias).HasColumnName("direccionales_repetidores_estacionarias");

                entity.Property(e => e.GuanteraLuzTechoBaul).HasColumnName("guantera_luz_techo_baul");

                entity.Property(e => e.LuzAltaBajaPosicion).HasColumnName("luz_alta_baja_posicion");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("text")
                    .HasColumnName("observaciones");

                entity.Property(e => e.ReversaPlaca).HasColumnName("reversa_placa");

                entity.Property(e => e.Stops).HasColumnName("stops");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Caso)
                    .WithMany(p => p.Alumbrados)
                    .HasForeignKey(d => d.CasoId)
                    .HasConstraintName("alumbrados_caso_id_foreign");

                entity.HasOne(d => d.Controlcalidad)
                    .WithMany(p => p.Alumbrados)
                    .HasForeignKey(d => d.ControlcalidadId)
                    .HasConstraintName("alumbrados_controlcalidad_id_foreign");
            });

            modelBuilder.Entity<Caso>(entity =>
            {
                entity.ToTable("casos");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.LugarId, "casos_lugar_id_foreign");

                entity.HasIndex(e => e.VehiculoId, "casos_vehiculo_id_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.LugarId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("lugar_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.VehiculoId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("vehiculo_id");

                entity.HasOne(d => d.Lugar)
                    .WithMany(p => p.Casos)
                    .HasForeignKey(d => d.LugarId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("casos_lugar_id_foreign");

                entity.HasOne(d => d.Vehiculo)
                    .WithOne(p => p.Caso)
                    .HasForeignKey<Caso>(d => d.VehiculoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("casos_vehiculo_id_foreign");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("colors");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("nombre");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<ControlCalidade>(entity =>
            {
                entity.ToTable("control_calidades");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CasoId, "control_calidades_caso_id_foreign");

                entity.HasIndex(e => e.UsuarioId, "control_calidades_usuario_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CasoId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("caso_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.FechProximoServicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fechProximoServicio");

                entity.Property(e => e.FechaComienzo)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaComienzo");

                entity.Property(e => e.Kilometraje)
                    .HasColumnType("int(11)")
                    .HasColumnName("kilometraje");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UsuarioId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("usuario_id");

                entity.HasOne(d => d.Caso)
                    .WithMany(p => p.ControlCalidades)
                    .HasForeignKey(d => d.CasoId)
                    .HasConstraintName("control_calidades_caso_id_foreign");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.ControlCalidades)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("control_calidades_usuario_id_foreign");
            });

            modelBuilder.Entity<DebajoCapo>(entity =>
            {
                entity.ToTable("debajo_capos");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CasoId, "debajo_capos_caso_id_foreign");

                entity.HasIndex(e => e.ControlcalidadId, "debajo_capos_controlcalidad_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AceiteMotor).HasColumnName("aceite_motor");

                entity.Property(e => e.BateriaFijacionAjustesTerminales).HasColumnName("bateria_fijacion_ajustes_terminales");

                entity.Property(e => e.CajaCambios).HasColumnName("caja_cambios");

                entity.Property(e => e.CasoId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("caso_id");

                entity.Property(e => e.CircuitoDireccionAsistida).HasColumnName("circuito_direccion_asistida");

                entity.Property(e => e.CircuitoRefrigeracionEstanquidad).HasColumnName("circuito_refrigeracion_estanquidad");

                entity.Property(e => e.ControlcalidadId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("controlcalidad_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.LimpiaParabrisasDelanteroTrasero).HasColumnName("limpia_parabrisas_delantero_trasero");

                entity.Property(e => e.LiquidoFrenos).HasColumnName("liquido_frenos");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("text")
                    .HasColumnName("observaciones");

                entity.Property(e => e.TensionCorreasAccesorios).HasColumnName("tension_correas_accesorios");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Caso)
                    .WithMany(p => p.DebajoCapos)
                    .HasForeignKey(d => d.CasoId)
                    .HasConstraintName("debajo_capos_caso_id_foreign");

                entity.HasOne(d => d.Controlcalidad)
                    .WithMany(p => p.DebajoCapos)
                    .HasForeignKey(d => d.ControlcalidadId)
                    .HasConstraintName("debajo_capos_controlcalidad_id_foreign");
            });

            modelBuilder.Entity<Estanqueidad>(entity =>
            {
                entity.ToTable("estanqueidad");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CasoId, "estanqueidad_caso_id_foreign");

                entity.HasIndex(e => e.ControlcalidadId, "estanqueidad_controlcalidad_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Amortiguadores).HasColumnName("amortiguadores");

                entity.Property(e => e.CajaVelocidades).HasColumnName("caja_velocidades");

                entity.Property(e => e.CasoId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("caso_id");

                entity.Property(e => e.CircuitoFrenos).HasColumnName("circuito_frenos");

                entity.Property(e => e.ControlcalidadId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("controlcalidad_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.DireccionAsistida).HasColumnName("direccion_asistida");

                entity.Property(e => e.Motor).HasColumnName("motor");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("text")
                    .HasColumnName("observaciones");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Caso)
                    .WithMany(p => p.Estanqueidads)
                    .HasForeignKey(d => d.CasoId)
                    .HasConstraintName("estanqueidad_caso_id_foreign");

                entity.HasOne(d => d.Controlcalidad)
                    .WithMany(p => p.Estanqueidads)
                    .HasForeignKey(d => d.ControlcalidadId)
                    .HasConstraintName("estanqueidad_controlcalidad_id_foreign");
            });

            modelBuilder.Entity<Instrumento>(entity =>
            {
                entity.ToTable("instrumentos");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CasoId, "instrumentos_caso_id_foreign");

                entity.HasIndex(e => e.ControlcalidadId, "instrumentos_controlcalidad_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.ActivacionAlarmaSonora).HasColumnName("activacion_alarma_sonora");

                entity.Property(e => e.Bocina).HasColumnName("bocina");

                entity.Property(e => e.CasoId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("caso_id");

                entity.Property(e => e.ControlcalidadId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("controlcalidad_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.EspejosRetrovisores).HasColumnName("espejos_retrovisores");

                entity.Property(e => e.EstadoLimpiaParabrisas).HasColumnName("estado_limpia_parabrisas");

                entity.Property(e => e.IndicadoresAbordo).HasColumnName("indicadores_abordo");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("text")
                    .HasColumnName("observaciones");

                entity.Property(e => e.OrdenadorLimpiaParabrisas).HasColumnName("ordenador_limpia_parabrisas");

                entity.Property(e => e.RelojAbordo).HasColumnName("reloj_abordo");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.VentilacionCalefaccionAireacondicionado).HasColumnName("ventilacion_calefaccion_aireacondicionado");

                entity.HasOne(d => d.Caso)
                    .WithMany(p => p.Instrumentos)
                    .HasForeignKey(d => d.CasoId)
                    .HasConstraintName("instrumentos_caso_id_foreign");

                entity.HasOne(d => d.Controlcalidad)
                    .WithMany(p => p.Instrumentos)
                    .HasForeignKey(d => d.ControlcalidadId)
                    .HasConstraintName("instrumentos_controlcalidad_id_foreign");
            });

            modelBuilder.Entity<Lugare>(entity =>
            {
                entity.ToTable("lugares");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Barrio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("barrio");

                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ciudad");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("direccion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Localidad)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("localidad");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Migration>(entity =>
            {
                entity.ToTable("migrations");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Batch)
                    .HasColumnType("int(11)")
                    .HasColumnName("batch");

                entity.Property(e => e.Migration1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("migration");
            });

            modelBuilder.Entity<PresionLlanta>(entity =>
            {
                entity.ToTable("presion_llantas");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CasoId, "presion_llantas_caso_id_foreign");

                entity.HasIndex(e => e.ControlcalidadId, "presion_llantas_controlcalidad_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CasoId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("caso_id");

                entity.Property(e => e.ControlcalidadId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("controlcalidad_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("text")
                    .HasColumnName("observaciones");

                entity.Property(e => e.PresionDelanteraDerecha)
                    .HasColumnType("int(11)")
                    .HasColumnName("presion_delantera_derecha");

                entity.Property(e => e.PresionDelanteraIzquierda)
                    .HasColumnType("int(11)")
                    .HasColumnName("presion_delantera_izquierda");

                entity.Property(e => e.PresionTraseraDerecha)
                    .HasColumnType("int(11)")
                    .HasColumnName("presion_trasera_derecha");

                entity.Property(e => e.PresionTraseraIzquierda)
                    .HasColumnType("int(11)")
                    .HasColumnName("presion_trasera_izquierda");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Caso)
                    .WithMany(p => p.PresionLlanta)
                    .HasForeignKey(d => d.CasoId)
                    .HasConstraintName("presion_llantas_caso_id_foreign");

                entity.HasOne(d => d.Controlcalidad)
                    .WithMany(p => p.PresionLlanta)
                    .HasForeignKey(d => d.ControlcalidadId)
                    .HasConstraintName("presion_llantas_controlcalidad_id_foreign");
            });

            modelBuilder.Entity<Propietario>(entity =>
            {
                entity.ToTable("propietarios");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.EmailEmpresa, "propietarios_emailempresa_unique")
                    .IsUnique();

                entity.HasIndex(e => e.EmailPersonal, "propietarios_emailpersonal_unique")
                    .IsUnique();

                entity.HasIndex(e => e.TipoDocumentoId, "propietarios_tipodocumento_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.DireccionCasa)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("direccionCasa");

                entity.Property(e => e.DireccionTrabajo)
                    .HasMaxLength(64)
                    .HasColumnName("direccionTrabajo");

                entity.Property(e => e.EmailEmpresa)
                    .HasMaxLength(64)
                    .HasColumnName("emailEmpresa");

                entity.Property(e => e.EmailPersonal)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("emailPersonal");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.NumeroDocumento)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("numeroDocumento");

                entity.Property(e => e.TelefonoCelular)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("telefonoCelular");

                entity.Property(e => e.TelefonoFijo)
                    .HasMaxLength(14)
                    .HasColumnName("telefonoFijo");

                entity.Property(e => e.TelefonoTrabajo)
                    .HasMaxLength(14)
                    .HasColumnName("telefonoTrabajo");

                entity.Property(e => e.TipoDocumentoId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("tipoDocumento_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.TipoDocumento)
                    .WithMany(p => p.Propietarios)
                    .HasForeignKey(d => d.TipoDocumentoId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("propietarios_tipodocumento_id_foreign");
            });

            modelBuilder.Entity<Puerta>(entity =>
            {
                entity.ToTable("puertas");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CasoId, "puertas_caso_id_foreign");

                entity.HasIndex(e => e.ControlcalidadId, "puertas_controlcalidad_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CasoId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("caso_id");

                entity.Property(e => e.ControlCerraduras).HasColumnName("control_cerraduras");

                entity.Property(e => e.ControlPuertasCapoBaul).HasColumnName("control_puertas_capo_baul");

                entity.Property(e => e.ControlcalidadId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("controlcalidad_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("text")
                    .HasColumnName("observaciones");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Caso)
                    .WithMany(p => p.Puerta)
                    .HasForeignKey(d => d.CasoId)
                    .HasConstraintName("puertas_caso_id_foreign");

                entity.HasOne(d => d.Controlcalidad)
                    .WithMany(p => p.Puerta)
                    .HasForeignKey(d => d.ControlcalidadId)
                    .HasConstraintName("puertas_controlcalidad_id_foreign");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rols");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("nombre");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<RolUsuario>(entity =>
            {
                entity.ToTable("rol_usuarios");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.RolId, "rol_usuarios_rol_id_foreign");

                entity.HasIndex(e => e.UsuarioId, "rol_usuarios_usuario_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.RolId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("rol_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UsuarioId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("usuario_id");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.RolUsuarios)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("rol_usuarios_rol_id_foreign");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.RolUsuarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("rol_usuarios_usuario_id_foreign");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.ToTable("tipo_documentos");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("nombre");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.EmailEmpresa, "usuarios_emailempresa_unique")
                    .IsUnique();

                entity.HasIndex(e => e.EmailPersonal, "usuarios_emailpersonal_unique")
                    .IsUnique();

                entity.HasIndex(e => e.TipoDocumentoId, "usuarios_tipodocumento_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.DireccionCasa)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("direccionCasa");

                entity.Property(e => e.DireccionTrabajo)
                    .HasMaxLength(64)
                    .HasColumnName("direccionTrabajo");

                entity.Property(e => e.EmailEmpresa)
                    .HasMaxLength(64)
                    .HasColumnName("emailEmpresa");

                entity.Property(e => e.EmailPersonal)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("emailPersonal");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("nombreUsuario");

                entity.Property(e => e.NumeroDocumento)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("numeroDocumento");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.TelefonoCelular)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("telefonoCelular");

                entity.Property(e => e.TelefonoFijo)
                    .HasMaxLength(14)
                    .HasColumnName("telefonoFijo");

                entity.Property(e => e.TelefonoTrabajo)
                    .HasMaxLength(14)
                    .HasColumnName("telefonoTrabajo");

                entity.Property(e => e.TipoDocumentoId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("tipoDocumento_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.TipoDocumento)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoDocumentoId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("usuarios_tipodocumento_id_foreign");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.ToTable("vehiculos");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.ColorId, "vehiculos_color_id_foreign");

                entity.HasIndex(e => e.PropietarioId, "vehiculos_propietario_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.ColorId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("color_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("marca");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("modelo");

                entity.Property(e => e.NumeroMotor)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("numeroMotor");

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("placa");

                entity.Property(e => e.PropietarioId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("propietario_id");

                entity.Property(e => e.Serie)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("serie");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("vehiculos_color_id_foreign");

                entity.HasOne(d => d.Propietario)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.PropietarioId)
                    .HasConstraintName("vehiculos_propietario_id_foreign");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
