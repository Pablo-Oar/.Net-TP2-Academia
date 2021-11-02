using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;

namespace Business.Logic
{
    public class PersonasLogic
    {

        private Data.Database.PersonasAdapter _PersonasData;

        public Data.Database.PersonasAdapter PersonasData
        {
            get
            {
                return _PersonasData;
            }
            set
            {
                _PersonasData = value;
            }
        }

        public PersonasLogic()
        {
            this.PersonasData = new Data.Database.PersonasAdapter();
        }

        public List<Personas> GetAll()
        {
            return PersonasData.GetAll();
        }

        //public Usuario GetOne(int IdUsuario)
        //{
        //    return PersonasData.GetOne(IdUsuario);
        //}
        //public void Delete(int IdUsuario)
        //{
        //    PersonasData.Delete(IdUsuario);
        //}
        //public void Save(Usuario User)
        //{
        //    PersonasData.Save(User);
        //}
    }
}
