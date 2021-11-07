using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Linq;

namespace Data.Database
{
    public class PersonasAdapter:Adapter
    {

       
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
                    Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas" + Ex, Ex);
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
                Exception ExcepcionDatosUsuario = new Exception("Error al recuperar datos de la persona", Ex);
                throw ExcepcionDatosUsuario;
            }
            return persona;
        }

        public List<Personas> GetByTipo(int tipo)
        {
            using (_EfConn)
            {
                List<Personas> lsPersonas = new List<Personas>();
                try
                {
                    Personas persona;
                    List<personas> personas = (from p in _EfConn.personas where p.tipo_persona == tipo select p).ToList();
                    foreach (var per in personas)
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

        public Business.Entities.Personas GetByUser(Usuario us)
        {
            Personas persona = new Personas();
            try
            {
                using (_EfConn)
                {
                    var per = _EfConn.personas.Find(us.IdPerosna);
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
                Exception ExcepcionDatosUsuario = new Exception("Error al recuperar datos de la persona", Ex);
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
                Exception ExcepcionEliminarUsuario = new Exception("Error al eliminar persona", Ex);
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
                    _EfConn.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                    _EfConn.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionModificaDatosUsuario = new Exception("Error al modificar los datos de la persona", Ex);
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
                    _EfConn.Entry(persona).State = System.Data.Entity.EntityState.Added;
                    _EfConn.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionInsertarUsuario = new Exception("Error al crear persona", Ex);
                throw ExcepcionInsertarUsuario;
            }
            finally
            {
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
