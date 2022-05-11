namespace CoreApiEF.Models.Request
{
    public class AlumnoRequest
    {
        public string? Id { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FecCumple { get; set; }
        public int IdColegio { get; set; }

    }
}
