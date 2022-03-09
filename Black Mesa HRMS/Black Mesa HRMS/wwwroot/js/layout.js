//initClock();
let sidebarCloseBtn = document.getElementById("sidebarClose")
let sidebar = document.getElementById("Sidebar")
let shortcut = document.getElementById("Shortcut")
let accordionBtn = Array.from(document.getElementsByClassName("accordion-button"))
let notificationBtn = document.getElementsByClassName("notification-btn")
let notificationTab = document.getElementsByClassName("notification-tab")
let loadingView = document.getElementById("LoadingBarMain")


function setVisible(selector, visible) {
    document.querySelector(selector).style.display = visible ? 'flex' : 'none';
}

window.addEventListener("load", function () {
    setVisible('#LoadingBarMain', false);
    setVisible('main', true);
    setVisible('header', true);
})

notificationBtn[0].addEventListener("click",function(ev)
{
    notificationTab[0].classList.toggle("notification-tab-hidden")
})

sidebarCloseBtn.addEventListener("click",function(ev)
{
    ev.preventDefault()
    if(sidebarCloseBtn.classList.contains("fa-expand"))
    {
        sidebar.classList.add("sidebar-hidden");
        shortcut.classList.add("sidebar-hidden");
        sidebarCloseBtn.classList.remove("fa-expand");
        sidebarCloseBtn.classList.add("fa-bars");
    }
    else if(sidebarCloseBtn.classList.contains("fa-grip-lines-vertical"))
    {
        sidebar.classList.add("sidebar-hidden");
        shortcut.classList.remove("sidebar-hidden");
        sidebarCloseBtn.classList.remove("fa-grip-lines-vertical");
        sidebarCloseBtn.classList.add("fa-expand");
    }
    else if(sidebarCloseBtn.classList.contains("fa-bars"))
    {
        sidebar.classList.remove("sidebar-hidden");
        shortcut.classList.remove("sidebar-hidden");
        sidebarCloseBtn.classList.remove("fa-bars");
        sidebarCloseBtn.classList.add("fa-grip-lines-vertical");
    }
})