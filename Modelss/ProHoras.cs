using System;
using System.Collections.Generic;

namespace Commander.Modelss
{
    public partial class ProHoras
    {
        public ProHoras()
        {
            ProCitas = new HashSet<ProCitas>();
        }

        public long HoraId { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int DiasId { get; set; }
        public int? TiesId { get; set; }

        public virtual ProDias Dias { get; set; }
        public virtual ICollection<ProCitas> ProCitas { get; set; }
    }
}
