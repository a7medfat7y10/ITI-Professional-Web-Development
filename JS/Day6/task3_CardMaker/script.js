var img;
var personal_message;
var win;
var new_img;
var new_paragraph;
var new_button;

document.getElementById("generate").onclick = function (e)
{
    e.preventDefault();
    for(var i=0; i<6;i++)
    {
        if(document.getElementsByName("design_img")[i].checked)
        {
            img = document.getElementsByName("design_img")[i].previousElementSibling.firstChild.getAttribute("src");
        }
    }

    personal_message = document.getElementById("personal_msg").value;
    
    openwin();
};

function openwin()
{
    win = open("preview.html", "", "width=1000,height=1000");
    
    win.onload = function(){
        new_img = document.createElement("img");
        new_img.setAttribute("src", img);
        new_img.style.width = "550px";
        new_img.style.paddingLeft = "225px";
        win.document.body.appendChild(new_img);


        new_paragraph = document.createElement("p");
        new_paragraph.style.textAlign = "center";
        new_paragraph.innerText = personal_message;
        new_paragraph.style.color = "#7b7bd5";
        new_paragraph.style.fontSize = "30px";
        win.document.body.appendChild(new_paragraph);
        
        new_button = document.createElement("input");
        new_button.setAttribute("type", "button");
        new_button.setAttribute("id", "close_preview");
        new_button.setAttribute("value", "Close Preview");
        new_button.style.display = "block";
        new_button.style.margin = "auto";
        new_button.onclick = winclose;
        win.document.body.appendChild(new_button);
    }
}

function winclose ()
{
    win.close();
}
