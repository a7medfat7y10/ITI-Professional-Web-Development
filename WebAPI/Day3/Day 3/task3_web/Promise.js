let tbodyRef = document.getElementById('myTable').getElementsByTagName('tbody')[0];
let AddBtn = document.getElementById('AddBtn');
AddBtn.addEventListener("click", addBtn);
start();

function start() {
    fetch('https://localhost:7262/api/Departments').then((Departments => {
        return Departments.json();
    })).then(Departments => {
        let rowCounter = 1;
        for (let dept of Departments) {
            const newRow = tbodyRef.insertRow();//create new row
            newRow.id = "r" + rowCounter;

            const idCell = newRow.insertCell();//create new cells in the created row
            const nameCell = newRow.insertCell();
            const locationCell = newRow.insertCell();
            const descriptionCell = newRow.insertCell();
            const deleteCell = newRow.insertCell();
            const updateCell = newRow.insertCell();

            const id = document.createTextNode(dept.id);//create text node
            const name = document.createTextNode(dept.name);
            const location = document.createTextNode(dept.location);
            const description = document.createTextNode(dept.description);
            let BtnDelete = document.createElement("button");
            BtnDelete.innerHTML = "Delete";
            BtnDelete.value = dept.id;
            BtnDelete.rowNum = "r" + rowCounter;
            BtnDelete.classList.add('btn', 'btn-danger');
            BtnDelete.addEventListener("click", deleteBtn);
            let BtnUpdate = document.createElement("button");
            BtnUpdate.innerHTML = "Update";
            BtnUpdate.value = dept.id;
            BtnUpdate.classList.add('btn', 'btn-primary');

            idCell.appendChild(id);//append the text node to the cell
            nameCell.appendChild(name);
            locationCell.appendChild(location);
            descriptionCell.appendChild(description);
            deleteCell.appendChild(BtnDelete);
            updateCell.appendChild(BtnUpdate);
            rowCounter++;
        }
    });
}

function deleteBtn() {
    fetch('https://localhost:7262/api/Departments/' + this.value,
        {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            },
            body: null
        })
        .then(res => {
            let row = document.getElementById(this.rowNum);
            row.parentNode.removeChild(row);
        })
        .catch((error) => {
            Alert("Error:", error);
        });
}

function addBtn() {
    location.href = "add.html";
}