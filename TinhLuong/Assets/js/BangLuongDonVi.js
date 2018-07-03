$(function () {
    $(".btnDeleteAdvs").click(function () {
        var a = $(this).data("id");
        $.ajax({
            type: "POST", url: "/BangLuongDonVi/Details", data: '{nhansuID: "' + a + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "html", success: function (a) {
                $("#dialog").html(a),
                $("#dialog").dialog("open")
            }, failure: function (a) { alert(a.responseText) },
            error: function (a) { alert(a.responseText) }
        })
    }),
    $("#viewSalary").click(function () {
        var a = $("#drpThang").val(),
            b = $("#drpNam").val();
        a > 0 & b > 0 ? window.location.href = "/bang-luong-don-vi/thang-" + a + "-nam-" + b : alert("Bạn phải chọn tháng và năm để xem dữ liệu bảng lương!")
    })
});