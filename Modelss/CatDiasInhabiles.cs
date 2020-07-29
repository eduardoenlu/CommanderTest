using System;
using System.Collections.Generic;

namespace Commander.Modelss
{
    public partial class CatDiasInhabiles
    {
        public CatDiasInhabiles()
        {
            CatDiasInhabilesMuni = new HashSet<CatDiasInhabilesMuni>();
        }

        public int DiinId { get; set; }
        public DateTime DiinDia { get; set; }
        public int DiinTipo { get; set; }
        public int? TiesId { get; set; }

        public virtual ICollection<CatDiasInhabilesMuni> CatDiasInhabilesMuni { get; set; }
    }
}
