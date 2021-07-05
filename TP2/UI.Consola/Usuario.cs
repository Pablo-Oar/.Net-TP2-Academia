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
        { int opc;
            do
            {
                Console.Clear();
                System.Console.WriteLine("1– Listado General \n2– Consulta\n3– Agregar\n4 - Modificar\n5 - Eliminar\n6 - Salir");
                opc = Convert.ToInt32(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        ListadoGeneral();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 3:
                        Agregar();
                        break;
                    case 4:
                        Modificar();
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            } while (opc != 6);
        }           
        
       public void ListadoGeneral()
        {
            foreach (Business.Entities.Usuario us in _UsuarioNegocio.GetAll())
            {
                MostrarDatos(us);
            }
        }

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a consultar");
                int ID = Convert.ToInt32(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch(FormatException e) 
            {
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                
            }
        }

        public void Agregar()
        {
            
                Business.Entities.Usuario usuario = new Business.Entities.Usuario();
                Console.WriteLine("Ingrese nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese nombre de usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese clave: ");
                usuario.Clave = Console.ReadLine();
                Console.WriteLine("Ingrese Email: ");
                usuario.EMail = Console.ReadLine();
                Console.WriteLine("Ingrese habilidation de usuario (1-Si / otro - No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.New;
                UsuarioNegocio.Save(usuario);
                Console.WriteLine("ID: {}", usuario.ID);   
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
        }
        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a modificar: ");
                int ID = Convert.ToInt32(Console.ReadLine());
                Business.Entities.Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.WriteLine("Ingrese nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese nombre de usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese clave: ");
                usuario.Clave = Console.ReadLine();
                Console.WriteLine("Ingrese Email: ");
                usuario.EMail = Console.ReadLine();
                Console.WriteLine("Ingrese habilidation de usuario (1-Si / otro - No): ");
                usuario.Habilitado = (Console.ReadLine()=="1");
                UsuarioNegocio.Save(usuario);
            }
            catch(FormatException fe)
            {
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                
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
