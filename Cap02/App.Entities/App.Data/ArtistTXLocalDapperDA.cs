using App.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace App.Data
{
    public class ArtistTXLocalDapperDA : BaseConnection   
    {
        ///<summary>
        ///Permite obtener la cantidad de registros
        ///que existen en la tabla artista
        /// </summary>     
        /// <returns>Retorna el numero de registros
        /// </returns>
        public int GetCount() {

            var result = 0;

            var sql = "SELECT COUNT(1) FROM ARTIST";
            /*1.- Creando la instancia del objeto connection   */
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {               
               result=cn.ExecuteScalar<int>(sql);
            }
            
            return result;
        }

        /// <summary>
        /// Permite obtener la lista de artistas
        /// </summary>
        /// <returns>Lista de artistas</returns>
        
        public List<Artista> GetAll()
        {
            var result = new List<Artista>();

            var sql = "Select * from Artist";

            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                result = cn.Query<Artista>(sql).ToList(); 
            }
                return result;
            
        }


        public Artista Get(int id) {
            var result = new Artista();

            var sql = "Select * from Artist where ArtistId=@id";            
                            
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                result=cn.QueryFirstOrDefault<Artista>(sql,
                    new { id = id }
                    );
            }
            return result;

        }


        public List<Artista> GetAllfilter(string filterByName="")
        {
            var result = new List<Artista>();

            var sql = "Select * from Artist where Name like @filterByName";

            filterByName = $"%{filterByName}%";

            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                result = cn.Query<Artista>(sql,
                    new { filterByName = filterByName }
                    ).ToList();
            }
                return result;
            
        }
        
        //Stored procedure

        public List<Artista> GetAllSP(string filterByName = "")
        {
            var result = new List<Artista>();

            var sql = "usp_GetAll";
                       
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                cn.Query<Artista>(sql,
                    new { filterByName = filterByName },
                    commandType:CommandType.StoredProcedure).ToList();                    
                }
                return result;
            
        }


        public int Insert(Artista entity)
        {
            var Result = 0;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                Result = cn.ExecuteScalar<int>("usp_InsertArtist",
                    new { pName = entity.Name },
                    commandType: CommandType.StoredProcedure
                    );

            }
            return Result;
            
              
        }

        public int Update(Artista entity)
        {
            var Result = 0;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                Result=cn.Execute("usp_UpdateArtist",
                    new { pName = entity.Name, pId = entity.ArtistID },
                    commandType: CommandType.StoredProcedure);
            }
                return Result;            
        }


        public int delete(Artista entity)
        {
            var Result = 0;
            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {
                Result = cn.Execute("usp_UpdateArtist",
                        new {pId = entity.ArtistID },
                        commandType: CommandType.StoredProcedure);
            }               
            
            return Result;


        }

    }
}
