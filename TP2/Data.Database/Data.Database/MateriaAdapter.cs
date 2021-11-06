using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;

namespace Data.Database
{
    public class MateriaAdapter:Adapter
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

        public List<Materia> GetAll()
        {
            using (_EfConn) {
                List<Materia> lsMateria = new List<Materia>();
                try
                {
                    Materia Mater;
                    var materias = _EfConn.materias;
                    foreach(var mat in materias)
                    {
                        Mater = new Materia();
                        Mater.ID = mat.id_materia;
                        Mater.Descripcion = mat.desc_materia;
                        Mater.HSSemanales = mat.hs_semanales;
                        Mater.HSTotales = mat.hs_totales;
                        Mater.IDPlan = mat.id_plan;
                        lsMateria.Add(Mater);
                    }
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias" + Ex, Ex);
                    throw ExcepcionManejada;
                }
                finally
                {
                }
                return lsMateria;
            }
        }

        public Business.Entities.Materia GetOne(int ID)
        {
            Materia Mater = new Materia();
            try
            {
                using (_EfConn)
                {
                    var mat = _EfConn.materias.Find(ID);
                    Mater = new Materia();
                    Mater.ID = mat.id_materia;
                    Mater.Descripcion = mat.desc_materia;
                    Mater.HSSemanales = mat.hs_semanales;
                    Mater.HSTotales = mat.hs_totales;
                    Mater.IDPlan = mat.id_plan;
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionDatosUsuario = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionDatosUsuario;
            }
            return Mater;
        }

        public void Delete(int ID)
        {
            try
            {
                using (_EfConn)
                {
                    var mat = _EfConn.materias.Find(ID);
                    _EfConn.materias.Remove(mat);
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

        protected void Update(Materia mat)
        {
            try
            {
                using (_EfConn)
                {
                    var Mater = _EfConn.materias.Find(mat.ID);
                    Mater.id_materia = mat.ID;
                    Mater.desc_materia = mat.Descripcion;
                    Mater.hs_semanales = mat.HSSemanales;
                    Mater.hs_totales = mat.HSTotales;
                    Mater.id_plan = mat.IDPlan;
                    _EfConn.Entry(Mater).State = System.Data.Entity.EntityState.Modified;
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

        protected void Insert(Materia mat)
        {
            try
            {
                using (_EfConn)
                {
                    var Mater = new materias();
                    Mater.id_materia = mat.ID;
                    Mater.desc_materia = mat.Descripcion;
                    Mater.hs_semanales = mat.HSSemanales;
                    Mater.hs_totales = mat.HSTotales;
                    Mater.id_plan = mat.IDPlan;

                    _EfConn.materias.Add(Mater);
                    _EfConn.Entry(Mater).State = System.Data.Entity.EntityState.Added;
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

        public void Save(Materia mat)
        {
            if (mat.State == BusinessEntity.States.Deleted)
            {
                this.Delete(mat.ID);
            }
            else if (mat.State == BusinessEntity.States.New)
            {
                this.Insert(mat);
            }
            else if (mat.State == BusinessEntity.States.Modified)
            {
                this.Update(mat);
            }
            mat.State = BusinessEntity.States.Unmodified;
        }
    }
}
