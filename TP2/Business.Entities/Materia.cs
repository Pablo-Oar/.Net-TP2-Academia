using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia: BusinessEntity
    {
        private string _Descripcion;
        public int _HSSemanales;
        public int _HSTotales;
        public int _IDPlan;



        public int HSSemanales
        {
            get
            {
                return _HSSemanales;
            }
            set
            {
                _HSSemanales = value;
            }
        }
        public int HSTotales
        {
            get
            {
                return _HSTotales;
            }
            set
            {
                _HSTotales = value;
            }
        }
        public int IDPlan
        {
            get
            {
                return _IDPlan;
            }
            set
            {
                _IDPlan = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                _Descripcion = value;
            }
        }
    }
}
