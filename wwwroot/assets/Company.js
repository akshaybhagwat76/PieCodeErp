var table;
$("document").ready(function () {
    loadAllCompanys();
 
    // Display a success toast, with a title
    Toast.fire({
        icon: 'success',
        title: 'Your Level is 3.'
    })
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
        url: "/Company/DeleteCompany",
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


function loadAllCompanys() {
    var url = "/Company/GetAllCompanies"
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
        //"columnDefs": [
        //    { "width": "70px", "targets": 0 },
        //    { "width": "70px", "targets": 1 },
        //    { "width": "5px", "targets": 2 },
        //],
        "columns": [
            {
                "data": "CompanyName"
            },
            {
                "data": "CompanyCode"
            },
            {
                "render": function (data, type, full, meta) {
                    return ` <a href="/Company/Edit/` + full.CompanyId + `" data-id="` + full.CompanyId + `" class="btn btn-success btn-sm" title="Edit">
                                    <i class="fa fa-edit"></i>
                             </a>
                             <a href="javascript:void(0)" id="btn-delete" data-id="`+ full.CompanyId + `" class="btn btn-danger btn-sm" title="Delete">
                                    <i class="fa fa-trash"></i>
                             </a>`;
                }
            }

        ],
        //"order": [[3, 'desc']],
        //"dom": ' <"search"f><"top"l>rt<"bottom"ip><"clear">'
    });
    //$("#myTable_filter").css("float", "right");
}

