

    window.onload = function() {
        updateGrid();
    };

function changeNumber(id, value) {
    var item = JSON.parse(localStorage.getItem(id));
    localStorage.setItem(id,JSON.stringify({Id:id,Text:item.Text,Cost:item.Cost,Count:Number.parseInt(value)}));
    counting();
}


function updateGrid() {

    for (var i = 0; i < localStorage.length; i++) {
        var key = localStorage.key(i);
        var itemText = document.getElementById(`item+${key}`);
        var text = itemText.innerText.split(':')[1].trim();

        var item = JSON.parse(localStorage.getItem(key));
        if (item.Text !== text) {
            item.Text = text;
            item = JSON.stringify(item);
            localStorage.setItem(key,item);
        }
    }


    var grid = $("#grid").data("kendoGrid");
    var dataSource = grid.dataSource;
    var raw = dataSource.data();
    var length = raw.length;
    for (var i = 0; i < length; i++) {
        dataSource.remove(raw[0]);
    }
    for (var i = 0; i < localStorage.length; i++) {
        var item = JSON.parse(localStorage.getItem(localStorage.key(i)));
        dataSource.add({ Id: item.Id, Text: item.Text, Cost: item.Cost });
    }
    for (var i = 0; i < localStorage.length; i++) {
        var item = JSON.parse(localStorage.getItem(localStorage.key(i)));
        document.getElementById(item.Id).value = item.Count;
    }

}


function counting() {

    var totalCost = 0;
    for (var i = 0; i < localStorage.length; i++) {
        var id = localStorage.key(i);    
        var element = JSON.parse(localStorage.getItem(id));
        totalCost += element.Cost * element.Count;
    }
    document.getElementById('cost').innerHTML = totalCost;
    updateGrid();
}


function choose(id, text, cost) {


    var grid = $("#grid").data("kendoGrid");
    var dataSource = grid.dataSource;
    var raw = dataSource.data();
    var length = raw.length;
    var result = true;
    var item = localStorage.getItem(id);
    if (item === null) {
        localStorage.setItem(id, JSON.stringify({ Id: id, Text: text, Cost: cost, Count: 1 }));
    } else {
        item = JSON.parse(item);
        localStorage.setItem(id, JSON.stringify({ Id: id, Text: text, Cost: cost, Count: item.Count+1 }));
    }
    counting();
}

function clearGrid() {
    var length = localStorage.length;
    for (var i = 0; i <length; i++) {
        remove(localStorage.key(0));
    }
    counting();
}

function remove(id) {

    localStorage.removeItem(id);
    counting();


}

function sendOrder(message) {
    var idArray = [];
    var countArray = [];
    var grid = $("#grid").data("kendoGrid");
    var dataSource = grid.dataSource;
    var raw = dataSource.data();
    var length = raw.length;
    for (var i = 0; i < length; i++) {
        idArray.push(raw[i].Id);
        countArray.push(document.getElementById(raw[i].Id).value);
    }
    $.post('/Home/Order', { idArray, countArray},
        function (data) {
            console.log(data);
            alert(message);
        });

    clearGrid();
}
