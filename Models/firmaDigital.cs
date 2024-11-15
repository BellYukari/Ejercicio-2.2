using SQLite;

namespace Tarea2._2FirmaDigital.Models
{
    [SQLite.Table("FirmasDigitales")]
    public class firmaDigital
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255), NotNull]
        public string? Descripcion { get; set; }

        [MaxLength(255), NotNull]
        public string? NombreFirma { get; set; }
        public string? FirmaDigital { get; set; }
    }
}
