let sidebarAtt = document.getElementById("Sidebar")
let shortcutAtt = document.getElementById("Shortcut")
let sidebarCloseBtnAtt = document.getElementById("sidebarClose")

document.addEventListener('DOMContentLoaded', function() {
  var calendarEl = document.getElementById('calendar');
  var calendar = new FullCalendar.Calendar(calendarEl, 
  {
    initialView: 'dayGridMonth',
    events: [
        { 
          title: 'The Title', 
          start: '2022-02-02', 
          end: '2022-02-05' 
        }
      ]
  });
  calendar.render();
});

var calendarEl = document.getElementById('calendar');
var calendar = new FullCalendar.Calendar(calendarEl)
sidebarCloseBtnAtt.addEventListener("click",function(ev)
{
    ev.preventDefault()
    if(sidebarCloseBtnAtt.classList.contains("fa-expand"))
    {
      calendar.updateSize()
    }
    else if(sidebarCloseBtnAtt.classList.contains("fa-grip-lines-vertical"))
    {
      calendar.updateSize()
    }
    else if(sidebarCloseBtnAtt.classList.contains("fa-bars"))
    {
      calendar.updateSize()
    }
})


    