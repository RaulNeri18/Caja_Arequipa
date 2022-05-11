using System;
using System.Collections.Generic;

namespace CoreApiEF.Models
{
    public partial class Alumno
    {
        public int IdAlumno { get; set; }
        public string Dni { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public DateTime? FecCumple { get; set; }
        public int IdColegio { get; set; }

        public virtual Colegio IdColegioNavigation { get; set; } = null!;
    }
}
