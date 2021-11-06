using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;

namespace Business.Logic
{
    public class CursoLogic
    {

        private Data.Database.CursoAdapter _CursoData;

        public Data.Database.CursoAdapter CursoData
        {
            get
            {
                return _CursoData;
            }
            set
            {
                _CursoData = value;
            }
        }

        public CursoLogic()
        {
            this.CursoData = new Data.Database.CursoAdapter();
        }

        public List<Curso> GetAll()
        {
            return CursoData.GetAll();
        }

        public Curso GetOne(int Idcur)
        {
            return CursoData.GetOne(Idcur);
        }
        public void Delete(int Idcur)
        {
            CursoData.Delete(Idcur);
        }
        public void Save(Curso cur)
        {
            CursoData.Save(cur);
        }
    }
}
