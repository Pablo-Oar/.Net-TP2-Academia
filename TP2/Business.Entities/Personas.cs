using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Personas:BusinessEntity
    {
        private string _Nombre;//
        private string _Apellido;//
        private string _Email;//
        private string _Direccion;
        private int _IDPlan;
        private int _Legajo;
        private string _Telefono;
        private DateTime _FechaNacimiento;
        private TiposPersonas _TipoPersona;

        public enum TiposPersonas
        {
            Admin,
            Alumno,
            Docente,
        }
        public int Legajo
        {
            get
            {
                return _Legajo;
            }
            set
            {
                _Legajo = value;
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
        public string Direccion
        {
            get
            {
                return _Direccion;
            }
            set
            {
                _Direccion = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                _Nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return _Apellido;
            }
            set
            {
                _Apellido = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _Telefono;
            }
            set
            {
                _Telefono = value;
            }
        }
        
        public DateTime FechaNacimiento
        {
            get
            {
                return _FechaNacimiento;
            }
            set
            {
                _FechaNacimiento = value;
            }
        }

        public TiposPersonas TipoPersona
        {
            get
            {
                return _TipoPersona;
            }
            set
            {
                _TipoPersona = value;
            }
        }

    }
}
