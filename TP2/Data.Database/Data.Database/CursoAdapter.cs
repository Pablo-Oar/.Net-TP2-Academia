using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;

namespace Data.Database
{
    public class CursoAdapter:Adapter
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
                    usr.EMail = "casimirocegado@gmail.Cur";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 2;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.EMail = "armandoquito@gmail.Cur";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.EMail = "alanbrado@gmail.Cur";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion

        public List<Curso> GetAll()
        {
            using (_EfConn) {
                List<Curso> lsCurso = new List<Curso>();
                try
                {
                    Curso Cur;
                    var Cursos = _EfConn.cursos;
                    foreach(var cu in Cursos)
                    {
                        Cur = new Curso();
                        Cur.ID = cu.id_curso;
                        Cur.AnioCalendario = cu.anio_calendario;
                        Cur.Cupo = cu.cupo;
                        Cur.IDComision = cu.id_comision;
                        Cur.IDMateria = cu.id_materia;
                        lsCurso.Add(Cur);
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
                return lsCurso;
            }
        }

        public Business.Entities.Curso GetOne(int ID)
        {
            Curso Cur = new Curso();
            try
            {
                using (_EfConn)
                {
                    var cu = _EfConn.cursos.Find(ID);
                    Cur = new Curso();
                    Cur.ID = cu.id_curso;
                    Cur.AnioCalendario = cu.anio_calendario;
                    Cur.Cupo = cu.cupo;
                    Cur.IDComision = cu.id_comision;
                    Cur.IDMateria = cu.id_materia;
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionDatosUsuario = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionDatosUsuario;
            }
            return Cur;
        }

        public void Delete(int ID)
        {
            try
            {
                using (_EfConn)
                {
                    var cu = _EfConn.cursos.Find(ID);
                    _EfConn.cursos.Remove(cu);
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

        protected void Update(Curso cu)
        {
            try
            {
                using (_EfConn)
                {
                    var Cur = _EfConn.cursos.Find(cu.ID);
                    Cur.id_curso = cu.ID;
                    Cur.anio_calendario = cu.AnioCalendario;
                    Cur.cupo = cu.Cupo;
                    Cur.id_comision = cu.IDComision;
                    Cur.id_materia = cu.IDMateria;
                    _EfConn.Entry(Cur).State = System.Data.Entity.EntityState.Modified;
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

        protected void Insert(Curso cu)
        {
            try
            {
                using (_EfConn)
                {
                    var Cur = new cursos();
                    Cur.id_curso = cu.ID;
                    Cur.anio_calendario = cu.AnioCalendario;
                    Cur.cupo = cu.Cupo;
                    Cur.id_comision = cu.IDComision;
                    Cur.id_materia = cu.IDMateria;

                    _EfConn.cursos.Add(Cur);
                    _EfConn.Entry(Cur).State = System.Data.Entity.EntityState.Added;
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

        public void Save(Curso cu)
        {
            if (cu.State == BusinessEntity.States.Deleted)
            {
                this.Delete(cu.ID);
            }
            else if (cu.State == BusinessEntity.States.New)
            {
                this.Insert(cu);
            }
            else if (cu.State == BusinessEntity.States.Modified)
            {
                this.Update(cu);
            }
            cu.State = BusinessEntity.States.Unmodified;
        }
    }
}
