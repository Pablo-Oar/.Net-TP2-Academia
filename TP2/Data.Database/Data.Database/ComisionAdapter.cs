using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;

namespace Data.Database
{
    public class ComisionAdapter:Adapter
    {
        
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
