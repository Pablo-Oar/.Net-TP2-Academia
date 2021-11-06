using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;

namespace Business.Logic
{
    public class ComisionLogic
    {

        private Data.Database.ComisionAdapter _ComisionData;

        public Data.Database.ComisionAdapter ComisionData
        {
            get
            {
                return _ComisionData;
            }
            set
            {
                _ComisionData = value;
            }
        }

        public ComisionLogic()
        {
            this.ComisionData = new Data.Database.ComisionAdapter();
        }

        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();
        }

        public Comision GetOne(int Idcom)
        {
            return ComisionData.GetOne(Idcom);
        }
        public void Delete(int Idcom)
        {
            ComisionData.Delete(Idcom);
        }
        public void Save(Comision com)
        {
            ComisionData.Save(com);
        }
    }
}
