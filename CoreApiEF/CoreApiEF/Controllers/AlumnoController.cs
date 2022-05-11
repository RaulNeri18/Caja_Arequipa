using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreApiEF.Models;

namespace CoreApiEF.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {

        //Listar Alumnos con sus respectivos colegios.
        [HttpGet(Name = "GetAlumnos")]
        public ActionResult GetAlumnos()
        {
            using (BD_SISCOLEContext db = new BD_SISCOLEContext())
            {
                var lst = (from a in db.Alumnos join
                                c in db.Colegios
                           on a.IdColegio equals c.IdColegio

                           select new {
                               IdAlumno = a.IdAlumno,
                               Dni = a.Dni,
                               Nombres = a.Nombres,
                               Apellidos = a.Apellidos,
                               FecCumple = a.FecCumple,
                               IdColegio = a.IdColegio,
                               NombreColegio = c.Nombre
                           }).ToList();

                return Ok(lst);
            }
        }

        //Crear alumnos.
        [HttpPost(Name = "PostAlumno")]
        public ActionResult PostAlumno([FromBody] Models.Request.AlumnoRequest model)
        {
            using (BD_SISCOLEContext db = new BD_SISCOLEContext())
            {
                Alumno oAlumno = new Alumno();
                oAlumno.Dni = model.Dni;
                oAlumno.Nombres = model.Nombres;
                oAlumno.Apellidos = model.Apellidos;
                oAlumno.FecCumple = model.FecCumple;
                oAlumno.IdColegio = model.IdColegio;

                db.Add(oAlumno);
                db.SaveChanges();
            }
            return Ok();
        }

        //Eliminar Alumnos.
        [HttpDelete(Name = "DeleteAlumnoById")]
        public ActionResult DeleteAlumnoById([FromBody] int Id)
        {
            using (BD_SISCOLEContext db = new BD_SISCOLEContext())
            {
                Alumno oAlumno = db.Alumnos.Find(Id);
                db.Remove(oAlumno);
                db.SaveChanges();
            }
            return Ok();
        }

        //Buscar Alumnos Por Nombres y Apellidos.
        [HttpGet(Name = "GetAlumnosByNombre")]
        public ActionResult GetAlumnosByNombre([FromBody] string NombreApellido)
        {
            using (BD_SISCOLEContext db = new BD_SISCOLEContext())
            {
                var lst = db.Alumnos.Where(p => p.Nombres.Contains(NombreApellido) || p.Apellidos.Contains(NombreApellido)).ToList();

                return Ok(lst);
            }
        }
    }
}
