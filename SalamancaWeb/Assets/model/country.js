$(document).ready(function () {
    function resetModal() {
        window.document.querySelector("#modalCountryContenido").innerHTML = '';
    }

    function openModal(vista, id) {
        if (id > 0) {
            $("#modalCountryContenido").load("/Country/" + vista + "/" + id);
        } else {
            $("#modalCountryContenido").load("/Country/" + vista + "/");
        }
    }

    $("#btnAddCountry").click(function (eve) {
        resetModal();
        openModal("AddEdit");
    });

    $(".btnDetailCountry").click(function (eve) {
        resetModal();
        openModal("Detail", $(this).data("id"))
    });

    $(".btnEditCountry").click(function (eve) {
        resetModal();
        openModal("AddEdit", $(this).data("id"))
    });

    $(".btnDeleteCountry").click(function (eve) {
        resetModal();
        openModal("Delete", $(this).data("id"))
    });

    $(document).on('show.bs.modal', '#modalCountry', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var modalTitle = button.data('title') // Extract info from data-* attributes
        // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
        // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
        var modal = $(this)
        modal.find('.modal-title').text(modalTitle)
    })
});