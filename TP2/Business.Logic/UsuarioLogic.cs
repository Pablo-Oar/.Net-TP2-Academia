using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;

namespace Business.Logic
{
    public class UsuarioLogic: BusinessLogic
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
            this._UsuarioData = UsuarioData.New;
        }

        public List<Usuario> GetAll()
        {

        }



    }
}
