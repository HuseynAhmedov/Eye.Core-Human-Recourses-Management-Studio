let basketBtn = Array.from(document.getElementsByClassName("add-to-cart-btn"))
let basketMain = document.getElementById("basketMain")
let basketCountCon = document.querySelector(".cart-total span")
let totalPayCon = document.querySelector("span.price")
let closeBtn = ""

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
