var table;
$("document").ready(function () {
    loadAllDepartments();

    // Display a success toast, with a title
    //Toast.fire({
    //    icon: 'success',
    //    title: 'Your Level is 3.'
    //})
})
$("#datatable-basic").on("click", "a#btn-delete", function () {
    var id = $(this).data('id');
    $('#deleteModal').data('id', id).modal('show');
    $('#deleteModal').modal('show');
});
$('#delete-btn').click(function () {
    var id = $('#deleteModal').data('id');
    $.ajax({
        type: "GET",
        url: "/Department/DeleteDepartment",
        data: { id: id },
        success: function (response) {
            if (!response.isSuccess) {
                $('#deleteModal').modal('hide');
            }
            else {
                $('#deleteModal').modal('hide');
                table.ajax.reload()
                funToastr(true, response.message);
            }
        },
        error: function (error) {
            //toastr.error(error)
        }
    });
});


function loadAllDepartments() {
    var url = "/Department/GetAllDepartment"
    table = $("#datatable-basic").DataTable({

        "searching": true,
        "serverSide": true,
        "bFilter": true,
        "orderMulti": false,
        "ajax": {
            url: url,
            type: "POST",
            datatype: "json"
        },
        
        "columns": [
            {
                "data": "departmentName"
            },
            {
                "data": "departmentCode"
            },
            {
                "render": function (data, type, full, meta) {
                    return ` <a href="/Department/Edit/` + full.departmentId + `" data-id="` + full.departmentId + `" class="btn btn-success btn-sm" title="Edit">
                                    <i class="fa fa-edit"></i>
                             </a>
                             <a href="javascript:void(0)" id="btn-delete" data-id="`+ full.departmentId + `" class="btn btn-danger btn-sm" title="Delete">
                                    <i class="fa fa-trash"></i>
                             </a>`;
                }
            }

        ],
        
    });
   
}

