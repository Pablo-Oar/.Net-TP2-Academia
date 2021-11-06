using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;

namespace Business.Logic
{
    public class UsuarioLogic
    {

        private Data.Database.UsuarioAdapter _UsuarioData;

        public Data.Database.UsuarioAdapter UsuarioData
        {
            get
            {
                return _UsuarioData;
            }
            set
            {
                _UsuarioData = value;
            }
        }

        public UsuarioLogic()
        {
            this.UsuarioData = new Data.Database.UsuarioAdapter();
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public List<Usuario> Login(string us, string pw)
        {
            return UsuarioData.Login( us, pw);
        }

        public Usuario GetOne(int IdUsuario)
        {
            return UsuarioData.GetOne(IdUsuario);
        }
        public void Delete(int IdUsuario)
        {
            UsuarioData.Delete(IdUsuario);
        }
        public void Save(Usuario User)
        {
            UsuarioData.Save(User);
        }

        public Usuario LogIn(string nombreUsuario, string contraseña)
        {
            try
            {
                Usuario usu = UsuarioData.LogIn(nombreUsuario, contraseña);
                return usu;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
