using System;
using System.Collections.Generic;

namespace Commander.Modelss
{
    public partial class CatMunicipios
    {
        public CatMunicipios()
        {
            CatCentros = new HashSet<CatCentros>();
            CatDiasInhabilesMuni = new HashSet<CatDiasInhabilesMuni>();
        }

        public int MuniId { get; set; }
        public string MuniDescripcion { get; set; }
        public string MuniNumero { get; set; }

        public virtual ICollection<CatCentros> CatCentros { get; set; }
        public virtual ICollection<CatDiasInhabilesMuni> CatDiasInhabilesMuni { get; set; }
    }
}
