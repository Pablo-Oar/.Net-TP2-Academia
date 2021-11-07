using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter:Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Usuario> _Usuarios;

        private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Business.Entities.Usuario>();
                    Business.Entities.Usuario usr;
                    usr = new Business.Entities.Usuario();
                    usr.ID = 1;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "miro";
                    usr.EMail = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 2;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.EMail = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.EMail = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion

        public List<AlumnoInscripcion> GetAll()
        {
            using (_EfConn) {
                List<AlumnoInscripcion> lsAlumnoInscripcion = new List<AlumnoInscripcion>();
                try
                {
                    AlumnoInscripcion Alumno;
                    var AlumnoInscripcion = _EfConn.alumnos_inscripciones;
                    foreach(var alu in AlumnoInscripcion)
                    {                       
                        Alumno = new AlumnoInscripcion();
                        Alumno.ID = alu.id_inscripcion;
                        Alumno.IDAlumno = alu.id_alumno;
                        Alumno.IDCurso = (int)alu.id_curso;
                        Alumno.Nota = (int)alu.nota;
                        Alumno.Condicion = alu.condicion;                       
                        lsAlumnoInscripcion.Add(Alumno);
                    }
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al recuperar lista de Inscripciones de Alumnos" + Ex, Ex);
                    throw ExcepcionManejada;
                }
                finally
                {
                }
                return lsAlumnoInscripcion;
            }
        }

        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion Alumno = new AlumnoInscripcion();
            try
            {
                using (_EfConn)
                {
                    var alu = _EfConn.alumnos_inscripciones.Find(ID);
                    Alumno = new AlumnoInscripcion();
                    Alumno.ID = alu.id_inscripcion;
                    Alumno.IDAlumno = alu.id_alumno;
                    Alumno.IDCurso = (int)alu.id_curso;
                    Alumno.Nota = (int)alu.nota;
                    Alumno.Condicion = alu.condicion;
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionDatosUsuario = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionDatosUsuario;
            }
            return Alumno;
        }

        public void Delete(int ID)
        {
            try
            {
                using (_EfConn)
                {
                    var per = _EfConn.alumnos_inscripciones.Find(ID);
                    _EfConn.alumnos_inscripciones.Remove(per);
                    _EfConn.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionEliminarUsuario = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionEliminarUsuario;
            }
            finally
            {
            }
        }

        protected void Update(AlumnoInscripcion alu)
        {
            try
            {
                using (_EfConn)
                {
                    var Alumno = _EfConn.alumnos_inscripciones.Find(alu.ID);
                    Alumno.id_inscripcion = alu.ID;
                    Alumno.id_alumno = alu.IDAlumno;
                    Alumno.id_curso = (int)alu.IDCurso;
                    Alumno.nota = (int)alu.Nota;
                    Alumno.condicion = alu.Condicion;
                    _EfConn.Entry(Alumno).State = System.Data.Entity.EntityState.Modified;
                    _EfConn.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionModificaDatosUsuario = new Exception("Error al modificar los datos de usuario", Ex);
                throw ExcepcionModificaDatosUsuario;
            }
            finally
            {
                
            }
        }

        protected void Insert(AlumnoInscripcion alu)
        {
            try
            {
                using (_EfConn)
                {
                    var Alumno = new alumnos_inscripciones();
                    Alumno.id_alumno = alu.IDAlumno;
                    Alumno.id_curso = (int)alu.IDCurso;
                    Alumno.nota = (int)alu.Nota;
                    Alumno.condicion = alu.Condicion;
                    _EfConn.alumnos_inscripciones.Add(Alumno);
                    _EfConn.Entry(Alumno).State = System.Data.Entity.EntityState.Added;
                    _EfConn.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionInsertarUsuario = new Exception("Error al crear usuario", Ex);
                throw ExcepcionInsertarUsuario;
            }
            finally
            {
            }
        }

        public void Save(AlumnoInscripcion alu)
        {
            if (alu.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alu.ID);
            }
            else if (alu.State == BusinessEntity.States.New)
            {
                this.Insert(alu);
            }
            else if (alu.State == BusinessEntity.States.Modified)
            {
                this.Update(alu);
            }
            alu.State = BusinessEntity.States.Unmodified;
        }
    }
}
