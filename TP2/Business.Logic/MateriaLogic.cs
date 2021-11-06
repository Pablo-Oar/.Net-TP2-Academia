using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;

namespace Business.Logic
{
    public class MateriaLogic
    {

        private Data.Database.MateriaAdapter _MateriaData;

        public Data.Database.MateriaAdapter MateriaData
        {
            get
            {
                return _MateriaData;
            }
            set
            {
                _MateriaData = value;
            }
        }

        public MateriaLogic()
        {
            this.MateriaData = new Data.Database.MateriaAdapter();
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public Materia GetOne(int IdMat)
        {
            return MateriaData.GetOne(IdMat);
        }
        public void Delete(int IdUsuario)
        {
            MateriaData.Delete(IdUsuario);
        }
        public void Save(Materia mat)
        {
            MateriaData.Save(mat);
        }
    }
}
