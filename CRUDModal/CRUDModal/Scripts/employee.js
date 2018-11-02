function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}

function Delete(id) {
    var ans = confirm("Are you sure you want to delete this Record?"+id);
    if (ans) {
        $.ajax({
            url: "/Employees/Delete/"+id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                window.location.href = "/Employees/Index";
            },
            error: function (errormessage) {
                alert("error");
            }
        });
    }
}





//$(document).ready(function () {
        
//    //get departments
//    $.ajax({
//        type: "GET",
//        url: "/Employees/DepList",
//        contentType: "application/json;charset=UTF-8",
//        dataType: "json",
//        success: function (data) {
//            var s = '<option value="-1">Please Select a Department</option>';
//            $.each(data, function (index, row) {
//                $("#Departments").append("<option value ='" + row.Id + "'>" + row.Name + "</option>")
//            });
//        }
//    });

//    //get role
//    $.ajax({
//        type: "GET",
//        url: "/Employees/RoleList",
//        contentType: "application/json;charset=UTF-8",
//        dataType: "json",
//        success: function (data) {
//            var s = '<option value="-1">Please Select a Role</option>';
//            $.each(data, function (index, row) {
//                $("#Roles").append("<option value ='" + row.Id + "'>" + row.Name + "</option>")
//            });
//        }
//    });
//});


//preview Image


//function Add() {
//    var file = { Foto: $("#ImageUpload").get(0).files };
//    $("#ImageUpload").append('<img src="/Images/');
//    var depObj = {
//        FirstName : $('#firstname').val(),
//        LastName : $('#lastname').val(),
//        Age : $('#age').val(),
//        Gender: $('#gender').val(),
//        Foto: $('#ImageUpload').get(0).files,
//        Salary : $('#salary').val(),
//        Email: $('#email').val(),
//        Address : $('#address').val(),
//        Password : $('#password').val(),
//        Departments: $('#departments').val(),
//        Roles: $('#roles').val()
        
//    };
//    $.ajax({
//        url: "/Employees/Add",
//        type: "POST",
//        data: JSON.stringify(depObj, file),
//        contentType: "application/json;charset=utf-8",  
//        dataType: "json",  
//        success: function (result) {
           
//            window.location.href = "/Employees/";
//        },  
//        error: function (errormessage) {  
//            alert(errormessage.responseText);  
//        }   
//    });


//}

//function delete



//var Departments = []
////fetch departments from database

//function LoadDepartments(element) {
//    if (Departments.length == 0) {
//        //ajax function for fetch data
//        $.ajax({
//            type: 'GET',
//            url: '/Employees/getDepartments',
//            success: function (data) {
//                Departments = data;
//                //render category
//                renderDepartment(element);

//            }
//        })
//    }
//    else {
//        //render category to element
//        renderDepartment(element);
//    }
//}

//function renderDepartment(element) {
//    var $ele = $(element);
//    $ele.empty();
//    $ele.append($('<option/>').val('0').text('Select'));
//    $.each(Departments, function (i, val) {
//        $ele.append($('<option/>').val(val.Id).text(val.Name));
//    })
//}

//LoadDepartments($('#departments'));