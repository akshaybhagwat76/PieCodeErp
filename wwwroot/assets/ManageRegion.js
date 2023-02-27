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
                RegionName: $("#RegionName").val().trim(),
                RegionCode: $("#RegionCode").val().trim(),
            }
            //StartProcess();
            $.ajax({
                type: "POST",
                url: "/Region/AddOrUpdateRegion",
                data: { regionVM: data },
                success: function (data) {
                    if (!data.isSuccess) {
                        //StopProcess();
                        $("#lblError").addClass("error").text(data.errors.map(c => c.errorDescription).toString()).show();
                    }
                    else {
                        window.location.href = '/Region/Index'
                    }
                }
            });
        }
    })
});
