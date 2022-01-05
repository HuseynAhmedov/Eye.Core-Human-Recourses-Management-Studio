let navbarBrand = document.querySelector(".navbar-brand")
let navbarLinks = Array.from(document.getElementsByClassName("nav-link")) 
console.log(window.scrollY)

navbarBrand.addEventListener('click',function(ev)
{
    ev.preventDefault()

    window.scroll(0 , 206)

})

navbarLinks.forEach(function(ev)
{
    ev.addEventListener('click',function(ev)
    {
        
        navbarLinks.forEach(function(ev)
        {
            if(ev.classList.contains("active"))
            {
                ev.classList.remove("active")
            }
        })
        ev.target.classList.add("active")
    })
})

window.addEventListener('scroll',function(ev)
{
    navbarLinks.forEach(function(ev)
    {
        if(ev.classList.contains("active"))
        {
            ev.classList.remove("active")
        }
    })
    if(window.scrollY > 531 && window.scrollY < 1331)
    {
       let portfolioLink =  navbarLinks.find(x=> x.getAttribute("href") == "#PortfolioCards")
       portfolioLink.classList.add("active")
    }
    if(window.scrollY > 1332 && window.scrollY < 2013)
    {
        let aboutLink =  navbarLinks.find(x=> x.getAttribute("href") == "#About")
        aboutLink.classList.add("active")
    }
    if(window.scrollY > 2014 && window.scrollY < 2640)
    {
        let ContactMeLink =  navbarLinks.find(x=> x.getAttribute("href") == "#ContactMe")
        ContactMeLink.classList.add("active")
    }
})


$(document).on("click", ".fa-plus", function () {

    let id = $(this).attr("data-id");

    fetch(`/home/modal/${id}`)
        .then(response => response.text())
        .then(data => {
            console.log(data)
            $("#detailModal .modal-content").html(data)
        })



    $("#detailModal").modal("show")
})

const forms = document.querySelectorAll('.needs-validation');

Array.prototype.slice.call(forms).forEach((form) => {
    form.addEventListener('submit', (event) => {
        if (!form.checkValidity()) {
            event.preventDefault();
            event.stopPropagation();
        }
        form.classList.add('was-validated');
    }, false);
});