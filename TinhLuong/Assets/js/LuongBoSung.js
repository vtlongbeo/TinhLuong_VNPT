$("#DonViID").change(function () {
    return $("#Tram").empty(), $("#NhanVien").empty(), $("#DonViID").val() ? $.ajax({
        url: "/LuongBoSung/LoadDonViTram",
        data: { donviID: $("#DonViID").val() }, dataType: "json", type: "POST",
        success: function (a) { $("#Tram").append('<option value="All">--Chọn tất cả--</option>'), $("#NhanVien").append('<option value="0">--Chọn nhân viên--</option>'), $.each(a, function (a, b) { $("#Tram").append('<option value="' + b.Value + '">' + b.Text + "</option>") }) }, error: function (a) { alert("Failed to retrieve states." + a) }
    }) : alert("Vui lòng chọn Đơn vị cấp trên!"), !1
}), $("#Tram").change(function () {
    return $("#NhanVien").empty(), $("#Tram").val() ? $.ajax({
        url: "/LuongBoSung/LoadNhanVien", data: { donviID: $("#Tram").val() },
        dataType: "json", type: "POST", success: function (a) {
            $("#NhanVien").append('<option value="0">--Chọn nhân viên--</option>'),
            $.each(a, function (a, b) { $("#NhanVien").append('<option value="' + b.Value + '">' + b.Text + "</option>") })
        }, error: function (a) { alert("Failed to retrieve states." + a) }
    }) : alert("Vui lòng chọn Đơn vị cấp trên!"), !1
}), $("#drpNamBS").change(function () {
    return $("#LoaiBS").empty(), $("#drpNamBS").val() ? $.ajax({
        url: "/LuongBoSung/LoadBS", data: { Nam: $("#drpNamBS").val() }, dataType: "json", type: "POST",
        success: function (a) {
            $("#LoaiBS").append('<option value="0">--Chọn bổ sung--</option>'),
                $.each(a, function (a, b) { $("#LoaiBS").append('<option value="' + b.Value + '">' + b.Text + "</option>") })
        }, error: function (a) { alert("Failed to retrieve states." + a) }
    }) : alert("Vui lòng chọn năm bổ sung!"), !1
});