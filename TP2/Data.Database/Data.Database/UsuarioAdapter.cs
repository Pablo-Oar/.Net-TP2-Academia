using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usr = null;
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios", SqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    usr = new Usuario();
                    //Mapeo de registro a objeto.
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.IdPerosna = (int)drUsuarios["id_persona"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];

                    usuarios.Add(usr);
                }

                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios WHERE id_usuario = @id", SqlConn);
                cmdUsuarios.Parameters.AddWithValue("@id", ID);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.IdPerosna = (int)drUsuarios["id_persona"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionDatosUsuario = new Exception("Error al recuperar datos de usuario",Ex);
                throw ExcepcionDatosUsuario;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public Usuario Login(string us, string pw)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios WHERE usuarios.nombre_usuario = 'sdsds1233332' and usuarios.clave = 'nanusongo';", SqlConn);
                cmdUsuarios.Parameters.AddWithValue("@nus", us);
                cmdUsuarios.Parameters.AddWithValue("@clave", pw);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.IdPerosna = (int)drUsuarios["id_persona"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionDatosUsuario = new Exception("usuario o contraseña incorrectos", Ex);
                throw ExcepcionDatosUsuario;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE usuarios WHERE id_usuario=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionEliminarUsuario = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionEliminarUsuario;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave," +
                    "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email, id_persona = @id_persona WHERE id_usuario=@id", SqlConn);
               
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPerosna;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionModificaDatosUsuario = new Exception("Error al modificar los datos de usuario", Ex);
                throw ExcepcionModificaDatosUsuario;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO usuarios (nombre_usuario, clave, habilitado, nombre, apellido, email, id_persona)"+
                    "VALUES(@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email, @id_persona) SELECT @@identity", SqlConn);

                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPerosna;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); //Así obtengo el ID que se asigno a la BD automaticamente.
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

        public void Save(Usuario usuario)
        {
            if(usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if(usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if(usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }

        public Usuario LogIn(string nombreUsuario, string contrasena)
        {
            Usuario user = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios WHERE (nombre_usuario = @nombre_usuario AND clave = @clave)", SqlConn);
                cmdUsuarios.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = nombreUsuario;
                cmdUsuarios.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = contrasena;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    user.ID = (int)drUsuarios["id_usuario"];
                    user.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    user.Clave = (string)drUsuarios["clave"];
                    user.Habilitado = (bool)drUsuarios["habilitado"];
                    user.Nombre = (string)drUsuarios["nombre"];
                    user.Apellido = (string)drUsuarios["apellido"];
                    user.EMail = (string)drUsuarios["email"];
                    user.IdPerosna = (int)drUsuarios["id_persona"];
                }
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error durante el logueo" + e.Message);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return user;
        }
    }
}
