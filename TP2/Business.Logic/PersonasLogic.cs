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

        public Personas GetOne(int IdPer)
        {
            return PersonasData.GetOne(IdPer);
        }

        public List<Personas> GetByTipo(int tipo)
        {
            return PersonasData.GetByTipo(tipo);
        }
        public void Delete(int IdUsuario)
        {
            PersonasData.Delete(IdUsuario);
        }
        public void Save(Personas per)
        {
            PersonasData.Save(per);
        }
    }
}
