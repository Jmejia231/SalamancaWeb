$(document).ready(function () {
    function resetModal() {
        window.document.querySelector("#modalDocumentIdentityTypeContenido").innerHTML = '';
    }

    function openModal(vista, id) {
        if (id > 0) {
            $("#modalDocumentIdentityTypeContenido").load("/DocumentIdentityType/" + vista + "/" + id);
        } else {
            $("#modalDocumentIdentityTypeContenido").load("/DocumentIdentityType/" + vista + "/");
        }
    }

    $("#btnAddDocumentIdentityType").click(function (eve) {
        resetModal();
        openModal("AddEdit");
    });

    $(".btnDetailDocumentIdentityType").click(function (eve) {
        resetModal();
        openModal("Detail", $(this).data("id"))
    });

    $(".btnEditDocumentIdentityType").click(function (eve) {
        resetModal();
        openModal("AddEdit", $(this).data("id"))
    });

    $(".btnDeleteDocumentIdentityType").click(function (eve) {
        resetModal();
        openModal("Delete", $(this).data("id"))
    });

    $(document).on('show.bs.modal', '#modalDocumentIdentityType', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var modalTitle = button.data('title') // Extract info from data-* attributes
        // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
        // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
        var modal = $(this)
        modal.find('.modal-title').text(modalTitle)
    })
});