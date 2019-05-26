using System;
using App.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]
    public class AlumnoTXLocalDATest
    {
        [TestMethod]
        public void InsertSP()
        {
            var da = new AlumnoTXLocalDA();
            var alumno = new Alumno();

            alumno.Nombres = "JOSE LUIS";
            alumno.Apellidos = "ARIZA";
            alumno.Direccion = "NOSE";
            alumno.Sexo = "M";
            alumno.FechaNacimiento = DateTime.Now;

            var id = da.Insert(alumno);

            Assert.IsTrue(id > 0, "El nombre del album ya existe");
        }

        [TestMethod]
        public void GetAllSP()
        {
            var da = new AlumnoTXLocalDA();

            var listado = da.GetAllSP("%");

            Assert.IsTrue(listado.Count > 0);
        }


    }
}
