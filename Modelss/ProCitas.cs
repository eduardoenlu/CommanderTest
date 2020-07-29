using System;
using System.Collections.Generic;

namespace Commander.Modelss
{
    public partial class ProCitas
    {
        public ProCitas()
        {
            ProCitasDetalle = new HashSet<ProCitasDetalle>();
        }

        public long CitaId { get; set; }
        public int TtraId { get; set; }
        public int CitaBuzon { get; set; }
        public long HoraId { get; set; }
        public long? CitaAcuse { get; set; }
        public long? CitaFicha { get; set; }
        public int? CitaEstadoLogico { get; set; }
        public int? TiesId { get; set; }

        public virtual ProHoras Hora { get; set; }
        public virtual CatTipoTramite Ttra { get; set; }
        public virtual ICollection<ProCitasDetalle> ProCitasDetalle { get; set; }
    }
}
