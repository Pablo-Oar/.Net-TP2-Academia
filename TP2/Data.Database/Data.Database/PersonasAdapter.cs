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
                    persona.Apellido = per.apellido;
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

        //    protected void Update(Usuario usuario)
        //    {
        //        try
        //        {
        //            this.OpenConnection();
        //            SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave," +
        //                "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email WHERE id_usuario=@id", SqlConn);

        //            cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
        //            cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
        //            cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
        //            cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
        //            cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
        //            cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
        //            cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;

        //            cmdSave.ExecuteNonQuery();
        //        }
        //        catch (Exception Ex)
        //        {
        //            Exception ExcepcionModificaDatosUsuario = new Exception("Error al modificar los datos de usuario", Ex);
        //            throw ExcepcionModificaDatosUsuario;
        //        }
        //        finally
        //        {
        //            this.CloseConnection();
        //        }
        //    }

        //    protected void Insert(Usuario usuario)
        //    {
        //        try
        //        {
        //            this.OpenConnection();
        //            SqlCommand cmdSave = new SqlCommand("INSERT INTO usuarios (nombre_usuario, clave, habilitado, nombre, apellido, email)"+
        //                "VALUES(@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email) SELECT @@identity", SqlConn);

        //            cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
        //            cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
        //            cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
        //            cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
        //            cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
        //            cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;
        //            usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); //Así obtengo el ID que se asigno a la BD automaticamente.
        //        }
        //        catch (Exception Ex)
        //        {
        //            Exception ExcepcionInsertarUsuario = new Exception("Error al crear usuario", Ex);
        //            throw ExcepcionInsertarUsuario;
        //        }
        //        finally
        //        {
        //            this.CloseConnection();
        //        }
        //    }

        //    public void Save(Usuario usuario)
        //    {
        //        if(usuario.State == BusinessEntity.States.Deleted)
        //        {
        //            this.Delete(usuario.ID);
        //        }
        //        else if(usuario.State == BusinessEntity.States.New)
        //        {
        //            this.Insert(usuario);
        //        }
        //        else if(usuario.State == BusinessEntity.States.Modified)
        //        {
        //            this.Update(usuario);
        //        }
        //        usuario.State = BusinessEntity.States.Unmodified;
        //    }
    }
}
