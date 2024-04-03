$(document).ready(function () {
    BindEditors();
    Salutation();
    Designation();
    Country();
    State();
    District();
});

function BindEditors() {
    $.ajax({
        url: "/Admin/Editors/GetEditors",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            var table;
            table = $('#tblUserRegistration').DataTable({
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
                            return `<div class="dropdown"><button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownbutton" data-toggle="dropdown" style="padding:5px;">Action</button><div class="dropdown-menu dropdownSize"><a class="dropdown-item" id="${row.UserId}" role="button" data-target="#myModalSecond" data-toggle="modal" Onclick="EditUserRegistration(this);">Edit</a><a class="dropdown-item" id="${row.UserId}" role="button" Onclick="DeleteNavigation(this);">Delete</a></div></div>`
                        }
                    },
                    {
                        data: "UserName",
                        render: (data, type, row, meta) => {
                            return row.UserName;
                        }
                    },
                    {
                        data: "EmpCode",
                        render: (data, type, row, meta) => {
                            return row.EmpCode;
                        }
                    },
                    {
                        data: "FullName",
                        render: (data, type, row, meta) => {
                            return row.FullName;
                        }
                    },
                    {
                        data: "Email",
                        render: (data, type, row, meta) => {
                            return row.Email;
                        }
                    },
                    {
                        data: "MobileNo",
                        render: (data, type, row, meta) => {
                            return row.MobileNo;
                        }
                    },
                    {
                        data: "RoleId",
                        render: (data, type, row, meta) => {
                            return row.Designation;
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
function SaveUserRegistration() {
    event.preventDefault();
    var res = validate();
    if (res == false) {
        return false;
    }
    var Email = $('#txtEmail').val();
    var MobileNo = $('#txtMobile').val();
    //var Password = $('#txtpassword').val
    var Password = $('#txtConfirmPassword').val();
    $.ajax({
        url: "/Admin/Editors/CreateRegistration",
        type: "POST",
        data: { Email: Email, MobileNo: MobileNo, Password: Password },
        async: false,
        success: function (result) {
            clearField();
            ModelClose();
            BindEditors();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function EditUserRegistration(obj) {
    var modal = $(obj).attr('data-target');
    var UserId = $(obj).attr('id');
    $.ajax({
        url: "/Admin/Editors/EditUserRegistration/" + UserId,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#hdnUserId').val(result.UserId);
            $('#ddlSalutation').val(result.Salutation);
            $('#txtFirstName').val(result.FirstName);
            $('#txtMiddleName').val(result.MiddleName);
            $('#txtLastName').val(result.LastName);
            $('#txtEmpCode').val(result.EmpCode);
            $('#txtEditMobile').val(result.MobileNo);
            $('#txtEditEmail').val(result.Email);
            $('#ddldesignation').val(result.RoleId);
            $('#ddlState').val(result.StateId);
            $('#ddldistrict').val(result.DistrictId);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $(modal).css('display', 'block');
}
function UpdateUser() {
    event.preventDefault();
    var res = validateUsers();
    if (res == false) {
        return false;
    }
    var data = new FormData();
    data.append('UserId', $('#hdnUserId').val());
    data.append('Salutation', $('#ddlSalutation').val());
    data.append('FirstName', $('#txtFirstName').val());
    data.append('MiddleName', $('#txtMiddleName').val());
    data.append('LastName', $('#txtLastName').val());
    data.append('RoleId', $('#ddldesignation').val());
    data.append('CountryId', $('#ddlCountry').val());
    data.append('StateId', $('#ddlState').val());
    data.append('DistrictId', $('#ddldistrict').val());
    data.append('UserProfilePicture', $('#PicUpload')[0].files[0]);
    $.ajax({
        url: "/Admin/Editors/UpdateEditorRegistration",
        type: "POST",
        data: data,
        contentType: false,
        processData: false,
        async: false,
        success: function (result) {
            clearField();
            ModelCloseSecond()
            BindEditors();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function validate() {
    var isValid = true;
    if ($('#txtEmail').val().trim() == "") {
        $('#txtEmail').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtEmail').css('border-color', 'lightgrey');
    }
    if ($('#txtMobile').val().trim() == "") {
        $('#txtMobile').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtMobile').css('border-color', 'lightgrey');
    }
    if ($('#txtpassword').val().trim() == "") {
        $('#txtpassword').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtpassword').css('border-color', 'lightgrey');
    }
    if ($('#txtConfirmPassword').val().trim() == "") {
        $('#txtConfirmPassword').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtConfirmPassword').css('border-color', 'lightgrey');
    }
    return isValid;
}
function validateUsers() {
    var isValid = true;
    if ($('#ddlSalutation').val().trim() == "" || $('#ddlSalutation').val().trim() == 0) {
        $('#ddlSalutation').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ddlSalutation').css('border-color', 'lightgrey');
    }
    if ($('#txtFirstName').val().trim() == "") {
        $('#txtFirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtFirstName').css('border-color', 'lightgrey');
    }
    if ($('#txtMiddleName').val().trim() == "") {
        $('#txtMiddleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtMiddleName').css('border-color', 'lightgrey');
    }
    if ($('#txtLastName').val().trim() == "") {
        $('#txtLastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtLastName').css('border-color', 'lightgrey');
    }
    if ($('#txtEmpCode').val().trim() == "") {
        $('#txtEmpCode').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtEmpCode').css('border-color', 'lightgrey');
    }
    if ($('#txtEditMobile').val().trim() == "") {
        $('#txtEditMobile').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtEditMobile').css('border-color', 'lightgrey');
    }
    if ($('#txtEditEmail').val().trim() == "") {
        $('#txtEditEmail').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtEditEmail').css('border-color', 'lightgrey');
    }
    if ($('#ddldesignation').val().trim() == "" || $('#ddldesignation').val().trim() == 0) {
        $('#ddldesignation').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ddldesignation').css('border-color', 'lightgrey');
    }
    if ($('#ddlCountry').val().trim() == "" || $('#ddlCountry').val().trim() == 0) {
        $('#ddlCountry').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ddlCountry').css('border-color', 'lightgrey');
    }
    if ($('#ddlState').val().trim() == "" || $('#ddlState').val().trim() == 0) {
        $('#ddlState').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ddlState').css('border-color', 'lightgrey');
    }
    if ($('#ddldistrict').val().trim() == "" || $('#ddldistrict').val().trim() == 0) {
        $('#ddldistrict').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ddldistrict').css('border-color', 'lightgrey');
    }
    if ($('#PicUpload').val().trim() == "") {
        $('#PicUpload').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PicUpload').css('border-color', 'lightgrey');
    }
    return isValid;
}

function clearField() {
    $('#txtName').val("");
    $('#txtEmail').val("");
    $('#txtMobile').val("");
    $('#txtpassword').val("");
    $('#txtConfirmPassword').val("");
}

function ModelClose() {
    event.preventDefault();
    clearField();
    $('#myModal').modal('hide');
}
function ModelCloseSecond() {
    event.preventDefault();
    $('#myModalSecond').modal('hide');
}