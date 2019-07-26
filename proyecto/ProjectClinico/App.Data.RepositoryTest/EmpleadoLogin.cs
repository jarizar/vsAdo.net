using System;
using App.Data.Repository;
using App.Entities.Base;
using App.Entities.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.RepositoryTest
{
    [TestClass]
    public class EmpleadoLogin
    {
        [TestMethod]
        public void Login()
        {
            //var result = 0;

            using (var uw = new AppUnitOfWork())
            {
                Paciente p = new Paciente();
                p.direccion = "bien";
                p.idPaciente = 30;

                var validar=uw.PacienteRepository.actualizarPaciente(p);


                Assert.IsTrue(validar);
            }

            //{

                //    var usuario = "jjrc";
                //    var clave = "admin";


                //   //result= uw.EmpleadoRepository.LoginEmpleado(usuario,clave).Count;               

                //}

                //Assert.IsTrue(result>0);
        }
    }
}
