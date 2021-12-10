let wishlistBtnList = Array.from(document.getElementsByClassName('btn-add-basket'))
let wishListCount = document.getElementById('BasketCount')

let localWishActiveBtn = JSON.parse(localStorage.getItem('wishItemID'))

wishListCount.innerText = JSON.parse(localStorage.getItem('BasketCount'))

let toActivateBtnList = []
localWishActiveBtn.forEach(element => 
{
    toActivateBtnList.push(wishlistBtnList.filter(x=> x.getAttribute('item-id') == element))
})

for (let index = 0; index < toActivateBtnList.length; index++) 
{
    console.log(toActivateBtnList[index])
    toActivateBtnList[index].classList.add('on-wishlist')
}

wishlistBtnList.forEach(element => 
{
   let itemOnWishList = element.getAttribute('item-id') 
   element.addEventListener('click',function(ev)
   {
       if(this.classList.contains('on-wishlist'))
       {
           this.classList.remove('on-wishlist')
       }
       else 
       {
           this.classList.add('on-wishlist')
       }

       let wishListBtnActive = wishlistBtnList.filter(x=> x.classList.contains('on-wishlist'))
       let wishItemID = wishListBtnActive.map(x=> x.getAttribute('item-id'))
       localStorage.setItem('wishItemID',JSON.stringify(wishItemID))

       //--------------------------------------------------------------

       wishListCount.innerText = wishListBtnActive.length;
       let basketCount = wishListCount.innerText
       localStorage.setItem('BasketCount',JSON.stringify(basketCount))
   }) 
});