function deleteProduct(ProductId) {
    let result = confirm("Are you sure you want to delete?");
    if (result) {
        $.ajax({
            type: "get",
            url: '/ProductMvc/DeleteProduct?id=' + ProductId,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                if (response.success == true) {
                    location.reload();
                }
                else {
                    alert(response.message);
                }
            },
            error: function () {
                alert("error");
            }
        });
    }
}


//<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/v/dt/dt-1.12.1/datatables.min.css" />

// type="text/javascript" src="https://cdn.datatables.net/v/dt/dt-1.12.1/datatables.min.js"


//$(document).ready(function () {
//    $("#dataTable").DataTable();
//})