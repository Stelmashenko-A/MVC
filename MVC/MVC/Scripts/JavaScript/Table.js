function Table(size) {
    var str = "<table border=0 cellpadding=0 cellspacing=0>";
    for (var i = 0; i < size; i++) {
        str += "<tr>";
        for (var j = 0; j < size; j++) {
            str += '<td width=50height=50>' +
                        "<form style='width: 100%;'>" +
                            '<input type="text" id=textbox"' + (i * size + j) +
                            '"style="width: 100%; height: inherit; box-sizing: border-box;">' +

                "</form>" +
                "</td>";
        }
        str += "</tr>";
    }
    str += "</table>";
    var dat = document.getElementById("table");
    dat.innerHTML = str;

}
function CreateTable(size) {
    var str = "";
    for (var i = 0; i < size; i++) {
        str += "<tr>";
        for (var j = 0; j < size; j++) {
            str += '<td width=50height=50>' +
                        "<form style='width: 100%;'>" +
                            '<input type="text" id=textbox"' + (i * size + j) +
                            ' name=Array[' + (i * size + j) + ']' +
                            '"style="width: 100%; height: inherit; box-sizing: border-box;">' +

                "</form>" +
                "</td>";
        }
        str += "</tr>";
    }
    return str;
}

function CreateTableByMatrix(matrix) {

    var str = "";
    var size = Math.sqrt(matrix.length);
    for (var i = 0; i < size; i++) {
        str += "<tr>";
        for (var j = 0; j < size; j++) {

            str += '<td width=50height=50>' +

                            '<input type="text" id="Array[' + (i * size + j).toString() + ']"'
                            + ' name="Array[' + (i * size + j).toString() + ']"' +
                            'value="' + matrix[i*size+j] + '" ' +

                            'style="width: 100%; height: inherit; box-sizing: border-box;">' +


                "</td>";
        }
        str += "</tr>";
    }
    return str;
}
function SendMatrix() {
    var array = [];
    $('[id^=textbox]').each(function () {
        var val = $(this).val();
        array.push(val);
    });
    $.ajax({
        type: "POST",
        url: '/Home/Answer',
        dataType: "html",
        traditional: true,
        data: { 'array': array }
    }).done(function (data) {
        window.location = '/Home/Answer';
        $('#result').val(data);
    }).fail(function (data) {
        // alert(data);
    });
}

function SendData() {

    $.ajax({
        type: "POST",
        traditional: true,
        data: $("#table").serialize()
    }).done(function (data) {
        $('#result').val(data.length);
    }).fail(function (data) {
        // alert(data);
    });
}