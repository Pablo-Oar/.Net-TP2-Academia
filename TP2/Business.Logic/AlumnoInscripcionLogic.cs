using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic
    {

        private Data.Database.AlumnoInscripcionAdapter _AlumnoInscripcionData;

        public Data.Database.AlumnoInscripcionAdapter AlumnoInscripcionData
        {
            get
            {
                return _AlumnoInscripcionData;
            }
            set
            {
                _AlumnoInscripcionData = value;
            }
        }

        public AlumnoInscripcionLogic()
        {
            this.AlumnoInscripcionData = new Data.Database.AlumnoInscripcionAdapter();
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return AlumnoInscripcionData.GetAll();
        }

        public AlumnoInscripcion GetOne(int Idins)
        {
            return AlumnoInscripcionData.GetOne(Idins);
        }
        public void Delete(int Idins)
        {
            AlumnoInscripcionData.Delete(Idins);
        }
        public void Save(AlumnoInscripcion ins)
        {
            AlumnoInscripcionData.Save(ins);
        }
    }
}
