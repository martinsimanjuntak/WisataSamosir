var table = null;
$(document).ready(function () {
    table =  $('#dataTable').DataTable({
        "ajax": {
            "url": '/accounts/getAccount',
            "datatype": "json",
            "dataSrc": ""
        },
        "columns": [
            {
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "username",
            },
            {
                "data": "email",
            },
            {
                "data" : "role",
                "render": function (data, type, full, meta) {
                    var html = '';
                    if (data == "ADMIN") {
                        return html += `<span class="badge badge-pill badge-warning">Admin</span> `;
                    } else if(data = "SUPERADMIN"){
                        return html += `<span class="badge badge-pill badge-info">SuperAdmin</span> `;
                    }
                }
            },
            {
                "data": "status",
                "render": function (data, type, full, meta) {
                    var html = '';
                    if (data == "ACTIVE") {
                        return html += `<span class="badge badge-pill badge-success">Active</span> `;
                    } else if (data = "Expired") {
                        return html += `<span class="badge badge-pill badge-danger">Expired</span> `;
                    }
                }
            },
            {
                "render": function (data, type, full, row) {
                    return `<a href="#" class="fas fa-pencil-alt text-warning mr-3" title="Borrow" onclick="DetailAccount(${full.id})"></a>
                            <a href="#" class="fas fa-trash-alt mr-3 text-danger" title="Borrow"onClick="DeleteAccount(${full.id})"></a>`
                }
            }
        ],
        'columnDefs': [{
            'targets': [0, 2],
            'orderable': false,
        }]

    });
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
});

const DeleteAccount = (account_id) => {
    Swal.fire({
        title: 'Apa Anda Yakin menghapus ? ',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Delete',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/accounts/Delete/' + account_id,
                method: 'DELETE',
                success: function (data) {
                    Swal.fire('Berhasil Dihapus', '', 'success')
                    table.ajax.reload()
                }
            });
        } else if (result.isDenied) {
            Swal.fire('Data Tidak Jadi Dihapus', '', 'info')
        }
    })
}

const DetailAccount = (account_id) => {
    $.ajax({
        url: '/accounts/GetDetail/' + account_id
    }).done(data => {
        console.log(data.role);
        $("#account #SubmitInsert").hide()
        $("#account #id").val(data.id)
        $("#account #username").val(data.username)
        $("#account #email").val(data.email)
        $("#account #password").val(data.password).hide();
        if (data.role == "ADMIN") {
            childr = 2;
        } else if (data.role == "SUPERADMIN") {
            childr = 3;
        }
        $(`#account #role :nth-child(${childr})`).prop('selected', true);
        if (data.status == "ACTIVE") {
            child = 2;
        } else if (data.status == "EXPIRED") {
            child = 3;
        }
        console.log(childr)
        $(`#account #status :nth-child(${child})`).prop('selected', true);
        $("#account").modal("show");
    });
}
function ModalAddAccount() {
    $("#account #SubmitUpdate").hide()

    $("#account").modal("show");

}
function Update() {
    $("#account #SubmitUpdate").show()

    var account = new Object();
    account.id = $("#account #id").val();;
    account.Username = $("#account #username").val();
    account.Email = $("#account #email").val();
    account.Password = $("#account #password").val();
    account.Role = $("#account #role").val();
    account.Status = $("#account #status").val()
    console.log(account);
    $.ajax({
        url: "/Accounts/UpdateAccount",
        data: account,
        type : 'PUT'
    }).then((result) => {
        console.log(result);
        if (result == 200) {
            Swal.fire(
                'Good job!',
                'Your data has been saved!',
                'success'
            )   
            $("#account").modal("toggle");
            table.ajax.reload();
        } else if (result == 400) {
            Swal.fire(
                'Watch Out!',
                'Duplicate Data!',
                'error'
            )
        }
    }).catch((error) => {
        console.log(error);
    })
}
function Add() {
    $("#account #SubmitUpdate").hide();
    var account = new Object();
    account.Username = $("#account #username").val();
    account.Email = $("#account #email").val();
    account.Password = $("#account #password").val();
    account.Role = $("#account #role").val();
    account.Status = $("#account #status").val()
    console.log(account);
    $.ajax({
        url: "/Accounts/AddAccount",
        data: account,
        type: 'POST'
    }).then((result) => {
        console.log(result);
        if (result == 200) {
            Swal.fire(
                'Good job!',
                'Your data has been saved!',
                'success'
            )
            $("#myModal").modal("toggle").hide();
            table.ajax.reload();
        } else if (result == 400) {
            Swal.fire(
                'Watch Out!',
                'Duplicate Data!',
                'error'
            )
        }
    }).catch((error) => {
        console.log(error);
    })
}

function SubmitUpdateAccount() {
    Update();
}
function SubmitAddAccount() {
    Add();
}

