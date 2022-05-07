var table = null;
$(document).ready(function () {
    table = $('#dataTable').DataTable({
        "ajax": {
            "url": '/touristattractions/GetAll',
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
                "data": "name",
            },
            {
                "data": "location",
            },
            {
                "data": "description",
                render: function (data, type, row) {
                    return data.substr(0, 150)+'...';
                }
                
            },
            {
                "render": function (data, type, full, row) {
                    return `<a href="#" class="fas fa-pencil-alt text-warning mr-3" title="Borrow" onclick="DetailAccount(${full.id})"></a>
                            <a href="#" class="fas fa-trash-alt mr-3 text-danger" title="Borrow"onClick="DeleteTour(${full.id})"></a>`
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
const DeleteTour = (id) => {
    Swal.fire({
        title: 'Apa Anda Yakin menghapus ? ',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Delete',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/touristattractions/Delete/' + id,
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

function AddTour() {
    console.log("Berhasil");
    $("#tour #SubmitUpdate").hide()

    $("#tour").modal("show");

}
function SubmitAddTour() {
    Add();
}
function Add() {
    $("#tour #SubmitUpdate").hide();
    var tour = new Object();
    tour.location = $("#tour #location").val();
    tour.name = $("#tour #name").val();
    tour.description = $("#tour #description").val();

    $.ajax({
        url: "/touristattractions/Post",
        data: tour,
        type: 'POST'
    }).then((result) => {

        if (result == 200) {
            console.log(JSON.stringify(tour));
            Swal.fire(
                'Good job!',
                'Your data has been saved!',
                'success'
            )

            $("#myModal").modal("toggle");
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


