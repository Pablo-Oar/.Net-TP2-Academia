using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;

namespace Business.Logic
{
    public class EspecialidadLogic
    {

        private Data.Database.EspecialidadAdapter _EspecialidadData;

        public Data.Database.EspecialidadAdapter EspecialidadData
        {
            get
            {
                return _EspecialidadData;
            }
            set
            {
                _EspecialidadData = value;
            }
        }

        public EspecialidadLogic()
        {
            this.EspecialidadData = new Data.Database.EspecialidadAdapter();
        }

        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }

        public Especialidad GetOne(int Idesp)
        {
            return EspecialidadData.GetOne(Idesp);
        }
        public void Delete(int IdUsuario)
        {
            EspecialidadData.Delete(IdUsuario);
        }
        public void Save(Especialidad esp)
        {
            EspecialidadData.Save(esp);
        }
    }
}
