//// Load data in table when document is ready
//$(document).ready(function(){
//    loadData();
//})

////Load data function
//function loadData(){
//    $.ajax({
//        url: "/Departments/Index",
//        type: "GET",
//        conetenType: "application/json;chartset=utf-8",
//        success: function (result){
//            return result;
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}

//Add data function
function Add() {
    var depObj = {
        Id : $('#Id').val(),
        Name : $('#Name').val()
    };
    $.ajax({
        url: "/Departments/Add",
        type: "POST",
        data: JSON.stringify(depObj),
        contentType: "application/json;charset=utf-8",  
        dataType: "json",  
        success: function (result) {
            window.location.href = "/Departments/Index";
        },  
        error: function (errormessage) {  
            alert(errormessage.responseText);  
        }   
    });
}

//Get by Id
function GetByID(id) {
    $('#Name').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Departments/GetByID/" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);            
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


//function delete
function Delete(id) {
    var ans = confirm("Are you sure you want to delete this Record?"+id);
    if (ans) {
        $.ajax({
            url: "/Departments/Delete/"+id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                window.location.href = "/Departments/Index";
            },
            error: function (errormessage) {
                alert("error");
            }
        });
    }
}

//function update
function Update() {
    var empObj = {
        Id: $('#Id').val(),
        Name: $('#Name').val()
        
    };
    $.ajax({
        url: "/Departments/Update/",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            window.location.href = "/Departments/Index";            
        },
        error: function (errormessage) {
            alert("error"+empObj.Id +empObj.Name);
        }
    });
}