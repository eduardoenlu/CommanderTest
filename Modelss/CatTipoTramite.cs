using System;
using System.Collections.Generic;

namespace Commander.Modelss
{
    public partial class CatTipoTramite
    {
        public CatTipoTramite()
        {
            ProCitas = new HashSet<ProCitas>();
        }

        public int TtraId { get; set; }
        public string TtraDescripcion { get; set; }
        public int CentTipo { get; set; }
        public int? TiesId { get; set; }

        public virtual ICollection<ProCitas> ProCitas { get; set; }
    }
}
