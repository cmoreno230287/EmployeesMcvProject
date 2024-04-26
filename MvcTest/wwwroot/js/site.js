var js = jQuery.noConflict(true);
js(document).ready(function () {

    LoadData(null);

    js("#btnSearch").on("click", function () {
        js('#tableData').DataTable().destroy();
        var txtSearch = js("#txtSearch").val();
        LoadData(txtSearch);
    });
});

function LoadData(id) {
    var employeesData = [];

    var ajaxOption = {
        type: "POST",
        url: '/Employee/GetEmployees',                
        dataType: "json",
        async: false,
        success: function (data) {
            if (data.status == null && data.data == null) {
                alert(data.message);
            }
            else {
                js.each(data.data, function (key, value) {
                    employeesData.push([value.employee_name, value.employee_salary, value.employee_anualsalary, value.employee_age, value.profile_image])
                });
            }
        },
        error: function (xhr, status, error) {            
            console.error(status, error);
        }
    };

    if (id != null) {
        ajaxOption.data = { id: id };
    }

    js.ajax(ajaxOption);

    js('#tableData').DataTable({
        data: employeesData,
        searching: false
    });
}