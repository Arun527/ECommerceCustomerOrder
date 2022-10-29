function deleteorder(OrderId) {
    let result = confirm("Are you sure you want to delete?");
    if (result) {
        $.ajax({
            type: "get",
            url: '/OrderMvc/Delete?id=' + OrderId,
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