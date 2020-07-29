using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Commander.Modelss
{
    public partial class agendaelectronicaContext : DbContext
    {
        public agendaelectronicaContext()
        {
        }

        public agendaelectronicaContext(DbContextOptions<agendaelectronicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatCentros> CatCentros { get; set; }
        public virtual DbSet<CatDiasInhabiles> CatDiasInhabiles { get; set; }
        public virtual DbSet<CatDiasInhabilesMuni> CatDiasInhabilesMuni { get; set; }
        public virtual DbSet<CatMunicipios> CatMunicipios { get; set; }
        public virtual DbSet<CatNiveles> CatNiveles { get; set; }
        public virtual DbSet<CatTipoAgenda> CatTipoAgenda { get; set; }
        public virtual DbSet<CatTipoEstatus> CatTipoEstatus { get; set; }
        public virtual DbSet<CatTipoTramite> CatTipoTramite { get; set; }
        public virtual DbSet<CatUsuarios> CatUsuarios { get; set; }
        public virtual DbSet<ProAgendas> ProAgendas { get; set; }
        public virtual DbSet<ProCitas> ProCitas { get; set; }
        public virtual DbSet<ProCitasDetalle> ProCitasDetalle { get; set; }
        public virtual DbSet<ProDias> ProDias { get; set; }
        public virtual DbSet<ProHoras> ProHoras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=201.161.72.36;port=3306;user=remote;password=S3rv1d0raldebqrqn2020!;database=agendaelectronica");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatCentros>(entity =>
            {
                entity.HasKey(e => e.CentId)
                    .HasName("PRIMARY");

                entity.ToTable("cat_centros");

                entity.HasComment("Centros de trabajo del estado");

                entity.HasIndex(e => e.MuniId)
                    .HasName("fk_cat_centros_-_cat_municipios_idx");

                entity.Property(e => e.CentId).HasColumnName("cent_id");

                entity.Property(e => e.CentClave)
                    .HasColumnName("cent_clave")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CentDescripcion)
                    .IsRequired()
                    .HasColumnName("cent_descripcion")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CentTipo).HasColumnName("cent_tipo");

                entity.Property(e => e.MuniId).HasColumnName("muni_id");

                entity.Property(e => e.TiesId)
                    .HasColumnName("ties_id")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.Muni)
                    .WithMany(p => p.CatCentros)
                    .HasForeignKey(d => d.MuniId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cat_centros_-_cat_municipios");
            });

            modelBuilder.Entity<CatDiasInhabiles>(entity =>
            {
                entity.HasKey(e => e.DiinId)
                    .HasName("PRIMARY");

                entity.ToTable("cat_dias_inhabiles");

                entity.HasComment("Dias inhabiles en el año");

                entity.Property(e => e.DiinId).HasColumnName("diin_id");

                entity.Property(e => e.DiinDia)
                    .HasColumnName("diin_dia")
                    .HasColumnType("date");

                entity.Property(e => e.DiinTipo).HasColumnName("diin_tipo");

                entity.Property(e => e.TiesId)
                    .HasColumnName("ties_id")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<CatDiasInhabilesMuni>(entity =>
            {
                entity.HasKey(e => e.DinmId)
                    .HasName("PRIMARY");

                entity.ToTable("cat_dias_inhabiles_muni");

                entity.HasComment("Días inhabiles por municipio");

                entity.HasIndex(e => e.DiinId)
                    .HasName("fk_cat_dias_inhabiles_muni_-_cat_dias_inhabiles_idx");

                entity.HasIndex(e => e.MuniId)
                    .HasName("fk_cat_dias_inhabiles_muni_-_cat_municipios_idx");

                entity.Property(e => e.DinmId).HasColumnName("dinm_id");

                entity.Property(e => e.DiinId).HasColumnName("diin_id");

                entity.Property(e => e.MuniId).HasColumnName("muni_id");

                entity.Property(e => e.TiesId)
                    .HasColumnName("ties_id")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.Diin)
                    .WithMany(p => p.CatDiasInhabilesMuni)
                    .HasForeignKey(d => d.DiinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cat_dias_inhabiles_muni_-_cat_dias_inhabiles");

                entity.HasOne(d => d.Muni)
                    .WithMany(p => p.CatDiasInhabilesMuni)
                    .HasForeignKey(d => d.MuniId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cat_dias_inhabiles_muni_-_cat_municipios");
            });

            modelBuilder.Entity<CatMunicipios>(entity =>
            {
                entity.HasKey(e => e.MuniId)
                    .HasName("PRIMARY");

                entity.ToTable("cat_municipios");

                entity.HasComment("Municipios del estado");

                entity.Property(e => e.MuniId).HasColumnName("muni_id");

                entity.Property(e => e.MuniDescripcion)
                    .HasColumnName("muni_descripcion")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.MuniNumero)
                    .HasColumnName("muni_numero")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<CatNiveles>(entity =>
            {
                entity.HasKey(e => e.NiveId)
                    .HasName("PRIMARY");

                entity.ToTable("cat_niveles");

                entity.Property(e => e.NiveId).HasColumnName("nive_id");

                entity.Property(e => e.NiveDescripcion)
                    .IsRequired()
                    .HasColumnName("nive_descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TiesId)
                    .HasColumnName("ties_id")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<CatTipoAgenda>(entity =>
            {
                entity.HasKey(e => e.TiagId)
                    .HasName("PRIMARY");

                entity.ToTable("cat_tipo_agenda");

                entity.HasComment("Tipos de agenda");

                entity.Property(e => e.TiagId).HasColumnName("tiag_id");

                entity.Property(e => e.TiagDescripcion)
                    .IsRequired()
                    .HasColumnName("tiag_descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TiesId)
                    .HasColumnName("ties_id")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<CatTipoEstatus>(entity =>
            {
                entity.HasKey(e => e.TiesId)
                    .HasName("PRIMARY");

                entity.ToTable("cat_tipo_estatus");

                entity.HasComment("Estatus generales para la bd");

                entity.Property(e => e.TiesId).HasColumnName("ties_id");

                entity.Property(e => e.TiesDescripcion)
                    .IsRequired()
                    .HasColumnName("ties_descripcion")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatTipoTramite>(entity =>
            {
                entity.HasKey(e => e.TtraId)
                    .HasName("PRIMARY");

                entity.ToTable("cat_tipo_tramite");

                entity.Property(e => e.TtraId).HasColumnName("ttra_id");

                entity.Property(e => e.CentTipo).HasColumnName("cent_tipo");

                entity.Property(e => e.TiesId)
                    .HasColumnName("ties_id")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TtraDescripcion)
                    .IsRequired()
                    .HasColumnName("ttra_descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatUsuarios>(entity =>
            {
                entity.HasKey(e => e.UsuaId)
                    .HasName("PRIMARY");

                entity.ToTable("cat_usuarios");

                entity.HasIndex(e => e.NiveId)
                    .HasName("fk_cat_usuarios_-_cat_niveles_idx");

                entity.Property(e => e.UsuaId).HasColumnName("usua_id");

                entity.Property(e => e.NiveId).HasColumnName("nive_id");

                entity.Property(e => e.TiesId)
                    .HasColumnName("ties_id")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UsuaApellidoMaterno)
                    .IsRequired()
                    .HasColumnName("usua_apellido_materno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuaApellidoPaterno)
                    .IsRequired()
                    .HasColumnName("usua_apellido_paterno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuaNick)
                    .IsRequired()
                    .HasColumnName("usua_nick")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UsuaNombre)
                    .IsRequired()
                    .HasColumnName("usua_nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuaPassword)
                    .IsRequired()
                    .HasColumnName("usua_password")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Nive)
                    .WithMany(p => p.CatUsuarios)
                    .HasForeignKey(d => d.NiveId)
                    .HasConstraintName("fk_cat_usuarios_-_cat_niveles");
            });

            modelBuilder.Entity<ProAgendas>(entity =>
            {
                entity.HasKey(e => e.AgenId)
                    .HasName("PRIMARY");

                entity.ToTable("pro_agendas");

                entity.HasIndex(e => e.AgenCreador)
                    .HasName("fk_pro_agendas_-_cat_usuarios_idx1");

                entity.HasIndex(e => e.CentId)
                    .HasName("fk_pro_agendas_-_cat_centros_idx");

                entity.HasIndex(e => e.TiagId)
                    .HasName("fk_pro_agendas_-_cat_tipo_agenda_idx");

                entity.HasIndex(e => e.UsuaId)
                    .HasName("fk_pro_agendas_-_cat_usuarios_idx");

                entity.Property(e => e.AgenId).HasColumnName("agen_id");

                entity.Property(e => e.AgenCreador).HasColumnName("agen_creador");

                entity.Property(e => e.AgenDescripcion)
                    .HasColumnName("agen_descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AgenFechaCreacion).HasColumnName("agen_fecha_creacion");

                entity.Property(e => e.CentId).HasColumnName("cent_id");

                entity.Property(e => e.TiagId).HasColumnName("tiag_id");

                entity.Property(e => e.TiesId)
                    .HasColumnName("ties_id")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UsuaId).HasColumnName("usua_id");

                entity.HasOne(d => d.Cent)
                    .WithMany(p => p.ProAgendas)
                    .HasForeignKey(d => d.CentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pro_agendas_-_cat_centros");

                entity.HasOne(d => d.Tiag)
                    .WithMany(p => p.ProAgendas)
                    .HasForeignKey(d => d.TiagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pro_agendas_-_cat_tipo_agenda");

                entity.HasOne(d => d.Usua)
                    .WithMany(p => p.ProAgendas)
                    .HasForeignKey(d => d.UsuaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pro_agendas_-_cat_usuarios");
            });

            modelBuilder.Entity<ProCitas>(entity =>
            {
                entity.HasKey(e => e.CitaId)
                    .HasName("PRIMARY");

                entity.ToTable("pro_citas");

                entity.HasIndex(e => e.HoraId)
                    .HasName("fk_pro_cita_-_pro_horas_idx");

                entity.HasIndex(e => e.TtraId)
                    .HasName("fk_pro_cita_-_cat_tipo_tramite_idx");

                entity.Property(e => e.CitaId).HasColumnName("cita_id");

                entity.Property(e => e.CitaAcuse).HasColumnName("cita_acuse");

                entity.Property(e => e.CitaBuzon).HasColumnName("cita_buzon");

                entity.Property(e => e.CitaEstadoLogico).HasColumnName("cita_estado_logico");

                entity.Property(e => e.CitaFicha).HasColumnName("cita_ficha");

                entity.Property(e => e.HoraId).HasColumnName("hora_id");

                entity.Property(e => e.TiesId)
                    .HasColumnName("ties_id")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TtraId).HasColumnName("ttra_id");

                entity.HasOne(d => d.Hora)
                    .WithMany(p => p.ProCitas)
                    .HasForeignKey(d => d.HoraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pro_cita_-_pro_horas");

                entity.HasOne(d => d.Ttra)
                    .WithMany(p => p.ProCitas)
                    .HasForeignKey(d => d.TtraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pro_cita_-_cat_tipo_tramite");
            });

            modelBuilder.Entity<ProCitasDetalle>(entity =>
            {
                entity.HasKey(e => e.CideId)
                    .HasName("PRIMARY");

                entity.ToTable("pro_citas_detalle");

                entity.HasIndex(e => e.CitaId)
                    .HasName("fk_pro_citas_detalle_-_pro_citas_idx");

                entity.Property(e => e.CideId).HasColumnName("cide_id");

                entity.Property(e => e.CideCadenaVerificacion)
                    .HasColumnName("cide_cadena_verificacion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CideDescripcion)
                    .IsRequired()
                    .HasColumnName("cide_descripcion")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CitaId).HasColumnName("cita_id");

                entity.Property(e => e.TiesId)
                    .HasColumnName("ties_id")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.Cita)
                    .WithMany(p => p.ProCitasDetalle)
                    .HasForeignKey(d => d.CitaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pro_citas_detalle_-_pro_citas");
            });

            modelBuilder.Entity<ProDias>(entity =>
            {
                entity.HasKey(e => e.DiasId)
                    .HasName("PRIMARY");

                entity.ToTable("pro_dias");

                entity.HasIndex(e => e.AgenId)
                    .HasName("fk_pro_dias_-_pro_agendas_idx");

                entity.Property(e => e.DiasId).HasColumnName("dias_id");

                entity.Property(e => e.AgenId).HasColumnName("agen_id");

                entity.Property(e => e.DiasFecha)
                    .HasColumnName("dias_fecha")
                    .HasColumnType("date");

                entity.Property(e => e.TiesId)
                    .HasColumnName("ties_id")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.Agen)
                    .WithMany(p => p.ProDias)
                    .HasForeignKey(d => d.AgenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pro_dias_-_pro_agendas");
            });

            modelBuilder.Entity<ProHoras>(entity =>
            {
                entity.HasKey(e => e.HoraId)
                    .HasName("PRIMARY");

                entity.ToTable("pro_horas");

                entity.HasIndex(e => e.DiasId)
                    .HasName("fk_pro_horas_-_pro_dias_idx");

                entity.Property(e => e.HoraId).HasColumnName("hora_id");

                entity.Property(e => e.DiasId).HasColumnName("dias_id");

                entity.Property(e => e.HoraFin).HasColumnName("hora_fin");

                entity.Property(e => e.HoraInicio).HasColumnName("hora_inicio");

                entity.Property(e => e.TiesId)
                    .HasColumnName("ties_id")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.Dias)
                    .WithMany(p => p.ProHoras)
                    .HasForeignKey(d => d.DiasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pro_horas_-_pro_dias");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
