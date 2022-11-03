$(document).ready(function () {
    $('#Customerform').submit(function (e) {
        e.preventDefault();

        var valdata = $("#Customerform").serialize();
        $.ajax({
            url: "/CustomerMvc/AddCustomer",
            type: "POST",
            dataType: 'json',
            data: new FormData(Customerform),
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: valdata,
            success: function (response) {

                if (response.success == true) {
                    window.location.href = "/CustomerMvc/CustomerView";
                }
                else {
                    alert(response.message);
                    location.reload();
                }

            },
            error: function () {
                alert("error");
            }

        });

    });
});   

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
};


function detailCustomer(customerid) {

        window.location.href = '/CustomerMvc/CustomerDetailView?Id=' + customerid;

};

//function deleteOrder(InVoiceNo) {
//    let result = confirm("Are you sure you want to delete?");
//    if (result) {
//        $.ajax({
//            debugger;
//            type: "get",
//            url: '/OrderDetailMvc/DeleteOrderDetail?InVoiceNo=' + InVoiceNo,
//            contentType: 'application/json; charset=utf-8',
//            dataType: 'json',
//            success: function (response) {
//                if (response.success == true) {
//                    location.reload();
//                }
//                else {
//                    alert(response.message);
//                }
//            },
//            error: function () {
//                alert("error");
//            }
//        });
//    }
//}
