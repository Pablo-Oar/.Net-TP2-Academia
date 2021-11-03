using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;

namespace Data.Database
{
    public class PersonasAdapter:Adapter
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

        public List<Personas> GetAll()
        {
            using (_EfConn) {
                List<Personas> lsPersonas = new List<Personas>();
                try
                {
                    Personas persona;
                    var personas = _EfConn.personas;
                    foreach(var per in personas)
                    {
                        persona = new Personas();
                        persona.ID = per.id_persona;
                        persona.Legajo = (int)per.legajo;
                        persona.Apellido = per.apellido;
                        persona.Direccion = per.direccion;
                        persona.Email = per.email;
                        persona.FechaNacimiento = per.fecha_nac;
                        persona.IDPlan = per.id_plan;
                        persona.Nombre = per.nombre;
                        persona.Apellido = per.apellido;
                        persona.Telefono = per.telefono;
                        persona.TipoPersona = (Personas.TiposPersonas)per.tipo_persona;
                        lsPersonas.Add(persona);
                    }
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios" + Ex, Ex);
                    throw ExcepcionManejada;
                }
                finally
                {
                }
                return lsPersonas;
            }
        }

        public Business.Entities.Personas GetOne(int ID)
        {
            Personas persona = new Personas();
            try
            {
                using (_EfConn)
                {
                    var per = _EfConn.personas.Find(ID);
                    persona = new Personas();
                    persona.ID = per.id_persona;
                    persona.Legajo = (int)per.legajo;
                    persona.Direccion = per.direccion;
                    persona.Email = per.email;
                    persona.FechaNacimiento = per.fecha_nac;
                    persona.IDPlan = per.id_plan;
                    persona.Nombre = per.nombre;
                    persona.Apellido = per.apellido;
                    persona.Telefono = per.telefono;
                    persona.TipoPersona = (Personas.TiposPersonas)per.tipo_persona;
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionDatosUsuario = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionDatosUsuario;
            }
            return persona;
        }

        public void Delete(int ID)
        {
            try
            {
                using (_EfConn)
                {
                    var per = _EfConn.personas.Find(ID);
                    _EfConn.personas.Remove(per);
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

        protected void Update(Personas per)
        {
            try
            {
                using (_EfConn)
                {
                    var persona = _EfConn.personas.Find(per.ID);
                    persona.id_persona = per.ID;
                    persona.legajo = (int)per.Legajo;
                    persona.apellido = per.Apellido;
                    persona.direccion = per.Direccion;
                    persona.email = per.Email;
                    persona.fecha_nac = per.FechaNacimiento;
                    persona.id_plan = per.IDPlan;
                    persona.nombre = per.Nombre;
                    persona.telefono = per.Telefono;
                    persona.tipo_persona = (int)per.TipoPersona;
                    _EfConn.Entry(per).State = System.Data.Entity.EntityState.Modified;
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

        protected void Insert(Personas per)
        {
            try
            {
                using (_EfConn)
                {
                    var persona = new personas();
                    persona.legajo = (int)per.Legajo;
                    persona.apellido = per.Apellido;
                    persona.direccion = per.Direccion;
                    persona.email = per.Email;
                    persona.fecha_nac = per.FechaNacimiento;
                    persona.id_plan = per.IDPlan;
                    persona.nombre = per.Nombre;
                    persona.telefono = per.Telefono;
                    persona.tipo_persona = (int)per.TipoPersona;
                    _EfConn.personas.Add(persona);
                    _EfConn.Entry(per).State = System.Data.Entity.EntityState.Added;
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
                this.CloseConnection();
            }
        }

        public void Save(Personas pers)
        {
            if (pers.State == BusinessEntity.States.Deleted)
            {
                this.Delete(pers.ID);
            }
            else if (pers.State == BusinessEntity.States.New)
            {
                this.Insert(pers);
            }
            else if (pers.State == BusinessEntity.States.Modified)
            {
                this.Update(pers);
            }
            pers.State = BusinessEntity.States.Unmodified;
        }
    }
}
