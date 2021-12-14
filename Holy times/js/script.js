let todaysDateText = document.getElementsByClassName('todays-date-text')
let prayerDateList = Array.from(document.querySelectorAll('.prayer-time-text'))
let prayerMonthCon = document.getElementById('MonthMainList')

let dayNow = ""
let monthNow = ""
let yearNow = ""
let dateFullNow = ""
let prayerTimePullList = ""
let prayerMonthPullList = ""

fetch('http://worldclockapi.com/api/json/utc/now')
.then(result=>result.json())
.then(data=> todaysDateText[0].innerHTML = data.currentDateTime.substring(0,10))
.then(data=> dateFullNow = data)
.then(function ()
{
    yearNow = dateFullNow.slice(0,4)
    monthNow = dateFullNow.slice(5,7)
    dayNow = dateFullNow.slice(8,10)
    var requestStr = 'http://api.aladhan.com/v1/calendar?latitude=40.409264&longitude=49.867092&method=2&month='+monthNow +'&year='+yearNow  
    fetch(requestStr)
    .then(result=>result.json())
    .then(result=>result.data.find(element => element.date.gregorian.date== dayNow+'-'+monthNow+'-'+yearNow))
    .then(data=> prayerTimePullList = data.timings)
    .then(function()
    {
        prayerDateList.forEach(ev=>
        {
            this.addEventListener('click',ev=> { ev.preventDefault() })
            ev.innerHTML = prayerTimePullList[ev.getAttribute('date-for')]
        })
    })
    fetch(requestStr)
    .then(result=>result.json())
    .then(data=>prayerMonthPullList = data)
    .then(function()
    {
        prayerMonthPullList.data.forEach(element => 
        {
            let dayCon = document.createElement('a')
            dayCon.setAttribute('href','#')
            dayCon.setAttribute('aria-current','true')
            dayCon.classList.add('list-group-item')
            dayCon.classList.add('list-group-item-action')
            dayCon.classList.add('month-day-con')        
            let card = `
            <div class="d-flex w-100 justify-content-between ">
            <h5 class="mb-1 month-day ">December ${element.date.gregorian.day}</h5>
            </div>
            <div class = prayer-times-con>
                <ul>
                  <li><span class = 'time-name'>Fajr</span><span class="mb-1 prayer-time-txt" date-for = 'Fajr'>${element.timings.Asr}</span></li>
                  <li><span class = 'time-name'>Sunrise</span><span class="mb-1 prayer-time-txt" date-for = 'Sunrise'>${element.timings.Sunrise}</span></li>
                  <li><span class = 'time-name'>Dhuhr</span><span class="mb-1 prayer-time-txt" date-for = 'Dhuhr'>${element.timings.Dhuhr}</span></li>
                  <li><span class = 'time-name'>Asr</span><span class="mb-1 prayer-time-txt" date-for = 'Asr'>${element.timings.Asr}</span></li>
                  <li><span class = 'time-name'>Sunset</span><span class="mb-1 prayer-time-txt" date-for = 'Sunset'>${element.timings.Sunset}</span></li>
                  <li><span class = 'time-name'>Maghrib</span><span class="mb-1 prayer-time-txt" date-for = 'Maghrib'>${element.timings.Maghrib}</span></li>
                  <li><span class = 'time-name'>Isha</span><span class="mb-1 prayer-time-txt" date-for = 'Isha'>${element.timings.Isha}</span></li>
                  <li><span class = 'time-name'>Imsak</span><span class="mb-1 prayer-time-txt" date-for = 'Imsak'>${element.timings.Imsak}</span></li>
                  <li><span class = 'time-name'>Midnight</span><span class="mb-1 prayer-time-txt" date-for = 'Midnight'>${element.timings.Midnight}</span></li>
                </ul>
            </div>`
            dayCon.innerHTML +=card
            prayerMonthCon.appendChild(dayCon)
        });
    })
})


