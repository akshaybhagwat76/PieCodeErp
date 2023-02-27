$(document).ready(function () {
    $("#lblError").removeClass("success").removeClass("error").text('');

    $("#btn-submit").on("click", function () {
        debugger
        $("#lblError").removeClass("success").removeClass("error").text('');
        var retval = true;
        $("#myForm .required").each(function () {
            if (!$(this).val()) {
                $(this).addClass("error");
                retval = false;
            }
            else {
                $(this).removeClass("error");
            }
        });

        if (retval) {
            var data = {
                id: $("#Id").val().trim(),
                BranchName: $("#BranchName").val().trim(),
                BranchCode: $("#BranchCode").val().trim(),
            }
            //StartProcess();
            $.ajax({
                type: "POST",
                url: "/Branch/AddOrUpdateBranch",
                data: { BranchVM: data },
                success: function (data) {
                    if (!data.isSuccess) {
                        //StopProcess();
                        $("#lblError").addClass("error").text(data.errors.map(c => c.errorDescription).toString()).show();
                    }
                    else {
                        window.location.href = '/Branch/Index'
                    }
                }
            });
        }
    })
});
$(document).ready(function () {
});
$("#myTable").on("click", "a.btn-delete", function () {
    var id = $(this).data('id');
    $('#deleteModal').data('id', id).modal('show');
    $('#deleteModal').modal('show');
});
$('#delete-btn').click(function () {
    var id = $('#deleteModal').data('id');
    $.ajax({
        type: "POST",
        url: "/Categories/Delete",
        data: { id: id },
        success: function (response) {
            if (response.status != "Fail") {
                $('#deleteModal').modal('hide');
                location.reload();
            }
            else {
                $('#deleteModal').modal('hide');
                funToastr(false, response.error);
            }
        },
        error: function (error) {
            toastr.error(error)
        }
    });
});