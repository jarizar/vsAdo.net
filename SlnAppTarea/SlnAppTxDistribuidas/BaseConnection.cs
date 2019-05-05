using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class BaseConnection
    {
        //BD: Chinook
        public string ConnectionString
        {
            get
            {
                ///P@$$w0rd
                string cnx = @"Data source=MI607-ST\SQL2016PIVOT; Initial Catalog=Chinook;User id=chinook;Password=123456";
                //string cnx = @"Data source=JOSE\MSSQLSERVER2; Initial Catalog=Chinook;User id=sa;Password=123456";

                return cnx;

            }

        }

        //BD: Chinook2
        public string ConnectionString2
        {
            get
            {
                ///P@$$w0rd
                string cnx2 = @"Data source=MI607-ST\SQL2016PIVOT; Initial Catalog=Chinook2;User id=sa;Password=123456";
                //string cnx2 = @"Data source=JOSE\MSSQLSERVER2; Initial Catalog=Chinook2;User id=sa;Password=123456";

                return cnx2;

            }

        }
    }
}
