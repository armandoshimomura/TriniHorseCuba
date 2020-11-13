$(document).ready(function () {
    chooseFile();
});

function chooseFile() {
    $('#chooseFile0').click(function (ev) {
        var t = $(ev.target);
        t.siblings('input:file').trigger('click');
    });

    $('#chooseFile').click(function (ev) {
        var t = $(ev.target);
        t.siblings('input:file').trigger('click');
    });

    $("input:file").change(function (ev) {
        var t = $(ev.target);
        var files = t[0].files;
        t.siblings("label").find("input:text").val("Archivo seleccionado: " + files[0].name);
        t.siblings("label").find(".clear").show();
        t.siblings('.btn-guardar').removeClass('disabled');
    });

    $(".clear").click(function (ev) {
        var t = $(ev.target);
        t.parent().siblings('input:file').val('');
        t.siblings("input:text").val("");
        t.hide();
        t.parent().siblings('.btn-guardar').addClass('disabled');
    });
}

$("body").on('click', "#cpBody_btnGrabar", function (e) {
    setTimeout(function () { notiACYM(); }, 1000);
});