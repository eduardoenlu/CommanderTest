using System;
using System.Collections.Generic;

namespace Commander.Modelss
{
    public partial class CatCentros
    {
        public CatCentros()
        {
            ProAgendas = new HashSet<ProAgendas>();
        }

        public int CentId { get; set; }
        public string CentClave { get; set; }
        public string CentDescripcion { get; set; }
        public int CentTipo { get; set; }
        public int MuniId { get; set; }
        public int? TiesId { get; set; }

        public virtual CatMunicipios Muni { get; set; }
        public virtual ICollection<ProAgendas> ProAgendas { get; set; }
    }
}
