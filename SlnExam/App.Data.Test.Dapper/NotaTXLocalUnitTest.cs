using System;
using System.Collections.Generic;
using App.Entities;
using App.Entities.Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]
    public class NotaTXLocalUnitTest
    {
        [TestMethod]
        public void InsertTXlocal()
        {
            var alumnoDA = new AlumnoDADapper();
            var alumno = new Alumno();
            alumno.Nombres = "JOSE LUISs";
            alumno.Apellidos = "ARIZA";
            alumno.Direccion = "NOSE";
            alumno.Sexo = "M";
            alumno.FechaNacimiento = DateTime.Now;

            //Agregando los detalles
            alumno.notas = new List<Notas>();
            alumno.notas.Add(
                new Notas()
                {
                    AlumnoID = 2,
                    CursoID = 3,
                    Nota = 20
                }
        );
           

            var id = alumnoDA.InsertTXLocal(alumno);


            Assert.IsTrue(id > 0);
        }
    }
}
