$("#DonViID").change(function () { return $("#DmBangLuong").empty(), $("#drpThang").val() > 0 && $("#drpNam").val() > 0 && $("#DonViID").val() ? $.ajax({ url: "/ChotSo/loadDMChoSo", data: { Thang: $("#drpThang").val(), nam: $("#drpNam").val(), DonViID: $("#DonViID").val() }, dataType: "json", type: "POST", success: function (a) { $("#DmBangLuong").append('<option value="NULL">--Chọn loại lương--</option>'), $.each(a, function (a, b) { $("#DmBangLuong").append('<option value="' + b.Value + '">' + b.Text + "</option>") }) }, error: function (a) { alert("Failed to retrieve states." + a) } }) : alert("Vui lòng chọn Tháng, Năm, và chọn lại Đơn vị!"), !1 }), $("#viewSalary").click(function () { var a = $("#drpThang").val(), b = $("#drpNam").val(), c = $("#DonViID").val(), d = $("#DmBangLuong").val(); a > 0 & b > 0 & c!=""& c!=null ? window.location.href = "/chot-so-don-vi/thang-" + a + "-nam-" + b + "-donvi-" + c + "-bangluong-" + d : alert("Bạn phải chọn tháng, năm, đơn vị để xem dữ liệu bảng lương!") }), $(".sttKey").off("click").on("click", function (a) { var c = ($(this), $(this).data("thang")), d = $(this).data("nam"), e = $(this).data("donviid"), f = $(this).data("bangid"), g = $(this).data("tinhtrang"), h = ""; h = 1 == g ? "Bạn có muốn mở sổ không?" : "Bạn có muốn khóa sổ không?", confirm(h) && $.ajax({ url: "/ChotSo/changeStatus", data: { thang: c, nam: d, bangid: f, donviid: e, trinhtrang: g }, dataType: "json", type: "POST", success: function (a) { console.log(a), a.status > 0 ? window.location.reload() : (alert("Xảy ra lỗi trong quá trình thự thi. Vui lòng thử lại!"), window.location.reload()) } }) });
$("#chotSo").click(function () {
    if (confirm("Bạn có chắc muốn thực hiện thao tác này?")) {
        var tinhtrang;
        
        if ($('#checkboxChotSo').is(':checked')) tinhtrang = 1;
        else tinhtrang = 0;
        if ($("#drpThang").val() > 0 && $("#drpNam").val() > 0 && $("#DonViID").val() && $("#DmBangLuong").val()) {
            if ($("#DmBangLuong").val() != "NULL") {
                $("#divLoading").show();
                $.ajax({
                    url: "/ChotSo/changeStatusBtnAll",
                    data: { thang: $("#drpThang").val(), nam: $("#drpNam").val(), bangid: $("#DmBangLuong").val(), donviid: $("#DonViID").val(), trinhtrang: tinhtrang },
                    dataType: "json",
                    type: "POST",
                    // here we are get value of selected country and passing same value
                    success: function (resp) {

                        if (resp.status > 0) {
                            alert("Thao tác thành công");
                            window.location.reload();
                        } else {
                            alert("Thao tác thất bại");
                            window.location.reload();
                        }
                    }

                });
            } else {
                alert("Vui lòng chọn bảng lương trước khi chốt sổ!");
            }
       
        } else {
            alert("Vui lòng chọn đầy đủ thông tin để chốt sổ");
        }
       
    }

});
$('#checkboxChotSo').change(function () {
    if ($('#checkboxChotSo').is(':checked')) {
        $('#chotSo').text("Khóa sổ");
    } else {
        $('#chotSo').text("Mở sổ");
    }
    });
