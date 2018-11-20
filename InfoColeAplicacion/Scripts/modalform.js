$(document).ready(function () {
    $.ajaxSetup({ cache: false });
    // busca los elementos el atributo data-modal y le suscribe el evento click
    $('a[data-modal]').on('click', function (e) {
        // Abre la ventana modal con el formulario solicitado 
        openmodal(this.href);
        return false;
    });
    $('#modalGenerica').on('hidden.bs.modal', function () {
        $('#contentModal').html('');
    })
});
function openmodal(url) {
    // Hace una petición get y carga el formulario en la ventana modal
    $('#contentModal').load(url, function () {
        $('#modalGenerica').modal({
            keyboard: true
        }, 'show');
        // Suscribe el evento submit
        bindForm(this);
    });
}
function bindForm(dialog) {
    // Suscribe el formulario en la ventana modal con el evento submit
    $('form', dialog).submit(function () {
        
            // Realiza una petición ajax
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    if (result.success) {
                        $("#modalGenerica").modal('hide');
                        toastr.success("Comentario guardado con exito.");
                        location.reload();
                    }
                    else {
                        $("#modalGenerica").modal('show');
                        toastr.error(result.ErrorMessage);
                    }
                },
                error: function (xml, message, text) {
                    toastr.error("Error: Campos vacios. Por favor complete todos los campos.");
                }
            });
            return false;
    });
}

