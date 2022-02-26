$(function () {
    var placeholder = $("#modal-placeholder");
    $(document).on('click','button[data-toggle="ajax-modal"]',function () {
        var url = $(this).data('url');
        $.ajax({
            url: url,
            beforeSend: function () { ShowLoading(); },
            complete: function () { $("body").preloader('remove'); },
            error: function () {
                ShowSweetErrorAlert();
            }
        }).done(function (result) {
            placeholder.html(result);
            placeholder.find('.modal').modal('show');
        });
    });

    placeholder.on('click', 'button[data-save="modal"]', function () {
        ShowLoading();
        var form = $(this).parents(".modal").find('form');
        var actionUrl = form.attr('action');

        if (form.length == 0) {
            form = $(".card-body").find('form');
            actionUrl = form.attr('action') + '/' + $(".modal").attr('id');
        }
      
        var dataToSend = new FormData(form.get(0));

        $.ajax({
            url: actionUrl, type: "post", data: dataToSend, processData: false, contentType: false, error: function () {
                ShowSweetErrorAlert();
            }}).done(function (data) {
                var newBody = $(".modal-body", data);
                var newFooter = $(".modal-footer", data);
                placeholder.find(".modal-body").replaceWith(newBody);
                placeholder.find(".modal-footer").replaceWith(newFooter);

            var IsValid = newBody.find("input[name='IsValid']").val() === "True";
            if (IsValid) {
                $.ajax({ url: '/Base/Notification', error: function () { ShowSweetErrorAlert(); } }).done(function (notification) {
                    ShowSweetSuccessAlert(notification)
                });
                var tableElement = $("#myTable");
                var tableUrl = tableElement.data('url');
                $.ajax({ url: tableUrl, error: function () { ShowSweetAlert(); } }).done(function (table) {
                    $("#tableContent").html(table);
                });
                placeholder.find(".modal").modal('hide');
            }
        });

        $("body").preloader('remove');
    });
});

function ShowSweetErrorAlert() {
    Swal.fire({
        type: 'error',
        title: 'خطایی رخ داده است !!!',
        text: 'لطفا تا برطرف شدن خطا شکیبا باشید.',
        confirmButtonText: 'بستن'
    });
}

function ShowLoading() {
    $("body").preloader({ text: 'لطفا صبر کنید ...' });
}

function ShowSweetSuccessAlert(message) {
    
    Snackbar.show({
        text: message,
        actionText: 'بستن',
        actionTextColor: '#e2a03f',
            pos: 'top-right'
        });
   
}
function ShowSweetAlert(message) {

    Snackbar.show({
        text: message,
        pos: 'bottom-right'
    });

}
function Search() {
    var input, filter, table, tr, td, id, txtValue;
    input = document.getElementById("MySearchInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");

    for (var i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];

        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {

                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}