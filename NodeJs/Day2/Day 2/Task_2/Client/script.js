document.getElementById("getAll").addEventListener("click", ()=>{
    var myData = getData("/client.json");
});

async function getData(url){
    var response = await fetch(url);
    var data = await response.json();
    // var parseData = data;
    // console.log(parseData);
    var mybody = document.getElementById("body");
        
        for(var i=0;i<data.length;i++)
        {
            mybody.innerHTML += 
            `<tr> 
                <th scope="row"> ${data[i].clientName} </th>
                <td> ${data[i].mobileNum} </td>
                <td> ${data[i].address} </td>
                <td> ${data[i].email} </td>
            </tr>`
        }

}
