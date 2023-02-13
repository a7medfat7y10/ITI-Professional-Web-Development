let result = fetch("https://jsonplaceholder.typicode.com/users");

let myjson = result.then(res =>res.json());

myjson.then(data => {
    var mybody = document.getElementById("body");
    
    for(var i=0;i<data.length;i++)
    {
        mybody.innerHTML += 
        `<tr> 
            <th scope="row">${data[i].id}</th>
            <td>${data[i].name}</td>
            <td>${data[i].username}</td>
            <td>${data[i].email}</td>
        </tr>`
    }
})