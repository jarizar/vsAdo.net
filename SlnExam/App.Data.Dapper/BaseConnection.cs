using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class BaseConnection
    {

        public string ConnectionString
        {
            get
            {
                //string cnx = @"Data source=MI607-ST\SQL2016PIVOT; Initial Catalog=Chinook;User id=chinook;Password=123456";
                string cnx = @"Data source=MI607-ST\SQL2016PIVOT; Initial Catalog=dbColegio;User id=sa;Password=123456";

                return cnx;
            }
        }
    }
}
