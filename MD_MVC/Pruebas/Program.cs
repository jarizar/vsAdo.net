using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            RepositorioGenerico.Repositorio.Excepcion += Repositorio_Excepcion;
            var datos=

            RepositorioGenerico.Repositorio.QuerySQL("Select * From Persona.Persona_Tipo",
                @"data source=DESKTOP-T74P6CB;initial catalog=MD_MVC;user id=sa;password=123456;");

            Modelos.MD_MVCEntities contexto = new Modelos.MD_MVCEntities();

            using (RepositorioGenerico.Repositorio <Modelos.Producto_Tipo> obj =
                new RepositorioGenerico.Repositorio<Modelos.Producto_Tipo>(contexto))
            {
               obj.Excepcion += Repositorio_Excepcion;
               var datosDeTipos= obj.All();

            }

            Console.WriteLine("Presione <enter> salir ...");
            Console.ReadLine();
        }

        private static void Repositorio_Excepcion(object sender, RepositorioGenerico.ExceptionEvenArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
