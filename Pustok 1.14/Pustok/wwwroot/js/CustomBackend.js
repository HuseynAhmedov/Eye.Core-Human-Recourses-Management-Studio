let basketBtn = Array.from(document.getElementsByClassName("add-to-cart-btn"))
let basketMain = document.getElementById("basketMain")
let basketCountCon = document.querySelector(".cart-total span")
let totalPayCon = document.querySelector("span.price")
let closeBtn = ""
let toasterMain = document.getElementById("ToasterMain")

fetch(`shop/showbasket`)
    .then(Response => Response.json())
    .then(data => BuildBasket(data.basketItems))

basketBtn.forEach(function (ev)
{
    ev.addEventListener("click", function (ev)
    {
        ev.preventDefault()
        let productID = $(this).attr("data-id");

        fetch(`shop/addtobasket/${productID}`)
            .then(Response => Response.json())
            .then(data => BuildBasket(data.basketItems))
    })
})


function BuildBasket(data)
{
    console.log(data)
      basketMain.innerHTML = ""
      var totalPay = 0
      let elem = ""
                for (var i = 0; i < data.length; i++)
                {
                    var totalPriceItem = data[i].product.price * data[i].count
                    totalPay += totalPriceItem
                    elem = `<div class="cart-product">
                                                    <a href="product-details.html" class="image">
                                                        <img src="./image/products/cart-product-1.jpg" alt="">
                                                    </a>
                                                    <div class="content">
                                                        <h3 class="title">
                                                            <a href="product-details.html">${data[i].product.title}</a>
                                                        </h3>
                                                        <p class="price"><span class="qty">${data[i].count} ×</span> £ ${totalPriceItem}</p>
                                                        <button class="cross-btn" data-id = "${data[i].product.id}"><i class="fas fa-times"></i></button>
                                                    </div>
                                                </div>`
                    basketMain.innerHTML += elem
                }
    basketCountCon.innerHTML = data.length
    totalPayCon.innerHTML = "£" + totalPay

    closeBtn = Array.from(document.getElementsByClassName("cross-btn"))
    if (closeBtn != null)
    {
        closeBtn.forEach(function (ev)
        {
            ev.addEventListener("click", function (ev)
            {
                console.log("delete")
                let deleteID = $(this).attr("data-id");
                fetch(`shop/deletebasket/${deleteID}`)
                    .then(Response => Response.json())
                    .then(data => BuildBasket(data.basketItems))
            })
        })
    }
}


var connection = new signalR.HubConnectionBuilder().withUrl("/SignalRPustok").withAutomaticReconnect().build();
connection.start().then(function () {
    console.log(connection.connectionId)
})
connection.on("CommentAccepted", function () {
    if ($("#toaster-success").length) {
        toastr["success"]("Your Comment has been confirmed")
    }
})
connection.on("OnlineStatus", function (onlineStatus, userName) {
    console.log("test")
    console.log(onlineStatus);
    console.log(userName);
})
console.log(connection)

toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}
$(document).ready(function () {
    if ($("#toaster-error").length) {
        console.log($("#toaster-error"))
        toastr["error"]($("#toaster-error").val())
    }
    if ($("#toaster-success").length) {
        console.log($("#toaster-success"))
        toastr["success"]($("#toaster-success").val())
    }
})


