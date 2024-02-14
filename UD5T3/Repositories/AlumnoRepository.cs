using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD5T3.MVVM.Models;

namespace UD5T3.Repositories
{
    /// <summary>
    /// Repositorio de alumnos.
    /// 
    /// Aqui se ejecutan las órdenes CRUD de la aplicación
    /// </summary>
    public class AlumnoRepository
    {
        SQLiteConnection connection;
        public string StatusMessages { get; set; }
        public AlumnoRepository()
        {
            connection = new SQLiteConnection(Constantes.DatabasePath, Constantes.Flags);
            connection.CreateTable<Alumno>();
        }
        /// <summary>
        /// Añade o actualiza ( en resumen, superpone ) a un alumno en la base
        /// de datos .
        /// Comprueba si existe el alumno a través de su id. Lanza un mensaje
        /// del estado de la operación en función si se realizó correctamente la operación,
        /// y muestra cuántas filas fueron actualizadas o insertadas.
        /// 
        /// Guarda el resultado de la operación en la variable resultado
        /// 
        /// No devuelve nada.
        /// </summary>
        /// <param name="alumno">Alumno que se va a añadir/editar.</param>
        public void AddOrUpdateStudent(Alumno alumno)
        {
            int resultado;
            try
            {
                if(alumno.ID != 0)
                {
                    if (alumno.NIF.Length <= 9)
                    {
                        resultado = connection.Update(alumno);
                        StatusMessages = $"{resultado} row(s) updated";
                    }
                    else
                    {
                        StatusMessages = $"El NIF no puede ser mayor a 9 caracteres";
                    }
                }
                else
                {
                        resultado = connection.Insert(alumno);
                        StatusMessages = $"{resultado} row(s) added";
                }
            }
            catch (Exception ex)
            {
                StatusMessages = $"No introduzca valores vacíos";
            }
        }
        /// <summary>
        /// Obtiene todos los alumnos almacenados en la base de datos.
        /// 
        /// Muestra un mensaje de error en caso de de que falle la operación.
        /// 
        /// El resultado lo almacena en la variable lista.
        /// 
        /// Devuelve la lista de alumnos obtenida.
        /// </summary>
        /// <returns>Una lista de tipo Alumno.</returns>
        public List<Alumno> GetAll()
        {
            List<Alumno> lista = null;
            try
            {
                lista = connection.Table<Alumno>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessages = $"Error: {ex.Message}";
            }
            return lista;
        }
        /// <summary>
        /// Obtiene un alumno de la base de datos a partir de su id.
        /// 
        /// Si surge algún error en la petición muestra un mensaje con el error correspondiente.
        /// 
        /// Guarda el resultado en una variable (alumno) privada de la función.
        /// 
        /// Devuelve el alumno obtenido.
        /// </summary>
        /// <param name="id">Id del alumno a obtener.</param>
        /// <returns>Un alumno de tipo Alumno.</returns>
        public Alumno Get(int id)
        {
            Alumno alumno = null;
            try
            {
                alumno = connection.Table<Alumno>().FirstOrDefault(item => item.ID == id);
            }
            catch (Exception ex)
            {
                StatusMessages = $"Error: {ex.Message}";
            }
            return alumno;
        }
        /// <summary>
        /// Borra un alumno de la base de datos a través de su ID.
        /// 
        /// Muestra un mensaje con el resultado de la operación.
        /// Si surge algún error en la petición muestra un mensaje con el error correspondiente.
        /// 
        /// Guarda el resultado de la operación en una variable (resultado) privada de la función.
        /// 
        /// No devuelve nada.
        /// </summary>
        /// <param name="id">ID del usuario a borrar.</param>
        public void Delete(int id)
        {
            int resultado;
            try
            {
                resultado = connection.Delete(Get(id));
                StatusMessages = $"{resultado} row(s) deleted";
            }
            catch (Exception ex)
            {
                StatusMessages = $"Error: {ex.Message}";
            }
        }
    }
}
