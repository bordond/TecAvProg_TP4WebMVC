using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Persona
    {
        #region Propiedades
        public int? IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        #endregion

        #region Constructores

        public Persona()
        {
        }

        public Persona(string nombre, string apellido, int dni, string direccion, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Direccion = direccion;
            Email = email;
        }
        #endregion

        #region Metodos Publicos
        public static List<Persona> Listar()
        {
            DataTable dt = new DataTable();
            dt = Datos.Persona.Listar();
            List<Persona> listaPersonas = new List<Persona>();

            foreach (DataRow item in dt.Rows)
            {
                listaPersonas.Add(ArmarDatos(item));
            }

            return listaPersonas;
        }

        public static Persona Obtener(int idPersona)
        {
            DataTable dt = new DataTable();
            dt = Datos.Persona.Obtener(idPersona);

            return ArmarDatos(dt.Rows[0]);
        }

        public static List<Persona> Buscar(int idPersona)
        {
            DataTable dt = new DataTable();
            dt = Datos.Persona.Buscar(idPersona);
            List<Persona> listaPersonas = new List<Persona>();

            foreach (DataRow item in dt.Rows)
            {
                listaPersonas.Add(ArmarDatos(item));
            }

            return listaPersonas;
        }

        public static void Eliminar(int idPersona)
        {
            Datos.Persona.Eliminar(idPersona);
        }

        public int Grabar()
        {
            try
            {
                if (Validar(out string error))
                {
                    if (IdPersona == null)
                    {
                        return Insertar();
                    }
                    else
                    {
                        return Modificar();
                    }
                }
                else
                    throw new Exception(error);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Metodos privados

        private int Insertar()
        {
            return Datos.Persona.Insertar(Nombre, Apellido, DNI, Direccion, Email);
        }

        private int Modificar()
        {
            Datos.Persona.Modificar(IdPersona.Value, Nombre, Apellido, DNI, Direccion, Email);
            return IdPersona.Value;
        }

        private bool Validar(out string error)
        {
            error = "";

            if (string.IsNullOrEmpty(Nombre))
                error += "El nombre se encuentra vacio; ";

            if (string.IsNullOrEmpty(Apellido))
                error += "El apellido se encuentra vacio; ";

            if (string.IsNullOrEmpty(Direccion))
                error += "La direccion se encuentra vacio; ";

            if (string.IsNullOrEmpty(Email))
                error += "El Email se encuentra vacio; ";

            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        private static Persona ArmarDatos(DataRow item)
        {
            Persona Persona = new Persona();
            Persona.IdPersona = Convert.ToInt32(item["IdPersona"]);
            Persona.Nombre = item["Nombre"].ToString();
            Persona.Apellido = item["Apellido"].ToString();
            Persona.DNI = Convert.ToInt32(item["DNI"]);
            Persona.Direccion = item["Direccion"].ToString();
            Persona.Email = item["Email"].ToString();
            return Persona;
        }
        #endregion
    }
}
