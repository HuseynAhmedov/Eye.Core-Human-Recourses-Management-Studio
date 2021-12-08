let dropBox = document.getElementById('DropBox');
let listItem = document.querySelectorAll('#ListMain li')
let listMain = document.getElementById('ListMain')
let dropList = document.getElementById('DropList')
let closeBtn = document.getElementsByClassName('close')

dropBox.ondragover = (ev)=>ev.preventDefault();

dropList.addEventListener('drop',function(ev)
{
    let order = ev.dataTransfer.getData('dataOrder');
    let elem = document.createElement("LI");
    elem.setAttribute('data-order',order)
    let textCopy = document.querySelector('#ListMain [data-order="'+order+'"]').textContent
    elem.textContent = textCopy
    //------------------------
    let newCloseBtn = document.createElement('SPAN')
    newCloseBtn.textContent = "x"
    newCloseBtn.classList.add('close')
    newCloseBtn.addEventListener('click',closeListBtnDropList)
    //------------------------
    elem.appendChild(newCloseBtn)
    ev.target.appendChild(elem)
})

for (let index = 0; index < listItem.length; index++) 
{
    listItem[index].addEventListener('dragstart',function (ev) 
    {
        console.log(ev)
        ev.dataTransfer.setData('dataOrder',this.getAttribute('data-order'));
    })
}


for (let index = 0; index < closeBtn.length; index++) 
{
    closeBtn[index].addEventListener('click',closeListBtnMainList)      
}

function closeListBtnDropList() 
{
    var closeOrder = this.parentElement.getAttribute('data-order')
    let listMainChildArr = Array.from(listMain.children)
    var item = listMainChildArr.filter(x=> x.getAttribute('data-order') == closeOrder)
    this.parentElement.style.display = "none"
    item[0].style.display = "none"

}

function closeListBtnMainList() 
{
    var closeOrder = this.parentElement.getAttribute('data-order')
    let DropListChildArr = Array.from(dropList.children)
    var itemArr = DropListChildArr.filter(x=> x.getAttribute('data-order') == closeOrder)
    this.parentElement.style.display = "none"
    itemArr.forEach(element => 
    {
        element.style.display = "none"
    });
}
