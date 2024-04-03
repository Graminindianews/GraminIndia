$(document).ready(function () {
    BindNavigation();
});

function BindNavigation() {
    $.ajax({
        url: "/Admin/Navigation/GetNavigation",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            var table;
            table = $('#tblNavigation').DataTable({
                bProcessing: true,
                bLengthChange: false,
                blengthMenu: [[10, 25, -1], [10, 25, 'All']],
                bFilter: false,
                bSort: false,
                bPaginate: true,
                bDestroy: true,
                data: data,
                columns: [
                    {
                        data: "Action",
                        render: (data, type, row, meta) => {
                            return `<div class="dropdown"><button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownbutton" data-toggle="dropdown" style="padding:5px;">Action</button><div class="dropdown-menu dropdownSize"><a class="dropdown-item" id="${row.NavigationId}" role="button" data-target="#myModal" data-toggle="modal" Onclick="EditNavigation(this);">Edit</a><a class="dropdown-item" id="${row.NavigationId}" role="button" Onclick="DeleteNavigation(this);">Delete</a></div></div>`
                        }
                    },
                    {
                        data: "Navigation Name",
                        render: (data, type, row, meta) => {
                            return row.NavigationName;
                        }
                    }
                ]
            })
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function CreateNavigation() {
    event.preventDefault();
    var res = validate();
    if (res == false) {
        return false;
    }
    var NavigationName = $('#txtNavigation').val();
    $.ajax({
        url: "/Admin/Navigation/AddNavigation",
        type: "POST",
        data: { NavigationName: NavigationName },
        async: false,
        success: function (result) {
            clearField();
            ModelClose();
            BindNavigation();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function EditNavigation(obj) {
    var modal = $(obj).attr('data-target');
    var NavigationId = $(obj).attr('id');
    $.ajax({
        url: "/Admin/Navigation/EditNavigation/" + NavigationId,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#lblNaviId').val(result.NavigationId);
            $('#txtNavigation').val(result.NavigationName);
            $('#btnUpdate').show();
            $('#btnSave').hide();
        }
    });
    $(modal).css('display', 'block');
}
function UpdateNavi() {
    event.preventDefault();
    var res = validate();
    if (res == false) {
        return false;
    }
    var NavigationId = $('#lblNaviId').val();
    var NavigationName = $('#txtNavigation').val();
    $.ajax({
        url: "/Admin/Navigation/UpdateNavigation",
        type: "POST",
        data: { NavigationId: NavigationId, NavigationName: NavigationName },
        async: false,
        success: function (result) {
            clearField();
            ModelClose();
            BindNavigation();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function DeleteNavigation(obj) {
    var NavigationId = $(obj).attr('id');
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Admin/Navigation/DeleteNavigation/" + NavigationId,
            type: "POST",
            dataType: "json",
            success: function (result) {
                if (result) {
                    dtRow = $(obj).closest('tr');  //assigning value on click delete
                    var stockistTable = $('#tblNavigation').DataTable();
                    stockistTable.row(dtRow).remove().draw(false);
                    BindNavigation();
                }
            }
        });
    }
}

function validate() {
    var isValid = true;
    if ($('#txtNavigation').val().trim() == "") {
        $('#txtNavigation').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtNavigation').css('border-color', 'lightgrey');
    }
    return isValid;
}
function clearField() {
    $('#txtNavigation').val("");
    $('#btnUpdate').hide();
    $('#btnSave').show();
}

function ModelClose() {
    event.preventDefault();
    clearField();
    $('#myModal').modal('hide');
}