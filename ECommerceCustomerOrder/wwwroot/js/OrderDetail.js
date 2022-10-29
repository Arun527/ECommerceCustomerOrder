

$(document).ready(function () {
    $('#btnsubmit').click(function (e) {
        e.preventDefault();


        var customerId = $('#CustomerId option:selected').val();
        debugger;
        if (customerId == null || customerId == 0) {
            $('#errormsg').html("customer is required");
            return;
        }
        if (productDetails == null || productDetails.length == 0) {
            $('#errormsg').html("product and quanity is required");
            return;
        }

        var request = {
            "CustomerId": customerId,
            "Products": productDetails

        };
        debugger;
        $.ajax({

            url: "/OrderDetailMvc/AddOrder",
            type: "POST",
            dataType: 'json',
            data: JSON.stringify(request),
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
              
                alert(response.message);
                setTimeout(function () { window.location = '/OrderDetailMvc/Invoice'; }, 1000);
              
            },
            error: function () {
                alert("error");
            }

        });

    });
    var productDetails = [];
    var obj;
    $("#showProduct").click(function () {
        $('#errormsg').html("");
        debugger;
        var customerId = $('#CustomerId option:selected').val();
        var customerName = $('#CustomerId :selected').text();
        var productId = $('#ProductId :selected').val();
        var productName = $('#ProductId option:selected').text();
        var quantity = $("#Quantity").val();
   
        if (customerId == null || customerId == 0) {
            $('#errormsg').html("Customer is required");
            return;
        }
        if (productId == null || productId == 0) {
            $('#errormsg').html("Product is required");
            return;
        }
        if (quantity == '' || quantity == '0') {
            $('#errormsg').html("Quantity is required");
            return;
        }

        $('#productList').append('<tr><td>' + productName + '</td><td>' + quantity + '</td><td><button class="btn btn-danger delete">Delete </button></td></tr>');




        obj = { "ProductId": productId, "Quantity": quantity }

        productDetails.push(obj);

        if (productDetails.length > 0) {
            $('#productList').show();
        }
       
        $("#ProductId").val('0');

        $("#Quantity").val('0');
    });

    $(document).on('click', '.delete', function () {
        let index = $(this).closest('tr').index()- 1;
        $(this).closest('tr').remove();
        console.log(index);
        productDetails.splice(index, 1);
        console.log(productDetails);
        if (productDetails.length == 0) {
            $('#productList').hide();
        }
    });

});   
function deleteOrder() {
alert("Are you sure want to delete this");
}
