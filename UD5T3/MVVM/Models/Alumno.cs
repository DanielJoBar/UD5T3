using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UD5T3.MVVM.Models
{

    /// <summary>
    /// Tabla de Alumnos.
    /// Almacena la estructura de la base de datos de AlumnoRepositorio.
    /// </summary>
    [Table("Alumnos")]
    public class Alumno
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Column("Nombre"), NotNull]
        public string Nombre { get; set; }
        [Column("NIF"), MaxLength(9), Unique]
        public string NIF { get; set; }
        [Column("Empresa"), MaxLength(100)]
        public string Empresa { get; set; }
    }
}
