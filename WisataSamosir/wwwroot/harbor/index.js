var table = null;
$(document).ready(function () {
    table = $('#dataTable').DataTable({
        "ajax": {
            "url": '/harbors/getAll',
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
                "data": "harbor_Name",
            },
            {
                "data": "location",
            },
            {
                "data": "description",
              
            },
            {
                "render": function (data, type, full, row) {
                    return `<a href="#" class="fas fa-pencil-alt text-warning mr-3" title="Borrow" onclick="DetailAccount(${full.id})"></a>
                            <a href="#" class="fas fa-trash-alt mr-3 text-danger" title="Borrow"onClick="DeleteHarbor(${full.id})"></a>`
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

const DeleteHarbor = (harbor_id) => {
    Swal.fire({
        title: 'Apa Anda Yakin menghapus ? ',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Delete',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/harbors/Delete/' + harbor_id,
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

const DetailAccount = (harbor_id) => {
    $.ajax({
        url: '/harbors/Get/' + harbor_id
    }).done(data => {
        console.log(data);
        $("#harbor #SubmitInsert").hide()
        $("#harbor #id").val(data.id)
        $("#harbor #name").val(data.harbor_Name)
        $("#harbor #location").val(data.location)
        $("#harbor #description").val(data.description)
        $("#harbor").modal("show");
    });
}
function ModalAddHarbor() {
    $("#harbor #SubmitUpdate").hide()

    $("#harbor").modal("show");

}
function Update() {
    var harbor = new Object();
    harbor.id = $("#harbor #id").val();;
    harbor.name = $("#harbor #name").val();
    harbor.description = $("#harbor #description").val();
    harbor.location= $("#harbor #location").val();
    $.ajax({
        url: "/Harbors/Put",
        data: harbor,
        type: 'PUT'
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

$.ajax({
    url: 'https://maps.googleapis.com/maps/api/geocode/json?address=' + "medan" + '&key=AIzaSyBF2ZTrnHd5ko_mQitE9kWiy2TWe-1X-3g',
    type: 'get',
    success: function (data) {
        if (data.status === 'OK') {
            // Get the lat/lng from the response
            let lat = data.results[0].geometry.location.lat;
            let lng = data.results[0].geometry.location.lng;
        }
    },
    error: function (msg) {
        // handle error
    }
});
function Add() {
    $("#harbor #SubmitUpdate").hide();
    var harbor = new Object();
    harbor.harbor_name = $("#harbor #name").val();
    harbor.location = $("#harbor #location").val();
    harbor.description = $("#harbor #description").val();
     
    $.ajax({
        url: "/harbors/Post",
        data: JSON.stringify(harbor),
        type: 'POST'
    }).then((result) => {
        
        if (result == 200) {
            console.log(JSON.stringify(harbor));
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

function SubmitUpdateHarbor() {
    Update();
}
function SubmitAddHarbor() {
    Add();
}



