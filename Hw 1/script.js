let imageBox = document.getElementById('ImageDrop')
let textBox = document.getElementById('TextDrop')
let replaceText = document.getElementById('replaceText')

window.addEventListener('drop',function(ev) 
{
    ev.preventDefault()
    imageBox.innerHTML='';
    LoadFile(ev.dataTransfer.files)
})

function LoadFile (params) 
{
    [...params].forEach(file=>
    {

        if(file.type == 'image/jpeg' || file.type == 'image/png')
        {
            let reader = new FileReader();

            reader.onloadend = function(ev)
            {
                let img = document.createElement('img');
                img.setAttribute('src',reader.result);
                img.className='image-item'
    
                imageBox.appendChild(img)
            }

            reader.readAsDataURL(file)
        }
        else if (file.type == 'text/plain')
        {
            let reader = new FileReader();

            reader.onloadend = function(ev)
            {
                replaceText.innerText = reader.result;
            }
            reader.readAsText(file)
        }
        else
        {
            alert(file.type + " cannot be loaded")
        }
    })
}

window.addEventListener('dragover',function (ev) 
{
    ev.preventDefault()
})