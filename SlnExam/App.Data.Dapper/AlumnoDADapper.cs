using App.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Transactions;

namespace App.Data
{
    public class AlumnoDADapper : BaseConnection
    {
        public int InsertTXLocal(Alumno alumno)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {

                //Abriendo la conexion a la base de datos
                cn.Open();
                //Iniciando la transacciones
                var tx = cn.BeginTransaction();
                try
                {
                    var alumnoID = cn.ExecuteScalar<int>("sp_insertalumno",
                        new
                        {
                            pNombres = alumno.Nombres,
                            papellidos = alumno.Apellidos,
                            pdireccion = alumno.Direccion,
                            psexo = alumno.Sexo,
                            pFechaNacimiento = alumno.FechaNacimiento                           
                        }, commandType: CommandType.StoredProcedure,
                        transaction: tx
                        );


                    foreach (var item in alumno.notas)
                    {
                        cn.Execute("usp_InsertNota",
                            new
                            {
                                palumnoID = alumnoID,
                                pCursoId = item.CursoID,
                                pnota = item.Nota                           

                            }, commandType: CommandType.StoredProcedure,
                            transaction: tx
                            );
                    }

                    //throw new Exception("ERROR");

                    //Confirmando la transacciòn
                    tx.Commit();

                    result = alumnoID;
                }
                catch (Exception ex)
                {
                    result = 0;
                    //Deshacer la transacciòn
                    tx.Rollback();
                }


            }


            return result;

        }


        

    }
}
