'use strict';


function sortTable(n) {
    var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
    table = document.getElementById("tableLectures");
    switching = true;

    dir = "asc";

    while (switching) {
        switching = false;
        rows = table.getElementsByTagName("TR");

        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false;
            x = rows[i].getElementsByTagName("TD")[n];
            y = rows[i + 1].getElementsByTagName("TD")[n];
            if (dir == "asc") {
                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            } else if (dir == "desc") {
                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            switchcount++;
        } else {
            if (switchcount == 0 && dir == "asc") {
                dir = "desc";
                switching = true;
            }
        }
    }
}



function searchTheme() {
    var strForSearch = document.getElementById("strForSearch").value;
    var table = document.getElementById("tableLectures");
    var isFinded = 0;

    if (table.children.length > 2) {
        table.removeChild(table.children.item(2));
    }

    for (var i = 1; i < table.rows.length; i++) {
        if (table.rows[i].cells[1].innerHTML.indexOf(strForSearch, 0) > -1) {
            table.rows[i].style.display = "";
        }
        else {
            table.rows[i].style.display = "none";
            isFinded++;
        }
    }

    if ((table.rows.length - 1) == isFinded) {
        var para = document.createElement("p");
        para.id = "notFound";
        para.className = "w3-green";

        var node = document.createTextNode("Лекция не найдена");
        para.appendChild(node);

        document.getElementById("tableLectures").appendChild(para);

    }
}