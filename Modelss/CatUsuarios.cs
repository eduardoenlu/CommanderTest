using System;
using System.Collections.Generic;

namespace Commander.Modelss
{
    public partial class CatUsuarios
    {
        public CatUsuarios()
        {
            ProAgendas = new HashSet<ProAgendas>();
        }

        public int UsuaId { get; set; }
        public string UsuaNombre { get; set; }
        public string UsuaApellidoPaterno { get; set; }
        public string UsuaApellidoMaterno { get; set; }
        public string UsuaNick { get; set; }
        public string UsuaPassword { get; set; }
        public int? NiveId { get; set; }
        public int? TiesId { get; set; }

        public virtual CatNiveles Nive { get; set; }
        public virtual ICollection<ProAgendas> ProAgendas { get; set; }
    }
}
