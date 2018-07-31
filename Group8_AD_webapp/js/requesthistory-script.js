$(document).ready(function () {
    var dp1 = $('#txtEndDate');
    dp1.datepicker({
        changeMonth: true,
        changeYear: true,
        format: "dd/mm/yyyy"
    }).on('changeDate', function (ev) {
        $(this).blur();
        $(this).datepicker('hide');
    });
    var dp = $('#txtStartDate');

    dp.datepicker({
        changeMonth: true,
        changeYear: true,
        format: "dd/mm/yyyy"
    }).on('changeDate', function (ev) {
        $(this).blur();
        $(this).datepicker('hide');
    });
});