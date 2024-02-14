using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UD5T3.MVVM.ViewModels
{
    /// <summary>
    /// Guarda la estructura de datos de la vista de detalles.
    /// </summary>
    public class DetalleViewModel
    {
        public int ID {  get; set; }
        public string Nombre { get; set; }
        public string NIF { get; set; }
        public string Empresa { get; set; }
    }
}
