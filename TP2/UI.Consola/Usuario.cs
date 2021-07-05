using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuario
    {
        private UsuarioLogic _UsuarioNegocio;       

        public void menu()
        {
            System.Console.WriteLine("1– Listado General \n2– Consulta\n3– Agregar\n4 - Modificar\n5 - Eliminar\n6 - Salir");
            int opc = Convert.ToInt32(Console.ReadLine());

            switch (opc)
            {
                case 1:
                    ListadoGeneral();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                default:
                    break;
            }
        }           
        
       public void ListadoGeneral()
        {
            foreach (Business.Entities.Usuario us in _UsuarioNegocio.GetAll())
            {
                MostrarDatos(us);
            }
        }

        public void MostrarDatos(Business.Entities.Usuario us)
        {
            Console.WriteLine("Usuario: {0}", us.ID);
            Console.WriteLine("\t\tNombre: {0}", us.Nombre);
            Console.WriteLine("\t\tApellido: {0}", us.Apellido);
            Console.WriteLine("\t\tNombre de usuario: {0}", us.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", us.Clave);
            Console.WriteLine("\t\tEmail: {0}", us.EMail);
            Console.WriteLine("\t\tHabilitado: {0}", us.Habilitado);
            Console.ReadKey();
        }

        public UsuarioLogic UsuarioNegocio
        {
            get
            {
                return _UsuarioNegocio;
            }
            set
            {
                _UsuarioNegocio = value;
            }
        }

        public Usuario()
        {
            this._UsuarioNegocio = new UsuarioLogic();
           
        }
    }
}
