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
            this._UsuarioData = new Data.Database.UsuarioAdapter();
        }

        public List<Usuario> GetAll()
        {
            return _UsuarioData.GetAll();
        }

        public Usuario GetOne(int IdUsuario)
        {
            return _UsuarioData.GetOne(IdUsuario);
        }
        public void delete(int IdUsuario)
        {
            _UsuarioData.Delete(IdUsuario);
        }
        public void Save(Usuario User)
        {
            _UsuarioData.Save(User);
        }
    }
}
