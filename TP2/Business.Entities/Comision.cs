using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision:BusinessEntity
    {
        private int _IdPlan;
        private int _AñoEspecialidad;
        private string _Descripcion;


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
        public int IdPlan
        {
            get
            {
                return _IdPlan;
            }
            set
            {
                _IdPlan = value;
            }
        }
        public int AñoEspecialidad
        {
            get
            {
                return _AñoEspecialidad;
            }
            set
            {
                _AñoEspecialidad = value;
            }
        }
    }
}
