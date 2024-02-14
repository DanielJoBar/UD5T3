using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UD5T3.MVVM.Models;

namespace UD5T3.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class AlumnoViewModel
    {
        public List<Alumno> Alumnos { get; set; }
        public Alumno AlumnoActual { get; set; }
        public ICommand CrearOActualizar {  get; set; }
        public ICommand Borrar {  get; set; }
        public ICommand Detalle {  get; set; }

        /// <summary>
        /// Almacena dinámicamente la lista de alumnos y el alumno actual seleccionado.
        /// 
        /// CrearOActualizar:
        ///     Se comunica con el repositorio para crear o actualizar un alumno pasándoselo por parámetro.
        ///     Muestra un mensaje del estado de la operación y resetea el valor de AlumnoActual.
        ///     Refresca la vista.
        ///     Controla nulos y de que el NIF sea menor a 9 caracteres.
        /// 
        /// Borrar:
        ///     Se comunica con el repositorio para borrar un alumno a través de su ID.
        ///     Muestra un mensaje del estado de la operación y resetea el valor de AlumnoActual.
        ///     Refresca la vista.
        ///     
        /// Detalle:
        ///     Se comunica con el repositorio para obtener un alumno de la base de datos a través
        ///     de su ID.
        ///     Asigna el valor resultante de la operación en la variable AlumnoActual.
        ///     Refresca la vista.
        /// </summary>
        public AlumnoViewModel() 
        {
            Refresh();
            AlumnoActual = new Alumno();

            CrearOActualizar = new Command(() =>
            {
                App.AlumnoRepository.AddOrUpdateStudent(AlumnoActual);
                Mensaje("Actualización", App.AlumnoRepository.StatusMessages);
                AlumnoActual = new Alumno();
                Refresh();
            });
            Borrar = new Command(() =>
            {
               App.AlumnoRepository.Delete(AlumnoActual.ID);
               Mensaje("Borrado", App.AlumnoRepository.StatusMessages);
               AlumnoActual = new Alumno();
               Refresh();
            });
            Detalle = new Command(() =>
            {
                var AlumnoObtenido = App.AlumnoRepository.Get(AlumnoActual.ID);
                AlumnoActual = AlumnoObtenido;
                Refresh();
            });
        }

        /// <summary>
        /// Muestra una alerta por pantalla.
        /// </summary>
        /// <param name="title">Título de la alerta.</param>
        /// <param name="message">Mensaje de la alerta.</param>
        public static void Mensaje(string title, string message)
        {
            App.Current.MainPage.DisplayAlert(title, message, "Ok");
        }
        /// <summary>
        /// Refresca la vista haciendo un getAll al repositorio.
        /// </summary>
        public void Refresh()
        {
            Alumnos = App.AlumnoRepository.GetAll();
        }
    }
}
