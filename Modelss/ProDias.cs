using System;
using System.Collections.Generic;

namespace Commander.Modelss
{
    public partial class ProDias
    {
        public ProDias()
        {
            ProHoras = new HashSet<ProHoras>();
        }

        public int DiasId { get; set; }
        public DateTime DiasFecha { get; set; }
        public int AgenId { get; set; }
        public int? TiesId { get; set; }

        public virtual ProAgendas Agen { get; set; }
        public virtual ICollection<ProHoras> ProHoras { get; set; }
    }
}
