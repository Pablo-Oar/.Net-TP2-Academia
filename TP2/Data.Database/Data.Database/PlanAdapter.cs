using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;

namespace Data.Database
{
    public class PlanAdapter:Adapter
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

        public List<Plan> GetAll()
        {
            using (_EfConn) {
                List<Plan> lsPlan = new List<Plan>();
                try
                {
                    Plan pla;
                    var planes = _EfConn.planes;
                    foreach(var p in planes)
                    {
                        pla = new Plan();
                        pla.ID = p.id_plan;
                        pla.Descripcion = p.desc_plan;                        
                        lsPlan.Add(pla);
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
                return lsPlan;
            }
        }

        public Business.Entities.Plan GetOne(int ID)
        {
            Plan pla = new Plan();
            try
            {
                using (_EfConn)
                {
                    var p = _EfConn.planes.Find(ID);
                    pla = new Plan();
                    pla.ID = p.id_plan;
                    pla.Descripcion = p.desc_plan;
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionDatosUsuario = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionDatosUsuario;
            }
            return pla;
        }

        public void Delete(int ID)
        {
            try
            {
                using (_EfConn)
                {
                    var p = _EfConn.planes.Find(ID);
                    _EfConn.planes.Remove(p);
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

        protected void Update(Plan p)
        {
            try
            {
                using (_EfConn)
                {
                    var pla = _EfConn.planes.Find(p.ID);
                    pla.id_plan = p.ID;
                    pla.desc_plan = p.Descripcion;
                    _EfConn.Entry(pla).State = System.Data.Entity.EntityState.Modified;
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

        protected void Insert(Plan p)
        {
            try
            {
                using (_EfConn)
                {
                    var pla = new planes();
                    pla.id_plan = p.ID;
                    pla.desc_plan = p.Descripcion;

                    _EfConn.planes.Add(pla);
                    _EfConn.Entry(pla).State = System.Data.Entity.EntityState.Added;
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

        public void Save(Plan p)
        {
            if (p.State == BusinessEntity.States.Deleted)
            {
                this.Delete(p.ID);
            }
            else if (p.State == BusinessEntity.States.New)
            {
                this.Insert(p);
            }
            else if (p.State == BusinessEntity.States.Modified)
            {
                this.Update(p);
            }
            p.State = BusinessEntity.States.Unmodified;
        }
    }
}
