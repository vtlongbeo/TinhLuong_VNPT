
$(function () {
    $("#btnImportSoLieu").click(function () {
        var a = $("#drpThang").val(),
            b = $("#drpNam").val(),
            c = $("#DonViID").val();
        c == '' ? c = 'VTT' : c = $("#DonViID").val()
        a > 0 & b > 0 ? window.location.href = "/cham-cong-don-vi/DonViID-" + c + "-thang-" + a + "-nam-" + b : alert("Bạn phải chọn đơn vị, tháng và năm để xem dữ liệu chấm công!")
    });
    $("#btnInChamCong").click(function () {
        var a = $("#drpThang").val(),
            b = $("#drpNam").val(),
            c = $("#DonViID").val();
        confirm("Bạn muốn xem bảng chấm công ?") && ($("#drpThang").val() > 0 && $("#drpThang").val() > 0 ?
        window.open("/ChamCong/BaoCaoChamCong?thang=" + $("#drpThang").val() + "&nam=" + $("#drpNam").val() + "&dv=" + $("#DonViID").val().replace("-", "_") + "&tram=NULL&trucdem=0", "_blank", "scrollbars=1,resizable=1,height=500,width=700") :
        alert("Phải chọn tháng và năm để xem danh sách tổng hợp"))
    });

    $("#btnInChamTrucDem").click(function () {
        confirm("Bạn muốn xem bảng chấm công ?") && ($("#drpThang").val() > 0 && $("#drpThang").val() > 0 ?
        window.open("/ChamCong/BaoCaoChamCong?thang=" + $("#drpThang").val() + "&nam=" + $("#drpNam").val() + "&dv=" + $("#DonViID").val().replace("-", "_") + "&tram=NULL&trucdem=1", "_blank", "scrollbars=1,resizable=1,height=500,width=700") :
        alert("Phải chọn tháng và năm để xem danh sách tổng hợp"))
    });
   
});