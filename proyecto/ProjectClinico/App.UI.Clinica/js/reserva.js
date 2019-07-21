$("[data-mask]").inputmask();

$("#btnBuscar").on('click', function (e) {
    e.preventDefault();

    var dni = $("#txtDNI").val();

    searchPacienteDni(dni);

});

function searchPacienteDni(dni) {

    var data = JSON.stringify({ dni: dni });
    $.ajax({
        type: "POST",
        url: "GestionarReservaCitas.aspx/BuscarPacienteDNI",
        data: data,
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            if (data.d == null) {
                alert('No exite el paciente con dni' + dni);
                limpiarDatosPaciente();
            } else {
                llenarDatosPaciente(data.d);
            }

        }
    });
}


function llenarDatosPaciente(obj) {
    $("#idPaciente").val(obj.idPaciente);
    $("#txtNombres").val(obj.nombres);
    $("#txtApellidos").val(obj.apPaterno + " " + obj.apMaterno);
    $("#txtTelefono").val(obj.telefono);
    $("#txtEdad").val(obj.edad);
    $("#txtSexo").val((obj.sexo == 'M') ? 'Masculino' : 'Femenino');
}

function limpiarDatosPaciente() {
    $("#idPaciente").val("0");
    $("#txtNombres").val("");
    $("#txtApellidos").val("");
    $("#txtTelefono").val("");
    $("#txtEdad").val("");
    $("#txtSexo").val("");
}