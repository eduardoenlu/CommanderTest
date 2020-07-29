using System;
using System.Collections.Generic;

namespace Commander.Modelss
{
    public partial class CatTipoAgenda
    {
        public CatTipoAgenda()
        {
            ProAgendas = new HashSet<ProAgendas>();
        }

        public int TiagId { get; set; }
        public string TiagDescripcion { get; set; }
        public int? TiesId { get; set; }

        public virtual ICollection<ProAgendas> ProAgendas { get; set; }
    }
}
