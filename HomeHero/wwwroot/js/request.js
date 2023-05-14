document.addEventListener('DOMContentLoaded', function () {
    var fileInput = document.getElementById('fileID');
    if (fileInput != null) {
        var fileNameLabel = document.getElementById('fileNameLabel');
        fileInput.addEventListener('change', function () {
            var fileName = fileInput.files[0].name;
            fileNameLabel.innerText = fileName;
        });
    }
    var imageInput = document.getElementById('imageID');
    if (imageInput != null) {
        var imageNameLabel = document.getElementById('imageNameLabel');
        imageInput.addEventListener('change', function () {
            var fileName = imageInput.files[0].name;
            imageNameLabel.innerText = fileName;
        });
    }
    var payInput = document.getElementById('payID');
    if (payInput != null) {
        var payNameLabel = document.getElementById('payNameLabel');
        payInput.addEventListener('change', function () {
            var fileName = payInput.files[0].name;
            payNameLabel.innerText = fileName;
        });
    }

    $(".reqCard").click(function () {
        var requestSelected = $(this).data("id");
        console.log(requestSelected);
        $.ajax({
            type: "POST",
            url: "/Home/ReloadModal",
            data: { request: requestSelected },
            success: function (data) {
                console.log("solicitud guardada en el ViewBag");
                // Actualizar el contenido del modal con el nuevo valor de ViewBag.RequestSelected
                $('#request-body').html(data);
            }
        });
    });
});

