using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class BaseConnection
    {
        public string ConnectionString {
            get
            {
                ///P@$$w0rd
                string cnx = @"Data source=MI607-ST\SQL2016PIVOT; Initial Catalog=Chinook;User id=chinook;Password=123456";

                return cnx;

            }

        }
    }
}
