using App.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace App.Data
{
    public class ArtistTXLocalDapperDA : BaseConnection
    {
        /// <summary>
        /// Permite obtener la cantidad de registros
        /// que existen en la tabla artista
        /// </summary>
        /// <returns>Retorna el numero de registros</returns>
        public int GetCount()
        {
            var result = 0;
            var sql = "SELECT COUNT(1) FROM Artist";
            /*1.- Creando la instancia del objeto 
             connection
             */
            using (IDbConnection
                cn = new SqlConnection(base.ConnectionString))
            {
                result =  cn.ExecuteScalar<int>(sql);
            }

            return result;

        }


        /// <summary>
        /// Permite obtener la lista de artistas
        /// </summary>
        /// <returns>Lista de artistas</returns>
        public List<Artist> GetAll(string filterByName="")
        {
            var result = new List<Artist>();
            var sql = "SELECT * FROM Artist WHERE Name LIKE @paramFilterByName ";

            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                result = cn.Query<Artist>(sql,
                    new { paramFilterByName= filterByName }
                    ).ToList();
            }

            return result;

        }

        public Artist Get(int id)
        {
            var result = new Artist();

            var sql = "SELECT * FROM Artist WHERE ArtistId = @paramID ";

            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                result = cn.QueryFirstOrDefault<Artist>(sql,
                    new { paramID = id }
                    );
            }


            return result;

        }

        /// <summary>
        /// Permite obtener la lista de artistas
        /// </summary>
        /// <returns>Lista de artistas</returns>
        public List<Artist> GetAllSP(string filterByName = "")
        {
            var result = new List<Artist>();
            var sql = "usp_GetAll";

            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                result = cn.Query<Artist>(sql,                    
                    new {filterByName= filterByName },                    
                    commandType:CommandType.StoredProcedure).ToList();
            }

            return result;

        }


        public int Insert(Artist entity)
        {
            var result = 0;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                result = cn.ExecuteScalar<int>("usp_InsertArtist",
                    new { pName = entity.Name },
                    commandType: CommandType.StoredProcedure
                    );                
            }
            return result;
        }


        public bool Update(Artist entity)
        {
            var result = false;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                result = cn.Execute("usp_UpdateArtist",
                    new { pName = entity.Name, pId = entity.ArtistId },
                    commandType: CommandType.StoredProcedure
                    )>0;
            }
            return result;
        }


        public bool Delete(int id)
        {
            var result = false;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                result = cn.Execute("usp_DeleteArtist",
                     new { pId = id },
                     commandType: CommandType.StoredProcedure
                     )>0;
             }
            return result;
        }

        public int InsertTx(Artist entity)
        {
            var result = 0;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                //Abriendo la conexión a la base de datos
                cn.Open();

                //Iniciamos la transacciones
                var tx = cn.BeginTransaction();

                try
                {
                    result = cn.ExecuteScalar<int>("usp_InsertArtist",
                        new { pName = entity.Name },
                        commandType: CommandType.StoredProcedure,transaction:tx
                        );

                    //Confirmando la transaccion
                    tx.Commit();

                }
                catch (Exception)
                {
                    //Deshacer las operaciones realizadas en la transaccion
                    tx.Rollback();
                 
                }

            }
            return result;
        }


        public bool UpdateTX(Artist entity)
        {
            var result = false;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                //Abriendo la conexión a la base de datos
                cn.Open();

                //Iniciamos la transacciones
                var tx = cn.BeginTransaction();

                try
                { result = cn.Execute("usp_UpdateArtist",
                  new { pName = entity.Name, pId = entity.ArtistId },
                  commandType: CommandType.StoredProcedure, transaction: tx
                  ) > 0;

                    //Confirmando la transaccion
                    tx.Commit();
                }
                catch (Exception)
                {
                    //Deshacer las operaciones realizadas en la transaccion
                    tx.Rollback();
                }

            }
            return result;
        }


        public bool DeleteTX(int id)
        {
            var result = false;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                result = cn.Execute("usp_DeleteArtist",
                     new { pId = id },
                     commandType: CommandType.StoredProcedure
                     ) > 0;
            }
            return result;
        }





    }
}
