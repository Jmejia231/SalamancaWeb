$(document).ready(function () {
    function resetModal() {
        window.document.querySelector("#modalPersonContenido").innerHTML = '';
    }

    function openModal(vista, id) {
        if (id > 0) {
            $("#modalPersonContenido").load("/Person/" + vista + "/" + id);
        } else {
            $("#modalPersonContenido").load("/Person/" + vista + "/");
        }
    }

    $("#btnAddPerson").click(function (eve) {
        resetModal();
        openModal("AddEdit");
    });

    $(".btnDetailPerson").click(function (eve) {
        resetModal();
        openModal("Detail", $(this).data("id"))
    });

    $(".btnEditPerson").click(function (eve) {
        resetModal();
        openModal("AddEdit", $(this).data("id"))
    });

    $(".btnDeletePerson").click(function (eve) {
        resetModal();
        openModal("Delete", $(this).data("id"))
    });

    $(document).on('show.bs.modal', '#modalPerson', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var modalTitle = button.data('title') // Extract info from data-* attributes
        // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
        // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
        var modal = $(this)
        modal.find('.modal-title').text(modalTitle)
    })
});