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

        static void Main(string[] args)
        {
            menu();

            void menu()
            {
                System.Console.WriteLine("1– Listado General \n2– Consulta\n3– Agregar\n4 - Modificar\n5 - Eliminar\n6 - Salir");
                int opc = Convert.ToInt32(Console.ReadLine());

                switch (opc)
                {
                    case 1:
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
        }
        List<Business.Entities.Usuario> ListadoGeneral()
        {
            return _UsuarioNegocio.GetAll();
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

        Usuario()
        {
            this._UsuarioNegocio = new UsuarioLogic();
        }
    }
}
