
// Para mostrar el nombre del archivo seleccionado



$(document).ready(function () {
    $('#addContact').submit(function (event) {
        event.preventDefault();

        var currentUrl = window.location.href;
        var actionUrl = currentUrl.substring(0, currentUrl.lastIndexOf('/')) + '/addContact';

        $.ajax({
            type: 'POST',
            url: actionUrl,
            data: { contactNum: $('#contactNum').val() },
            success: function (result) {
                console.log('Contacto agregado');
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    });
});

$(document).ready(function () {
    var currentUrl = window.location.href;
    var actionUrl = currentUrl.substring(0, currentUrl.lastIndexOf('/')) + '/GetContactData';
    $('#ContactsList').on('click', function () {
        $.ajax({
            url: actionUrl,
            type: 'GET',
            success: function (result) {
                $('#contact-body').html(result);
            }
        });
    });
});

$(document).ready(function () {
    $('#ContactList').submit(function (event) {
        event.preventDefault();
        var currentUrl = window.location.href;
        var actionUrl = currentUrl.substring(0, currentUrl.lastIndexOf('/')) + '/removeContact';

        // Recoger los valores seleccionados de los checkboxes en un array
        var selectedContacts = [];
        $('input[name="contactsNumSelected"]:checked').each(function () {
            selectedContacts.push($(this).val());
        });

        $.ajax({
            type: 'POST',
            url: actionUrl,
            data: { selectedContacts: selectedContacts },
            success: function (result) {
                console.log('Contactos eliminados');
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    });
});

