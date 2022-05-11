using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreApiEF.Models;

namespace CoreApiEF.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ColegioController : ControllerBase
    {

        //Mostrar Cantidad de Alumnos por cada colegio.
        [HttpGet(Name = "GetAlumnosByColegio")]
        public ActionResult GetAlumnosByColegio()
        {
            using (BD_SISCOLEContext db = new BD_SISCOLEContext())
            {
                var lst = (
                    from c in db.Colegios join
                          a in db.Alumnos
                     on c.IdColegio equals a.IdColegio
                    group c by c.Nombre into grupoColegios

                    select new
                    {
                        NombreColegio = grupoColegios.Key,
                        CantidadAlumnos = grupoColegios.Count()
                    }).ToList();

                return Ok(lst);
            }
        }
    }
}
