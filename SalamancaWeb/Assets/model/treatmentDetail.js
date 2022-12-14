$(document).ready(function () {
    function resetModal() {
        window.document.querySelector("#modalTreatmentDetailContenido").innerHTML = '';
    }

    function openModal(vista, id) {
        if (id > 0) {
            $("#modalTreatmentDetailContenido").load("/TreatmentDetail/" + vista + "/" + id);
        } else {
            $("#modalTreatmentDetailContenido").load("/TreatmentDetail/" + vista + "/");
        }
    }

    $("#btnAddTreatmentDetail").click(function (eve) {
        resetModal();
        openModal("AddEdit");
    });

    $(".btnDetailTreatmentDetail").click(function (eve) {
        resetModal();
        openModal("Detail", $(this).data("id"))
    });

    $(".btnEditTreatmentDetail").click(function (eve) {
        resetModal();
        openModal("AddEdit", $(this).data("id"))
    });

    $(".btnDeleteTreatmentDetail").click(function (eve) {
        resetModal();
        openModal("Delete", $(this).data("id"))
    });

    $(document).on('show.bs.modal', '#modalTreatmentDetail', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var modalTitle = button.data('title') // Extract info from data-* attributes
        // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
        // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
        var modal = $(this)
        modal.find('.modal-title').text(modalTitle)
    })
});