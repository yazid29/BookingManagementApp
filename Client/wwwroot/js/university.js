console.log('cek');
$.ajax({
    url: "Employee/getall",
    dataType: "JSON"
}).done((result) => {
    console.log('success')
}).fail((error) => {
    console.log('success');
})

//let table = $("#tbl-employee").DataTable({
//    ajax: {
//        url: "https://localhost:58889/api/Employee",
//        dataSrc: "data",
//        dataType: "JSON"
//    },
//    columns: [
//        {
//            render: function (data, type, row, meta) {
//                return meta.row + 1;
//            }
//        },
//        { data: "nik" },
//        {
//            data: "firstName",
//            render: function (data, type, row, meta) {
//                return row.firstName + " " + row.lastName;
//            }
//        },
//        {
//            data: "gender",
//            render: function (data, type, row, meta) {
//                return (row.gender == 1) ? "Male" : "Female";
//            }
//        },
//        { data: "email" },
//        {
//            data: "url",
//            render: function (data, type, row) {
//                let cek = String(row.guid);
//                //console.log("a"+cek);
//                return `<button type="button" class="btn btn-primary" onclick="details('${row.guid }')">
//                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
//                    <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
//                    <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
//                </svg>
//                </button>
//                <button type="button" class="btn btn-danger" onclick="deleteItem('${ row.guid}',${row.nik })">
//                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
//                  <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5Zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5Zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6Z"/>
//                  <path d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1ZM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118ZM2.5 3h11V2h-11v1Z"/>
//                </svg>
//                </button></td>`;
//            }
//        }
//    ],
//    dom: 'fBrtip',
//    buttons: [
//        {
//            extend: 'excelHtml5',
//            attr: {
//                id: 'excel-btn'
//            },
//            className: 'btn btn-success'
//        },
//        {
//            extend: 'pdfHtml5',
//            attr: {
//                id: 'pdf-btn'
//            },
//            className: 'btn btn-danger',
//            /*exportOptions: {
//                columns: ':visible:not(:last-child)'
//            }*/
//        }, {
//            extend: 'colvis',
//            text: 'Visibility',
//            attr: {
//                id: 'colvis-btn'
//            },
//            className: 'btn btn-info'
//        }
        
//    ]
//});
//// datatables
//let element = document.getElementById('excel-btn');
//element.classList.remove('dt-button');
//let element2 = document.getElementById('pdf-btn');
//element2.classList.remove('dt-button', 'buttons-pdf', 'buttons-html5');
//let element3 = document.getElementById('colvis-btn');
//element3.classList.remove('dt-button', 'buttons-colvis');

//let newButton = $('<button class="btn btn-primary" onclick="btnAdd()" data-bs-toggle="modal" data-bs-target="#modalAdd" id="addDataEmp">Add Data</button>');
//$('.dt-buttons').append(newButton);


//let now = new Date();
//console.log(now);
////$('#birthdate').inputmask('dd/mm/yyyy', { 'placeholder': '12/12/1998' })
////$('#hiringdate').inputmask('dd/mm/yyyy', { 'placeholder': '12/12/2022' })
////Datepicker
//$('#hiringdate').datetimepicker({
//    format: 'DD/MM/YYYY'
//});
//$('#birthdate').datetimepicker({
//    format: 'L'
//});
//var Toast = Swal.mixin({
//    //toast: true,
//    //position: 'top-end',
//    showConfirmButton: true,
//    showCancelButton: true,
//    timer: 5000
//});

//function btnAdd() {
//    $('#firstname').val('Ace');
//    $('#lastname').val('Hayato');
//    $('#email').val('aace@mail.com');
//    $('#phonenumber').val('082233335555');
//    let tombol2 = document.getElementById("update");
//    if (tombol2) {
//        tombol2.remove();
//        let newButton = $(' <button type="button" class="btn btn-primary" onclick="saveData()" id="save">Save changes</button> ');
//        $('#footerModalAdd').append(newButton);
//    }
//}
//function btnEdit() {
//    let tombol = document.getElementById("save");
//    if (tombol) {
//        tombol.remove();
//        let newButton = $(' <button type="button" class="btn btn-primary" onclick="updateData()" id="update">Update</button> ');
//        $('#footerModalAdd').append(newButton);
//    }
//}
//// function CRUD
//function saveData() {
//    let empData = new Object();
//    empData.FirstName = $('#firstname').val();
//    empData.LastName = $('#lastname').val();
//    empData.BirthDate = parseDate($('#birthdate').val());
//    empData.Gender = parseInt($('#gender').val());
//    empData.HiringDate = parseDate($('#hiringdate').val());
//    empData.Email = $('#email').val();
//    empData.PhoneNumber = $('#phonenumber').val();
//    console.log(empData);
//    $.ajax({
//        url: "https://localhost:58889/api/Employee",
//        type: "POST",
//        headers: {
//            'Accept': 'application/json',
//            'Content-Type': 'application/json'
//        },
//        dataType: 'JSON',
//        data: JSON.stringify(empData)
//    }).done((result) => {
//        console.log(result);
//        Toast.fire({
//            icon: 'success',
//            title: 'Success Created Data',
//            showCancelButton: false,
//        });
//        $('#modalAdd').modal('hide');
//        table.ajax.reload();
//    }).fail((error) => {
//        console.log(error);
//    });
//}

//function updateData() {
//    let empData = new Object();
//    empData.guid = $('#guid').val();
//    empData.nik = $('#nik').val();
//    empData.firstName = $('#firstname').val();
//    empData.lastName = $('#lastname').val();
//    empData.birthDate = parseDate($('#birthdate').val());
//    empData.gender = parseInt($('#gender').val());
//    empData.hiringDate = parseDate($('#hiringdate').val());
//    empData.email = $('#email').val();
//    empData.phoneNumber = $('#phonenumber').val();
//    console.log(empData);
//    $.ajax({
//        url: "https://localhost:58889/api/Employee",
//        type: "PUT",
//        headers: {
//            'Accept': 'application/json',
//            'Content-Type': 'application/json'
//        },
//        dataType: 'JSON',
//        data: JSON.stringify(empData)
//    }).done((result) => {
//        console.log(result);
//        Toast.fire({
//            icon: 'success',
//            title: 'Success Update Data',
//            showCancelButton: false,
//        });
//        $('#modalAdd').modal('hide');
//        table.ajax.reload();
//    }).fail((error) => {
//        console.log(error);
//    });
//}
//function details(idCek) {
//    btnEdit();
//    $('#modalAdd').modal('show');
    
//    console.log("Edit Employee" + idCek);
//    $.ajax({
//        url: "https://localhost:58889/api/Employee/" + idCek,
//        type: "GET",
//        headers: {
//            'Accept': 'application/json',
//            'Content-Type': 'application/json'
//        },
//        dataType: 'JSON'
//    }).done((result) => {
//        console.log(result);
//        $('#modalAddLabel').html('Edit Data ' + result.data.nik);
//        $('#guid').val(result.data.guid);
//        $('#firstname').val(result.data.firstName);
//        $('#lastname').val(result.data.lastName);
//        $('#birthdate').val(parseOutDate(result.data.birthDate));
//        $('#gender').val();
//        $('#hiringdate').val(parseOutDate(result.data.hiringDate));
//        $('#email').val(result.data.email);
//        $('#phonenumber').val(result.data.phoneNumber);
//    }).fail((error) => {
//        console.log(error);
//    });
//}
//function deleteItem(guid,nik) {
//    console.log("Delete Employee " + guid);
//    Swal.fire({
//        title: 'Apakah Anda Yakin?',
//        text: "Ingin Menghapus Data NIK " + nik + " ?",
//        icon: 'warning',
//        showCancelButton: true,
//        cancelButtonText: 'Tidak',
//        confirmButtonText: 'Ya'
//    }).then((result) => {
//        if (result.isConfirmed) {
//            $.ajax({
//                type: "DELETE",
//                url: "https://localhost:58889/api/Employee?guid=" + guid,
//                cache: false
//            }).done((result) => {
//                console.log(result);
//                Toast.fire({
//                    icon: 'success',
//                    title: 'Data ' + nik + ' Berhasil Dihapus',
//                    showCancelButton: false,
//                });
//                table.ajax.reload();
//            }).fail((error) => {
//                console.log(error);
//            });

//        }
//    })
//}

//function parseDate(datee) {
//    let parts = datee.split("/");
//    if (parts.length === 3) {
//        let day = parts[0];
//        let month = parts[1];
//        let year = parts[2];
//        let newDate = year + "-" + month + "-" + day;
//        return newDate
//    } else {
//        return "invalid";
//    }
//}
//function parseOutDate(datee) {
//    var tanggal = new Date(datee);
//    // Dapatkan nilai tanggal, bulan, dan tahun
//    var tahun = tanggal.getFullYear();
//    var bulan = tanggal.getMonth() + 1; // Ingat, bulan dimulai dari 0
//    var tanggal = tanggal.getDate();
//    // Format bulan dan tanggal agar memiliki dua digit
//    if (bulan < 10) {
//        bulan = "0" + bulan;
//    }
//    if (tanggal < 10) {
//        tanggal = "0" + tanggal;
//    }
//    // Buat string tanggal yang diformat (format: "YYYY-MM-DD")
//    var tanggalFormatted = tanggal + "/" + bulan + "/" + tahun;
//    console.log(tanggalFormatted)
//    return tanggalFormatted;
//}
//function parseOutDates(datee) {
//    let date = new Date(datee);
//    return date;
//}
//$('#modalAdd').on('hidden.bs.modal', function () {
//    console.log("cek");
//    $('#firstname').val('Ace');
//    $('#lastname').val('Hayato');
//    $('#email').val('aace@mail.com');
//    $('#phonenumber').val('082233335555');
//});