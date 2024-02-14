using UD5T3.MVVM.Views;
using UD5T3.Repositories;

namespace UD5T3
{
    /// <summary>
    /// Clase sobre la que se pintan la vista (actividad principal).
    /// 
    /// Almacena una instancia del repositorio de alumnos y asigna la página principal
    /// a la vista NAVEGABLE  AlumnoView
    /// </summary>
    public partial class App : Application
    {
        public static AlumnoRepository AlumnoRepository { get; private set; }
        public App(AlumnoRepository alumnoRepository)
        {
            InitializeComponent();
            AlumnoRepository = alumnoRepository;
            MainPage = new NavigationPage(new AlumnoView());
        }

    }
}