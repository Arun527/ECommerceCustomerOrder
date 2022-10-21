function deleteCustomer(customerid) {
    let result = confirm("Are you sure you want to delete?");
    if (result) {
        $.ajax({
            type: "get",
            url: '/CustomerMvc/Delete?id=' + customerid,
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
