using System;
using System.Collections.Generic;

namespace Commander.Modelss
{
    public partial class ProAgendas
    {
        public ProAgendas()
        {
            ProDias = new HashSet<ProDias>();
        }

        public int AgenId { get; set; }
        public int CentId { get; set; }
        public int TiagId { get; set; }
        public int UsuaId { get; set; }
        public DateTime AgenFechaCreacion { get; set; }
        public string AgenDescripcion { get; set; }
        public int AgenCreador { get; set; }
        public int? TiesId { get; set; }

        public virtual CatCentros Cent { get; set; }
        public virtual CatTipoAgenda Tiag { get; set; }
        public virtual CatUsuarios Usua { get; set; }
        public virtual ICollection<ProDias> ProDias { get; set; }
    }
}
