$("#drpThang").change(function () {
    var thang = $("#drpThang").val();
    var nam = $("#drpNam").val()
    if (thang && nam) {
        $.ajax({
            type: "POST",
            url: "/LayDuLieuDauThang/GetNgayCong",
            data: { thang: thang, nam: nam },
            dataType: "json",
            success: function (data) {
                $('#NC').val(data.status);
            },
            error: function () {
            }
        });
    } else {
        $('#NC').val("0");
    }
 
});

$("#drpNam").change(function () {
    var thang = $("#drpThang").val();
    var nam = $("#drpNam").val()
    if (thang && nam) {
        $.ajax({
            type: "POST",
            url: "/LayDuLieuDauThang/GetNgayCong",
            data: { thang: thang, nam: nam },
            dataType: "json",
            success: function (data) {
                $('#NC').val(data.status);
            },
            error: function () {
            }
        });
    } else {
        $('#NC').val("0");
    }
});