
$(document).ready(function () {
    $.ajaxSetup({ cache: false });
    $(".viewDialog").on("click", function (e) {
        e.preventDefault();

        $("<div></div>")
            .addClass("dialog")
            .appendTo("#createForm")
            .dialog({
                title: $(this).attr("data-dialog-title"),
                close: function () { $(this).remove() },
                modal: true
            })
            .load(this.href);
    });

    $(function () {
        // Заполняем таблицу должностей по IdOtdel
        $('#searching').on('input', function () {
            $.ajax({
                type: 'GET',
                url: '@Url.Action("Create")/',
                success: function (data) {
                    // заменяем содержимое присланным частичным представлением
                    $('#createForm').replaceWith(data);
                }
            });
        });
    });
});