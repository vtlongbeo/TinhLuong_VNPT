function showhide(a) { var b = document.getElementById(a); b.style.display = "block" == b.style.display ? "none" : "block" }
$("#DonViID").change(function () {
    return $("#Tram").empty(),
    $("#NhanVien").empty(),
        $("#DonViID").val() ?
        $.ajax({
            url: "/BaoCaoChung/LoadDonViTram",
            data: { donviID: $("#DonViID").val() },
            dataType: "json",
            type: "POST",
            success: function (a) {
                $("#Tram").append('<option value="All">--Chọn tất cả--</option>'),
                $("#NhanVien").append('<option value="0">--Chọn nhân viên--</option>'),
                $.each(a, function (a, b) { $("#Tram").append('<option value="' + b.Value + '">' + b.Text + "</option>") })
            }, error: function (a) { alert("Failed to retrieve states." + a) }
        }) : alert("Vui lòng chọn Đơn vị cấp trên!"), !1
}), $("#Tram").change(function () {
    return $("#NhanVien").empty(), $("#Tram").val() ?
        $.ajax({ url: "/BaoCaoChung/LoadNhanVien", data: { donviID: $("#Tram").val() }, dataType: "json", type: "POST", success: function (a) { $("#NhanVien").append('<option value="0">--Chọn nhân viên--</option>'), $.each(a, function (a, b) { $("#NhanVien").append('<option value="' + b.Value + '">' + b.Text + "</option>") }) }, error: function (a) { alert("Failed to retrieve states." + a) } }) : alert("Vui lòng chọn Đơn vị cấp trên!"), !1
}),
$("#viewSalary").click(function () { var a = $("#drpThang").val(), b = $("#drpNam").val(), c = $("#DonViID").val(), d = $("#Tram").val(), e = $("#NhanVien").val(); a > 0 & b > 0 ? window.location.href = "/bao-cao-don-vi/thang-" + a + "-nam-" + b + "-donvi-" + c + "-totram-" + d + "-nhanvien-" + e : alert("Bạn phải chọn tháng, năm để xem dữ liệu bảng lương!") }), $("#drpNamBS").change(function () { return $("#LoaiBS").empty(), $("#drpNamBS").val() ? $.ajax({ url: "/BaoCaoChung/LoadBS", data: { Nam: $("#drpNamBS").val() }, dataType: "json", type: "POST", success: function (a) { $("#LoaiBS").append('<option value="0">--Chọn bổ sung--</option>'), $.each(a, function (a, b) { $("#LoaiBS").append('<option value="' + b.Value + '">' + b.Text + "</option>") }) }, error: function (a) { alert("Failed to retrieve states." + a) } }) : alert("Vui lòng chọn năm bổ sung!"), !1 }), $("#reportSalary").click(function () { confirm("Bạn thực sự muốn xem danh sách tổng hợp") && ($("#drpThang").val() > 0 && $("#drpThang").val() > 0 ? window.open("/BaoCaoChung/TongHopReport?thang=" + $("#drpThang").val() + "&nam=" + $("#drpNam").val() + "&dv=" + $("#DonViID").val().replace("-", "_") + "&tram=" + $("#Tram").val() + "&type=BangLuong&luong=Null", "_blank", "scrollbars=1,resizable=1,height=500,width=700") : alert("Phải chọn tháng và năm để xem danh sách tổng hợp")) }), $("#smsKy1").click(function () { confirm("Bạn có chắc chắn gửi tin nhắn Thông báo Lương Kỳ 1?") && ($("#drpNam").val() > 0 && $("#drpThang").val() > 0 ? window.location.href = "/BaoCaoChung/SendSMSKy1?thang=" + $("#drpThang").val() + "&nam=" + $("#drpNam").val() : alert("Phải chọn tháng và năm!")) }), $("#smsQT").click(function () { confirm("Bạn có chắc chắn gửi tin nhắn Thông báo Quyết Toán?") && ($("#drpNam").val() > 0 && $("#drpThang").val() > 0 ? window.location.href = "/BaoCaoChung/SendSMSQuyetToan?thang=" + $("#drpThang").val() + "&nam=" + $("#drpNam").val() : alert("Phải chọn tháng và năm!")) }),
$("#reportKy1").click(function () {
    confirm("Bạn thực sự muốn xem danh sách tổng hợp") && ($("#drpThang").val() > 0 && $("#drpThang").val() > 0 ?
    window.open("/BaoCaoChung/TongHopReport?thang=" + $("#drpThang").val() + "&nam=" + $("#drpNam").val() + "&dv=" + $("#DonViID").val().replace("-", "_") + "&tram=" + $("#Tram").val() + "&type=Ky1&luong=Null", "_blank", "scrollbars=1,resizable=1,height=500,width=700") :
    alert("Phải chọn tháng và năm để xem danh sách tổng hợp"))
}),
$("#reportPTTB").click(function () {
    confirm("Bạn thực sự muốn xem danh sách tổng hợp") && ($("#drpThang").val() > 0 && $("#drpThang").val() > 0 ? window.open("/BaoCaoChung/TongHopReport?thang=" + $("#drpThang").val() + "&nam=" + $("#drpNam").val() + "&dv=" + $("#DonViID").val().replace("-", "_") + "&tram=" + $("#Tram").val() + "&type=PTTB&luong=Null", "_blank", "scrollbars=1,resizable=1,height=500,width=700") : alert("Phải chọn tháng và năm để xem danh sách tổng hợp"))
}),
$("#reportKKLD").click(function () {
    confirm("Bạn thực sự muốn xem danh sách tổng hợp") && ($("#drpThang").val() > 0 && $("#drpThang").val() > 0 ? window.open("/BaoCaoChung/TongHopReport?thang=" + $("#drpThang").val() + "&nam=" + $("#drpNam").val() + "&dv=" + $("#DonViID").val().replace("-", "_") + "&tram=" + $("#Tram").val() + "&type=KKLD&luong=Null", "_blank", "scrollbars=1,resizable=1,height=500,width=700") : alert("Phải chọn tháng và năm để xem danh sách tổng hợp"))
}),
$("#reportBank").click(function () {
    if (confirm("Bạn thực sự muốn xem danh sách tổng hợp"))
        if ($("#drpThang").val() > 0 && $("#drpThang").val() > 0)
            for (var a = 0; a < 3; a++) 0 == a && window.open("/BaoCaoChung/TongHopReport_ChuyenKhoanKy1?thang=" + $("#drpThang").val() + "&nam=" + $("#drpNam").val() + "&dv=" + $("#DonViID").val().replace("-", "_") + "&tram=" + $("#Tram").val() + "&type=Agri&luong=Ky1", "_blank", "scrollbars=1,resizable=1,height=500,width=700"), 1 == a && window.open("/BaoCaoChung/TongHopReport_ChuyenKhoanKy1?thang=" + $("#drpThang").val() + "&nam=" + $("#drpNam").val() + "&dv=" + $("#DonViID").val().replace("-", "_") + "&tram=" + $("#Tram").val() + "&type=VC&luong=Ky1", "_blank", "scrollbars=1,resizable=2,top=50, left=50,height=500,width=700"), 2 == a && window.open("/BaoCaoChung/TongHopReport_ChuyenKhoanKy1?thang=" + $("#drpThang").val() + "&nam=" + $("#drpNam").val() + "&dv=" + $("#DonViID").val().replace("-", "_") + "&tram=" + $("#Tram").val() + "&type=Viettin&luong=Ky1", "_blank", "scrollbars=1,resizable=3 ,top=100, left=100,height=500,width=700"); else alert("Phải chọn tháng và năm để xem danh sách tổng hợp")
}),
$("#reportBankQT").click(function () {
    if (confirm("Bạn thực sự muốn xem danh sách tổng hợp")) if ($("#drpThang").val() > 0 && $("#drpThang").val() > 0)
        for (var a = 0; a < 3; a++) 0 == a && window.open("/BaoCaoChung/TongHopReport_ChuyenQT?thang=" + $("#drpThang").val() + "&nam=" + $("#drpNam").val() + "&dv=" + $("#DonViID").val().replace("-", "_") + "&tram=" + $("#Tram").val() + "&type=Agri&luong=QT", "_blank", "scrollbars=1,resizable=1,height=500,width=700"), 1 == a && window.open("/BaoCaoChung/TongHopReport_ChuyenQT?thang=" + $("#drpThang").val() + "&nam=" + $("#drpNam").val() + "&dv=" + $("#DonViID").val().replace("-", "_") + "&tram=" + $("#Tram").val() + "&type=VC&luong=QT", "_blank", "scrollbars=1,resizable=2,top=50, left=50,height=500,width=700"), 2 == a && window.open("/BaoCaoChung/TongHopReport_ChuyenQT?thang=" + $("#drpThang").val() + "&nam=" + $("#drpNam").val() + "&dv=" + $("#DonViID").val().replace("-", "_") + "&tram=" + $("#Tram").val() + "&type=Viettin&luong=QT", "_blank", "scrollbars=1,resizable=3 ,top=100, left=100,height=500,width=700"); else alert("Phải chọn tháng và năm để xem danh sách tổng hợp")
});