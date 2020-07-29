using System;
using System.Collections.Generic;

namespace Commander.Modelss
{
    public partial class ProCitasDetalle
    {
        public long CideId { get; set; }
        public string CideDescripcion { get; set; }
        public string CideCadenaVerificacion { get; set; }
        public long CitaId { get; set; }
        public int? TiesId { get; set; }

        public virtual ProCitas Cita { get; set; }
    }
}
