using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;

namespace Business.Logic
{
    public class DocenteCursoLogic
    {

        private Data.Database.DocenteCursoAdapter _DocenteCursoData;

        public Data.Database.DocenteCursoAdapter DocenteCursoData
        {
            get
            {
                return _DocenteCursoData;
            }
            set
            {
                _DocenteCursoData = value;
            }
        }

        public DocenteCursoLogic()
        {
            this.DocenteCursoData = new Data.Database.DocenteCursoAdapter();
        }

        public List<DocenteCurso> GetAll()
        {
            return DocenteCursoData.GetAll();
        }

        public DocenteCurso GetOne(int Iddoc)
        {
            return DocenteCursoData.GetOne(Iddoc);
        }
        public void Delete(int IdUsuario)
        {
            DocenteCursoData.Delete(IdUsuario);
        }
        public void Save(DocenteCurso doc)
        {
            DocenteCursoData.Save(doc);
        }
    }
}
