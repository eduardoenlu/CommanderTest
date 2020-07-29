using System;
using System.Collections.Generic;

namespace Commander.Modelss
{
    public partial class CatDiasInhabilesMuni
    {
        public int DinmId { get; set; }
        public int MuniId { get; set; }
        public int DiinId { get; set; }
        public int? TiesId { get; set; }

        public virtual CatDiasInhabiles Diin { get; set; }
        public virtual CatMunicipios Muni { get; set; }
    }
}
