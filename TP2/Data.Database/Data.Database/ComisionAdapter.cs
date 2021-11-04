using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;

namespace Data.Database
{
    public class ComisionAdapter:Adapter
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
                    usr.EMail = "casimirocegado@gmail.Comi";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 2;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.EMail = "armandoquito@gmail.Comi";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.EMail = "alanbrado@gmail.Comi";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion

        public List<Comision> GetAll()
        {
            using (_EfConn) {
                List<Comision> lsComision = new List<Comision>();
                try
                {
                    Comision Comi;
                    var Comisiones = _EfConn.comisiones;
                    foreach(var com in Comisiones)
                    {
                        Comi = new Comision();
                        Comi.ID = com.id_comision;
                        Comi.Descripcion = com.desc_comision;
                        Comi.AñoEspecialidad = com.anio_especialidad;
                        Comi.IdPlan = com.id_plan;
                        lsComision.Add(Comi);
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
                return lsComision;
            }
        }

        public Business.Entities.Comision GetOne(int ID)
        {
            Comision Comi = new Comision();
            try
            {
                using (_EfConn)
                {
                    var com = _EfConn.comisiones.Find(ID);
                    Comi = new Comision();
                    Comi.ID = com.id_comision;
                    Comi.Descripcion = com.desc_comision;
                    Comi.AñoEspecialidad = com.anio_especialidad;
                    Comi.IdPlan = com.id_plan;                    
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionDatosUsuario = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionDatosUsuario;
            }
            return Comi;
        }

        public void Delete(int ID)
        {
            try
            {
                using (_EfConn)
                {
                    var com = _EfConn.comisiones.Find(ID);
                    _EfConn.comisiones.Remove(com);
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

        protected void Update(Comision com)
        {
            try
            {
                using (_EfConn)
                {
                    var Comi = _EfConn.comisiones.Find(com.ID);
                    Comi.id_comision = com.ID;
                    Comi.desc_comision = com.Descripcion;
                    Comi.anio_especialidad = com.AñoEspecialidad;
                    Comi.id_plan = com.IdPlan;
                    _EfConn.Entry(Comi).State = System.Data.Entity.EntityState.Modified;
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

        protected void Insert(Comision com)
        {
            try
            {
                using (_EfConn)
                {
                    var Comi = new comisiones();
                    Comi.id_comision = com.ID;
                    Comi.desc_comision = com.Descripcion;
                    Comi.anio_especialidad = com.AñoEspecialidad;
                    Comi.id_plan = com.IdPlan;

                    _EfConn.comisiones.Add(Comi);
                    _EfConn.Entry(Comi).State = System.Data.Entity.EntityState.Added;
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

        public void Save(Comision com)
        {
            if (com.State == BusinessEntity.States.Deleted)
            {
                this.Delete(com.ID);
            }
            else if (com.State == BusinessEntity.States.New)
            {
                this.Insert(com);
            }
            else if (com.State == BusinessEntity.States.Modified)
            {
                this.Update(com);
            }
            com.State = BusinessEntity.States.Unmodified;
        }
    }
}
