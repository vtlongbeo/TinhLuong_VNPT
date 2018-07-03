var bsquyController = {
    init: function () {
        $("#viewChotSo").click(function () {

            bsquyController.LoadData();
        });
      
    },
    registerEvent: function () {
        $(".btnActive").click(function () {
            if (confirm("Có muốn thực hiện")) {
                var nam = $(this).data('nam');
                var loaibs = $(this).data('loaibs')
                $.ajax({
                    url: '/ChotSoBS/UpdateChotSo',
                    type: 'POST',
                    dataType: 'json',
                    data: {
                        Nam: nam, LoaiBS: loaibs
                    },
                    success: function (resp) {

                        var data = resp.data;
                        alert(data.OutputString)
                       
                    }
                });
                bsquyController.LoadData();
            }
          
        });
    },
    LoadData: function () {
        var nam = $("#drpNam").val();
        if (nam) {
            $("#divLoading").show();
            $.ajax({
                url: '/ChotSoBS/GetListChotSo',
                type: 'GET',
                dataType: 'json',
                data: {
                    Nam: nam
                },
                success: function (resp) {

                    var data = resp.data;
                    var html = "";

                    var template = $("#ChotSoBS").html();

                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            STT: item.STT,
                            Nam: item.Nam,
                            LoaiBS: item.LoaiBS,
                            DienGiai: item.DienGiai,
                            TrangThai: item.Active == true ? "<button data-nam=" + item.Nam + " data-loaibs=" + item.LoaiBS + " class=\"btn btn-danger btnActive\">Đang khóa</button>" : "<button data-nam=" + item.Nam + " data-loaibs=" + item.LoaiBS + " class=\"btn btn-primary btnActive\">Đang mở</button>"
                        });

                    });
                    // $("#tbodyBSDV1").html(html2);

                    $("#tbodyChotSo").html(html);
                    $("#tblBSDV").DataTable();
                    $("#divLoading").hide();
                    bsquyController.registerEvent();
                }
            });
        } else {
            alert("Vui lòng chọn năm trước khi xem dữ liệu");
        }
    }
}
bsquyController.init();



