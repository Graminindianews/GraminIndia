$(document).ready(function () {
    Category();
    BindNews();
});

function AddNews() {
    debugger;
    event.preventDefault();
    var res = validate();
    if (res == false) {
        return false;
    }
    var Desc1 = CKEDITOR.instances.txtNewsSectionOne.getData();
    var Desc2 = CKEDITOR.instances.txtNewsSectionTwo.getData();
    var Banner = $("#CheckBoxBannerId").prop("checked") ? true : false;
    //if ($('#CheckBoxBannerId').is(":checked")) {
    //    Banner = true;
    //}
    //else {
    //    Banner = false;
    //}
    var data = new FormData();
    data.append('NewsNavigationId', $('#ddlNewsCategory').val());
    data.append('NewsTitle', $('#txtNewsTitle').val());
    data.append('NewsHeading', $('#txtNewsHeading').val());
    data.append('NewsDescriptionOne', Desc1);
    data.append('ImageUrlA', $('#Image1Id')[0].files[0]);
    data.append('ImageUrlB', $('#Image2Id')[0].files[0]);
    data.append('ImageUrlC', $('#Image3Id')[0].files[0]);
    data.append('YouTubeVideoUrl', $('#txtVideoUrls').val());
    data.append('NewsDescriptionTwo', Desc2);
    data.append('EditorId', $('#txtNewsEditors').val());
    data.append('TagDetails', $('#txtTagDetails').val());
    data.append('WebUrls', $('#ddlSalutation').val());
    data.append('Banner', Banner);
    $.ajax({
        url: "/Admin/AddNews/SaveNews",
        type: "POST",
        data: data,
        contentType: false,
        processData: false,
        async: false,
        success: function (result) {
            //clearField();
            ModelClose();
            BindNews();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function BindNews() {
    $.ajax({
        url: "/Admin/AddNews/GetNews",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            var table;
            table = $('#tblNewsDetails').DataTable({
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
                            return `<div class="dropdown"><button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownbutton" data-toggle="dropdown" style="padding:5px;">Action</button><div class="dropdown-menu dropdownSize"><a class="dropdown-item" id="${row.NewsId}" role="button" data-target="#myModalSecond" data-toggle="modal" Onclick="EditUserRegistration(this);">Edit</a><a class="dropdown-item" id="${row.NewsId}" role="button" Onclick="DeleteNavigation(this);">Delete</a></div></div>`
                        }
                    },
                    {
                        data: "View",
                        render: (data, type, row, meta) => {
                            return `<td><a href='#' id="${row.NewsId}" type="button" data-target="#myModalView" data-toggle="modal" onclick="ViewNews(this);"'><i class='fa fa-eye' style="font-size: x-large;"></i></a></td>`
                        }
                    },
                    {
                        data: "NewsTitle",
                        render: (data, type, row, meta) => {
                            return row.NewsTitle;
                        }
                    },
                    {
                        data: "EditorName",
                        render: (data, type, row, meta) => {
                            return row.EditorName;
                        }
                    },
                    //{
                    //    data: "Editor Photo",
                    //    render: (data, type, row, meta) => {
                    //        return '<img src="Upload/UploadNews/' + row.ImageUrlA + '">';
                    //    }
                    //},
                    {
                        data: "Created Date",
                        render: (data, type, row, meta) => {
                            return row.CreatedDate;
                        }
                    },
                    {
                        data: "NavigationName",
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
/*---------------------------------Function for View News--------------------*/
function ViewNews(obj) {
    var modal = $(obj).attr('data-target');
    var NewsId = $(obj).attr('id');
    $.ajax({
        url: "/Admin/AddNews/ViewNews/" + NewsId,
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#ddlNewsCategory').val(result.NewsNavigationId);
            $('#txtNewsTitleView').val(result.NewsTitle);
            $('#txtNewsHeadingView').val(result.NewsHeading);
            $('#txtVideoUrlsView').val(result.YouTubeVideoUrl);
            $('#txtNewsSectionOneView').val(result.NewsDescriptionOne);
            $('#txtNewsSectionTwoView').val(result.NewsDescriptionTwo);
            $('#txtTagDetailsView').val(result.TagDetails);
            $('#txtNewsEditorsView').val(result.EditorName);
            $("#CheckBoxBannerIdView").val(result.Banner).prop("checked") ? true : false;
            $('#img1').val(result.ImageUrlA);
        }
    });
    $(modal).css('display', 'block');
}
function ModelClose() {
    /*event.preventDefault();*/
    /*clearField();*/
    $('#myModal').modal('hide');
}
function ViewModelClose() {
    /*event.preventDefault();*/
    /*clearField();*/
    $('#myModalView').modal('hide');
}
function validate() {
    var desc1 = CKEDITOR.instances.txtNewsSectionOne.getData();
    var desc1 = CKEDITOR.instances.txtNewsSectionTwo.getData();
    var isValid = true;
    if ($('#ddlNewsCategory').val().trim() == "" || $('#ddlNewsCategory').val().trim() == 0) {
        $('#ddlNewsCategory').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ddlNewsCategory').css('border-color', 'lightgrey');
    }
    if ($('#txtNewsTitle').val().trim() == "") {
        $('#txtNewsTitle').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtNewsTitle').css('border-color', 'lightgrey');
    }
    if ($('#txtNewsHeading').val().trim() == "") {
        $('#txtNewsHeading').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtNewsHeading').css('border-color', 'lightgrey');
    }
    if (desc1.trim() === '') {
        var editorIframe = $('#txtNewsSectionOne').next().find('iframe');
        editorIframe.css('border', '2px  solid red');
        isValid = false;
    }
    else {
        var editorIframe = $('#txtNewsSectionOne').next().find('iframe');
        editorIframe.css('border-color', 'lightgrey');
    }
    //var fileInputValue = $('#Image1Id');
    //if (fileInputValue.val() === '') {
    //    fileInputValue.css('border-color', 'red');
    //    isValid = false;
    //}
    //else {
    //    fileInputValue.css('border-color', 'lightgrey');
    //}
    if ($('#txtTagDetails').val().trim() == "") {
        $('#txtTagDetails').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtTagDetails').css('border-color', 'lightgrey');
    }
    return isValid;
}
/*------------------------------------Preview Image--------------------*/
$("#Image1Id").on("change", function () {
    const photoInp = $("#Image1Id");
    let imgURL;
    photoInp.change(function (e) {
        imgURL = URL.createObjectURL(e.target.files[0]);
        $("#imgPreview").attr("src", imgURL);
    });
});
$("#Image2Id").on("change", function () {
    const photoInp1 = $("#Image2Id");
    let img1URL;
    photoInp1.change(function (e) {
        img1URL = URL.createObjectURL(e.target.files[0]);
        $("#imgPreview1").attr("src", img1URL);
    });
});
$("#Image3Id").on("change", function () {
    const photoInp2 = $("#Image3Id");
    let img2URL;
    photoInp2.change(function (e) {
        img2URL = URL.createObjectURL(e.target.files[0]);
        $("#imgPreview2").attr("src", img2URL);
    });
});
/*------------------------------------Preview Image End--------------------*/