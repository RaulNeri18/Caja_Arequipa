using System;
using System.Collections.Generic;

namespace CoreApiEF.Models
{
    public partial class Colegio
    {
        public Colegio()
        {
            Alumnos = new HashSet<Alumno>();
        }

        public int IdColegio { get; set; }
        public string Direccion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int IdPais { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }
    }
}
