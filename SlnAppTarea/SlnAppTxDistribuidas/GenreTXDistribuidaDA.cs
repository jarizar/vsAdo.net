using App.Data;
using App.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SlnAppTxDistribuidas
{
   public class GenreTXDistribuidaDA: BaseConnection
    {
        public int Insert(Genre2 entity)
        {
            var Result = 0;

            using (var trx = new TransactionScope())
            {
                try
                {
                    using (IDbConnection cn = new SqlConnection(this.ConnectionString))
                    {
                        cn.Open();

                        IDbCommand cmd = new SqlCommand("usp_InsertGenre");
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(
                            new SqlParameter("@pName", entity.Name)
                            );
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }


                    using (IDbConnection cn2 = new SqlConnection(this.ConnectionString2))
                    {
                        cn2.Open();

                        IDbCommand cmd = new SqlCommand("usp_InsertGenre");
                        cmd.Connection = cn2;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(
                            new SqlParameter("@pName", entity.Name)
                            );
                        Result = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    //Generando una excepción
                    //throw new Exception("Error");

                    //confirma la transacción
                    trx.Complete();
                }
                catch (Exception ex)
                {
                    Result = 0;
                }
                return Result;
            }
        }

    }
}
