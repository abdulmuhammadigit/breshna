$(function () {
    var placeholder = $("#modal-placeholder");
    $(document).on('click', 'button[data-toggle="ajax-modal"]', function () {
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
            }
        }).done(function (data) {
            var newBody = $(".modal-body", data);
            var newFooter = $(".modal-footer", data);
            placeholder.find(".modal-body").replaceWith(newBody);
            placeholder.find(".modal-footer").replaceWith(newFooter);

            var IsValid = newBody.find("input[name='IsValid']").val() === "True";
            if (IsValid) {
                $.ajax({ url: '/Admin/Base/Notification', error: function () { ShowSweetErrorAlert(); } }).done(function (notification) {
                    ShowSweetSuccessAlert(notification)
                });

                $table.bootstrapTable('refresh')
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


function ConfigureSettings(id, action) {
    $.ajax({
        url: "/Admin/UserManager/" + action + "?userId=" + id,
        beforeSend: function () { ShowLoading(); },
        complete: function () { $("body").preloader('remove'); },
        type: "get",
        data: {},
    }).done(function (result) {
        if (result == "فعال" || result == "تایید شده" || result == "قفل نشده") {
            $("#" + action).removeClass("badge-danger").addClass("badge-success");
            $("#btn" + action).removeClass("btn-suceess").addClass("btn-danger");
            if (result == "فعال")
                $("#btn" + action).html("غیرفعال شود");
            else if (result == "قفل نشده")
                $("#btn" + action).html("قفل شود");
            else
                $("#btn" + action).html("تایید نشود");
        }

        else {
            $("#" + action).removeClass("badge-success").addClass("badge-danger");
            $("#btn" + action).removeClass("btn-danger").addClass("btn-success");
            if (result == "غیرفعال")
                $("#btn" + action).html("فعال شود");
            else if (result == "قفل شده")
                $("#btn" + action).html("قفل نشود");
            else
                $("#btn" + action).html("تایید شود");
        }
        $("#" + action).html(result);
    });
}
