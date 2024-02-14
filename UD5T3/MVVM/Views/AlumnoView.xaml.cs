using UD5T3.MVVM.ViewModels;

namespace UD5T3.MVVM.Views
{
    /// <summary>
    /// Página principal del proyecto.
    /// Muestra un formulario para operaciones CRUD con alumnos 
    /// y hace la navegación a la vista detalle.
    /// </summary>
    public partial class AlumnoView : ContentPage
    {
        /// <summary>
        /// Inicializa la VistaAlumnoView.
        /// Asigna el contexto a AlumnoViewModel.
        /// </summary>
        public AlumnoView()
        {
            InitializeComponent();
            BindingContext = new AlumnoViewModel();
        }

        /// <summary>
        /// Recibe un evento Click de un Botón y el id del alumno seleccionado 
        /// por parámetro.
        /// Guarda el alumno seleccionado en una variable privada (alumnoActual) de la función.
        /// 
        /// Hace la navegación a vista de detalle y asigna el contexto al DetalleViewModel.
        /// Los datos del DetalleViewModel se sacan de alumnoActual para transpasar datos de una vista
        /// a otra.
        /// 
        /// </summary>
        /// <param name="sender"> Quien realiza el evento( el propio botón ). </param>
        /// <param name="e"> Argumetos que recibe el evento. </param>
        private void Detalle_Clicked(object sender, EventArgs e)
        {

            AlumnoViewModel currentView = (AlumnoViewModel)BindingContext;
            var alumnoActual = currentView.AlumnoActual;
         
            Navigation.PushAsync(new DetalleView()
            {
                BindingContext = new DetalleViewModel
                {
                    ID = alumnoActual.ID,
                    Nombre = alumnoActual.Nombre,
                    NIF = alumnoActual.NIF,
                    Empresa = alumnoActual.Empresa
                }
            });

        }
    }
}
