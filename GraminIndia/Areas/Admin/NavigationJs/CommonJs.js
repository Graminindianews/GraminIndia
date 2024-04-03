$(document).ready(function () {
    //Salutation();
    //Designation();
    //Country();
    //State();
    //District();
});

var data;
function Salutation() {
    $.ajax({
        url: "/Admin/Common/GetSalutation",
        type: 'GET',
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (response) {
            data = response
            $.each(data, function (row, value) {
                $("#ddlSalutation").append($("<option></option>").val(value.SalutationId).html(value.Salutation));
            })
        },
        failure: function () {
            alert("Failed!");
        }
    });
}
function Designation() {
    $.ajax({
        url: "/Admin/Common/GetDesignation",
        type: 'GET',
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (response) {
            //Designation = response
            data = response
            $.each(data, function (row, value) {
                $("#ddldesignation").append($("<option></option>").val(value.DesignationId).html(value.DesignationName));
            })
        },
        failure: function () {
            alert("Failed!");
        }
    });
}
function Country(id) {
    $.ajax({
        url: "/Admin/Common/GetCountry",
        type: 'GET',
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (response) {
            //Country = response
            data = response
            $.each(data, function (row, value) {
                $("#ddlCountry").append($("<option></option>").val(value.CountryId).html(value.CountryName));
                $("#ddlCountry").val(value.CountryId).select('selected', true);
            })
        },
        failure: function () {
            alert("Failed!");
        }
    });
}
function State(id) {
    $.ajax({
        url: "/Admin/Common/GetState",
        type: 'GET',
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (response) {
            //State = response
            data = response
            $.each(data, function (row, value) {
                $("#ddlState").append($("<option></option>").val(value.StateId).html(value.StateName));
            })
        },
        failure: function () {
            alert("Failed!");
        }
    });
}
function District(id) {
    $.ajax({
        url: "/Admin/Common/GetDistrict",
        type: 'GET',
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (response) {
            //District = response
            data = response
            $.each(data, function (row, value) {
                $("#ddldistrict").append($("<option></option>").val(value.DistrictId).html(value.DistrictName));
            })
        },
        failure: function () {
            alert("Failed!");
        }
    });
}
function Category() {
    $.ajax({
        url: "/Admin/Navigation/GetNavigation",
        type: 'GET',
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (response) {
            data = response
            $.each(data, function (row, value) {
                $("#ddlNewsCategory").append($("<option></option>").val(value.NavigationId).html(value.NavigationName));
            })
        },
        failure: function () {
            alert("Failed!");
        }
    });
}