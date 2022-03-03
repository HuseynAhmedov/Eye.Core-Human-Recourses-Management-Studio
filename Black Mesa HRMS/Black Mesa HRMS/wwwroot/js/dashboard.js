let monthViewBtnSalary = document.getElementsByClassName("month-view-btn-ES")
let yearViewBtnSalary = document.getElementsByClassName("year-view-btn-ES")

monthViewBtnSalary[0].addEventListener("click",function(ev)
{
    monthViewBtnSalary[0].classList.toggle("active")
    yearViewBtnSalary[0].classList.remove("active")
})

yearViewBtnSalary[0].addEventListener("click",function(ev)
{
    yearViewBtnSalary[0].classList.toggle("active")
    monthViewBtnSalary[0].classList.remove("active")
})
