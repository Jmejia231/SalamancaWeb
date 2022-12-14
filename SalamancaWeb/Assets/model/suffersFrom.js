﻿$(document).ready(function () {
    function resetModal() {
        window.document.querySelector("#modalSuffersFromContenido").innerHTML = '';
    }

    function openModal(vista, id) {
        if (id > 0) {
            $("#modalSuffersFromContenido").load("/SuffersFrom/" + vista + "/" + id);
        } else {
            $("#modalSuffersFromContenido").load("/SuffersFrom/" + vista + "/");
        }
    }

    $("#btnAddSuffersFrom").click(function (eve) {
        resetModal();
        openModal("AddEdit");
    });

    $(".btnDetailSuffersFrom").click(function (eve) {
        resetModal();
        openModal("Detail", $(this).data("id"))
    });

    $(".btnEditSuffersFrom").click(function (eve) {
        resetModal();
        openModal("AddEdit", $(this).data("id"))
    });

    $(".btnDeleteSuffersFrom").click(function (eve) {
        resetModal();
        openModal("Delete", $(this).data("id"))
    });

    $(document).on('show.bs.modal', '#modalSuffersFrom', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var modalTitle = button.data('title') // Extract info from data-* attributes
        // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
        // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
        var modal = $(this)
        modal.find('.modal-title').text(modalTitle)
    })
});