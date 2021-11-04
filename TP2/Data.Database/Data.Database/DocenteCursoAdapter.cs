using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;

namespace Data.Database
{
    public class DocenteCursoAdapter:Adapter
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

        public List<DocenteCurso> GetAll()
        {
            using (_EfConn) {
                List<DocenteCurso> lsDocente = new List<DocenteCurso>();
                try
                {
                    DocenteCurso Docent;
                    var docentes = _EfConn.docentes_cursos;
                    foreach(var doc in docentes)
                    {
                        Docent = new DocenteCurso();
                        Docent.ID = doc.id_dictado;
                        Docent.IDCurso = doc.id_curso;
                        Docent.IDDocente = doc.id_docente;
                        Docent.Cargo = (DocenteCurso.TiposCargos)doc.cargo;
                        lsDocente.Add(Docent);
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
                return lsDocente;
            }
        }

        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            DocenteCurso Docent = new DocenteCurso();
            try
            {
                using (_EfConn)
                {
                    var doc = _EfConn.docentes_cursos.Find(ID);
                    Docent = new DocenteCurso();
                    Docent.ID = doc.id_dictado;
                    Docent.IDCurso = doc.id_curso;
                    Docent.IDDocente = doc.id_docente;
                    Docent.Cargo = (DocenteCurso.TiposCargos)doc.cargo;

                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionDatosUsuario = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionDatosUsuario;
            }
            return Docent;
        }

        public void Delete(int ID)
        {
            try
            {
                using (_EfConn)
                {
                    var esp = _EfConn.docentes_cursos.Find(ID);
                    _EfConn.docentes_cursos.Remove(esp);
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

        protected void Update(DocenteCurso doc)
        {
            try
            {
                using (_EfConn)
                {
                    var Docent = _EfConn.docentes_cursos.Find(doc.ID);
                    Docent.id_dictado = doc.ID;
                    Docent.id_curso = doc.IDCurso;
                    Docent.id_docente = doc.IDDocente;
                    Docent.cargo = (int)doc.Cargo;
                    _EfConn.Entry(Docent).State = System.Data.Entity.EntityState.Modified;
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

        protected void Insert(DocenteCurso doc)
        {
            try
            {
                using (_EfConn)
                {
                    var Docent = new docentes_cursos();
                    Docent.id_dictado = doc.ID;
                    Docent.id_curso = doc.IDCurso;
                    Docent.id_docente = doc.IDDocente;
                    Docent.cargo = (int)doc.Cargo;

                    _EfConn.docentes_cursos.Add(Docent);
                    _EfConn.Entry(Docent).State = System.Data.Entity.EntityState.Added;
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

        public void Save(DocenteCurso doc)
        {
            if (doc.State == BusinessEntity.States.Deleted)
            {
                this.Delete(doc.ID);
            }
            else if (doc.State == BusinessEntity.States.New)
            {
                this.Insert(doc);
            }
            else if (doc.State == BusinessEntity.States.Modified)
            {
                this.Update(doc);
            }
            doc.State = BusinessEntity.States.Unmodified;
        }
    }
}
