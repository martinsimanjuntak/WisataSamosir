console.log("Martin Berhasil")
$.ajax({
    url: '/PortRoutes/getAll'
}).done(res => {
    let htmlContent = "";
    console.log(res)

    $.each(res, (key, value) => {
        console.log(key);
        htmlContent +=
            `<div class="col-xl-3 col-md-6 mt-5">
                            <div class="card border-left-primary shadow h-100">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center mb-2">
                                        <div class="col mr-2">
                                            <div class="h5 mb-0 font-weight-bold text-gray-800">${value.routeName}</div>
                                        </div>
                                        <div class="col-auto">
                                             <a href="/Schedules/schedule/${value.id}"><i class="fas fa-calendar fa-2x text-primary-300"></i></a>
                                        </div>
                                    </div>
                                       <a href="#" onClick="Delete(${value.id})" class="mb-0"><i class="fas fa-pencil-alt text-warning mr-2"></i></a>
                                       <a href="#" onClick="Delete(${value.id})" class="mb-0"><i class="fas fa-trash text-danger"></i></a>
                                    <div></div>
                                </div>
                            </div>
                        </div>`
    });

    $('#card_route').html(htmlContent)
})

function ModalAddRoute() {
    $("#route #SubmitUpdate").hide()

    $("#route").modal("show");
}


const Delete = (portRoute_id) => {
    Swal.fire({
        title: 'Apa Anda Yakin menghapus ? ',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Delete',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/PortRoutes/Delete/' + portRoute_id,
                method: 'DELETE',
                success: function (data) {
                    Swal.fire('Berhasil Dihapus', '', 'success')
                    location.reload()
                }
            });
        } else if (result.isDenied) {
            Swal.fire('Data Tidak Jadi Dihapus', '', 'info')
        }
    })
}

function SubmitAddHarbor() {
    Add();
}
$.ajax({
    url: 'https://localhost:44329/harbors/getall'
}).done(res => {
    let htmlContent = "<option selected disabled>...</option>";
    $.each(res, (key, value) => {
        htmlContent += `<option value="${res[key].id}">${res[key].harbor_Name}</option>`
    });
    $('#harbor_start').html(htmlContent)
    $('#harbor_end').html(htmlContent)
})
function Add() {
    $("#route #SubmitUpdate").hide();
    var port_route = new Object();
    port_route.Harbor_Start = $("#route #harbor_start").val();
    port_route.Harbor_End = $("#route #harbor_end").val();
    console.log(port_route);
    $.ajax({
        url: "/PortRoutes/addPortRoute",
        data: port_route,
        type: 'POST'
    }).then((result) => {
        console.log(result);
        if (result == 200) {
            Swal.fire(
                'Good job!',
                'Your data has been saved!',
                'success'
            )
            $("#myModal").modal("toggle");
           location.reload();
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