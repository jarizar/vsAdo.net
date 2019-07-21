
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Queries
{
    public class PermisoQuery
    {

        public Empleado PEmpleado { get; set; }
        public List<MenuQuery> PMenu { get; set; }
        public bool Estado { get; set; }

        public PermisoQuery(Empleado Empleado, List<MenuQuery> LMenu, bool Estado)
        {
            this.PEmpleado = Empleado;
            this.PMenu = LMenu;
            this.Estado = Estado;
        }

        public PermisoQuery() : this(new Empleado(), new List<MenuQuery>(), false) { }
    }
}
