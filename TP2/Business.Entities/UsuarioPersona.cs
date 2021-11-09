using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class UsuarioPersona:BusinessEntity
    {
        private string _Nombre;
        private string _Apellido;
        private string _Email;
        private string _Direccion;
        private int _IDPlan;
        private int _Legajo;
        private string _Telefono;
        private DateTime _FechaNacimiento;
        private TiposPersonas _TipoPersona;
        private string _NombreUsuario;
        private string _Clave;
        private bool _Habilitado;
        private int _Id_persona;
        private int _Id_usuario;

        public Personas GetPersona()
        {
            Personas p = new Personas();
            p.Apellido = this.Apellido;
            p.Nombre = this.Nombre;
            p.Email = this.Email;
            p.Direccion = this.Direccion;
            p.IDPlan = this.IDPlan;
            p.Legajo = this.Legajo;
            p.Telefono = this.Telefono;
            p.FechaNacimiento = this.FechaNacimiento;
            p.TipoPersona = (Personas.TiposPersonas)this.TipoPersona;
            p.ID = this.IdPerosna;
            return p;

        }

        public Usuario GetUsuario()
        {
            Usuario p = new Usuario();
            p.Apellido = this.Apellido;
            p.Nombre = this.Nombre;
            p.EMail = this.Email;
            p.Clave = this.Clave;
            p.Habilitado = this.Habilitado;
            p.NombreUsuario = this.NombreUsuario;
            p.ID = this.ID;
            return p;

        }

        public void SetUsuario(Usuario p)
        {
            this.Apellido = p.Apellido;
            this.Nombre = p.Nombre;
            this.Email = p.EMail;
            this.Clave = p.Clave;
            this.Habilitado = p.Habilitado;
            this.NombreUsuario = p.NombreUsuario;
            this.ID = p.ID;            
        }

        public void SetPersona(Personas p)
        {
            this.Apellido = p.Apellido;
            this.Nombre = p.Nombre;
            this.Email = p.Email;
            this.Direccion = p.Direccion;
            this.IDPlan = p.IDPlan;
            this.Legajo = p.IDPlan;
            this.Telefono = p.Telefono;
            this.FechaNacimiento = p.FechaNacimiento;
            this.TipoPersona = (TiposPersonas)p.TipoPersona;
            this.IdPerosna = p.ID;   
        }

        public enum TiposPersonas
        {
            Admin,
            Alumno,
            Docente,
        }

        public int IdUsuario
        {
            get
            {
                return _Id_usuario;
            }
            set
            {
                _Id_usuario = value;
            }
        }
        public int IdPerosna
        {
            get
            {
                return _Id_persona;
            }
            set
            {
                _Id_persona = value;
            }
        }

        public bool Habilitado
        {
            get
            {
                return _Habilitado;
            }
            set
            {
                _Habilitado = value;
            }
        }

        public string Clave
        {
            get
            {
                return _Clave;
            }
            set
            {
                _Clave = value;
            }
        }
        public string NombreUsuario
        {
            get
            {
                return _NombreUsuario;
            }
            set
            {
                _NombreUsuario = value;
            }
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
