let sectorInput = document.getElementById("Sector")
let departmentInput = document.getElementById("Department")
let JobInput = document.getElementById("Job")
let JobPositionInput = document.getElementById("JobPosition")
let applyBtn = document.getElementById("ApplyBtn")
let imageInput = document.getElementById("ImageInput")

if (imageInput.value != ""){
    previewImage.src = URL.createObjectURL(imageInput.target.files[0]);
    previewImage.onload = function () {
        URL.revokeObjectURL(previewImage.src)
    }
}

imageInput.addEventListener("change", function (ev)
{
    console.log(imageInput.value)
    var previewImage = document.getElementById("PreviewImage")
    previewImage.src = URL.createObjectURL(ev.target.files[0]);
    previewImage.onload = function ()
    {
        URL.revokeObjectURL(previewImage.src)
    }
})

if (sectorInput.value == "") {
    departmentInput.setAttribute("disabled", "disabled");
    JobInput.setAttribute("disabled", "disabled");
    JobPositionInput.setAttribute("disabled", "disabled");
}
if (departmentInput.value == "") {
    JobPositionInput.setAttribute("disabled", "disabled");
    JobInput.setAttribute("disabled", "disabled");
}
if (JobInput.value == "") {
    JobPositionInput.setAttribute("disabled", "disabled");
}

sectorInput.addEventListener("change", function(ev)
{
    departmentInput.innerHTML = "";
    JobInput.innerHTML = "";
    JobPositionInput.innerHTML = "";
    departmentInput.setAttribute("disabled", "disabled");
    JobInput.setAttribute("disabled", "disabled");
    JobPositionInput.setAttribute("disabled", "disabled");
    renderDepartments()
})

departmentInput.addEventListener("change", function (ev) {
    JobInput.innerHTML = "";
    JobPositionInput.innerHTML = "";
    JobPositionInput.setAttribute("disabled", "disabled");
    JobInput.setAttribute("disabled", "disabled");
    renderJobs()
})

JobInput.addEventListener("change", function (ev) {
    JobPositionInput.innerHTML = "";
    JobPositionInput.setAttribute("disabled", "disabled");
    renderJobPositions()
})

async function getDepartments(sectorId) {
    let url = `GetDepartments/${sectorId}`;
    try {
        let res = await fetch(url);
        return await res.json();
    } catch (error) {
        return 404;
    }
}

async function getJobs(DepartmentId) {
    let url = `GetJobs/${DepartmentId}`;
    try {
        let res = await fetch(url);
        return await res.json();
    } catch (error) {
        return 404;
    }
}

async function getJobPositions(JobId) {
    let url = `GetJobPositions/${JobId}`;
    try {
        let res = await fetch(url);
        return await res.json();
    } catch (error) {
        return 404;
    }
}

async function renderDepartments() {
    let departments = await getDepartments(sectorInput.value);
    if (departments == 404) {
        departmentInput.innerHTML = "";
        departmentInput.innerHTML = `<option value="">No departments found</option>`
        departmentInput.setAttribute("disabled", "disabled");
    }
    else
    {
        departmentInput.removeAttribute("disabled");
        departmentInput.innerHTML = "";
        departmentInput.innerHTML += `<option value="">Select department...</option>`;
        for (var i = 0; i < departments.length; i++){
            departmentInput.innerHTML += `<option value="${departments[i].id}">${departments[i].name}</option>` ;
        }
    }
}

async function renderJobs() {
    let Jobs = await getJobs(departmentInput.value);
    if (Jobs == 404) {
        JobInput.innerHTML = "";
        JobInput.innerHTML = `<option value="">No Jobs found</option>`
        JobInput.setAttribute("disabled", "disabled");
    }
    else {
        JobInput.removeAttribute("disabled");
        JobInput.innerHTML = "";
        JobInput.innerHTML += `<option value="">Select Job...</option>`;
        for (var i = 0; i < Jobs.length; i++) {
            JobInput.innerHTML += `<option value="${Jobs[i].id}">${Jobs[i].name}</option>`;
        }
    }
}

async function renderJobPositions() {
    let JobPosition = await getJobPositions(JobInput.value);
    if (JobPosition == 404) {
        JobPositionInput.innerHTML = "";
        JobPositionInput.innerHTML = `<option value="">No Job Position found</option>`
        JobPositionInput.setAttribute("disabled", "disabled");
    }
    else {
        JobPositionInput.removeAttribute("disabled");
        JobPositionInput.innerHTML = "";
        JobPositionInput.innerHTML += `<option value="">Select Job...</option>`;
        for (var i = 0; i < JobPosition.length; i++) {
            JobPositionInput.innerHTML += `<option value="${JobPosition[i].id}">${JobPosition[i].position.name}</option>`;
        }
    }
}