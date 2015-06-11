$(function () {
    $('select').selectpicker();

    $('.date').datepicker({
        language: "zh-TW",
        clearBtn: true,
        todayHighlight: true,
        format: "yyyy-mm-dd",
        autoclose: true
    });

    $('.radio :radio, .checkbox :checkbox').iCheck({
        checkboxClass: 'icheckbox_minimal-blue',
        radioClass: 'iradio_minimal-blue',
        increaseArea: '20%' // optional
    });

    // Fixed bootstrap validation class
    $("span.field-validation-valid, span.field-validation-error").addClass('help-block');
    $("div.form-group").has("span.field-validation-error").addClass('has-error');
    $("div.validation-summary-errors").has("li:visible").addClass("alert alert-block alert-danger");
});