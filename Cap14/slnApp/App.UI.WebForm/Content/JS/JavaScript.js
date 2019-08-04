debugger;

var numero = 15;
var cadeno = "Hola Javascript";
var booleanTrue = true;
var booleanFalse = false;
var date = new Date();
var date2 = new Date(2017,01,15);
var alumno = {
    Nombre: "Juan",
    Apellidos: "Días",
    FechaNacimiento: "1980/05/04",
    GenerarNombreCompleto: function (genero) {
        var fullName = this.Nombre + " " + this.Apellidos; 
        debugger;
        if (genero = "M") {
            fullName = "Señor: " + fullName;
        }
        else {
            fullName = "Señora: " + fullName;
        }

        return fullName;
    }
};

//arreglo
var clase = [];
//agregando elementos a un areglo
clase.push(alumno);








function MostrarAlumno() {  
    //Mostrar Mensaje
    //alert("Es el alumno:" + alumno.GenerarNombreCompleto("M"));

    for (var i = 0; i < clase.length; i++) {
        alert("Es el alumno:" + clase[i].GenerarNombreCompleto());
    }


}