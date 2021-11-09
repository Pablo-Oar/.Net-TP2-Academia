using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;

namespace Business.Logic
{
    public class UsuarioLogic
    {

        private Data.Database.UsuarioAdapter _UsuarioData;

        public Data.Database.UsuarioAdapter UsuarioData
        {
            get
            {
                return _UsuarioData;
            }
            set
            {
                _UsuarioData = value;
            }
        }

        public UsuarioLogic()
        {
            this.UsuarioData = new Data.Database.UsuarioAdapter();
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }
        public Usuario GetOne(int IdUsuario)
        {
            return UsuarioData.GetOne(IdUsuario);
        }
        public void Delete(int IdUsuario)
        {
            UsuarioData.Delete(IdUsuario);
        }
        public void Save(Usuario User)
        {
            UsuarioData.Save(User);
        }

        public UsuarioPersona LogIn(string nombreUsuario, string contraseña)
        {
            try
            {
                UsuarioPersona usu = UsuarioData.LogIn(nombreUsuario, contraseña);
                PersonasLogic pl = new PersonasLogic();
                Personas per = pl.GetOne(usu.IdPerosna);
                usu.TipoPersona = (UsuarioPersona.TiposPersonas)per.TipoPersona;
                usu.Direccion = per.Direccion;
                usu.IDPlan = per.IDPlan;
                usu.Legajo = per.Legajo;
                usu.Telefono = per.Telefono;
                usu.FechaNacimiento = per.FechaNacimiento;
                usu.Direccion = per.Direccion;
                return usu;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
