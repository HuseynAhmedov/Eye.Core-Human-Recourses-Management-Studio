let checkboxAttendanceArr = Array.from(document.getElementsByClassName("checkbox-attendance"))
let attendanceCountCon = document.querySelector(".attendance-count")
let tableCon = document.getElementsByClassName("table-con")
let sidebarAtt = document.getElementById("Sidebar")
let shortcutAtt = document.getElementById("Shortcut")
let sidebarCloseBtnAtt = document.getElementById("sidebarClose")

console.log(tableCon[0].style)
sidebarCloseBtnAtt.addEventListener("click",function(ev)
{
    ev.preventDefault()
    if(sidebarCloseBtnAtt.classList.contains("fa-expand"))
    {
        tableCon[0].style.maxWidth = "none";
    }
    else if(sidebarCloseBtnAtt.classList.contains("fa-grip-lines-vertical"))
    {
        tableCon[0].style.maxWidth = "92rem";
    }
})