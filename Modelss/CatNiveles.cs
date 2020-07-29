using System;
using System.Collections.Generic;

namespace Commander.Modelss
{
    public partial class CatNiveles
    {
        public CatNiveles()
        {
            CatUsuarios = new HashSet<CatUsuarios>();
        }

        public int NiveId { get; set; }
        public string NiveDescripcion { get; set; }
        public int? TiesId { get; set; }

        public virtual ICollection<CatUsuarios> CatUsuarios { get; set; }
    }
}
