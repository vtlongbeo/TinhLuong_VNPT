var KHLuongTamUng = {

    init: function () {
        $("#drpNam").change(function () {
            $("#LanhDao").empty();
            $.ajax({
                url: "/TinhLuongBoSungQuy/LoadLanhDao",
                data: { Nam: $("#drpNam").val() },
                dataType: "json",
                type: "POST",
                // here we are get value of selected country and passing same value
                success: function (dao) {
                    // states contains the JSON formatted list
                    // of states passed from the controller
                    $("#LanhDao").append('<option>--Chọn--</option>')
                    $.each(dao, function (i, khoa) {

                        $("#LanhDao").append('<option value="' + khoa.Value + '">' +
                             khoa.Text + '</option>');
                        // here we are adding option for States

                    });
                },
                error: function (ex) {
                    alert('Failed to retrieve states.' + ex);
                }
            });

            return false;
        });
        $("#viewLuongKH").click(function () {
           
                if ($("#drpNam").val() > 0) {
                    KHLuongTamUng.LoadData();

                } else {
                    alert("Vui lòng chọn năm để xem dữ liệu");
                }
            

        });
        $("#AddNewLuongKH").click(function () {

            if ($("#LanhDao").val() > 0) {
                KHLuongTamUng.AddNew($("#LanhDao").val(), $("#drpNam").val());

            } else {
                alert("Vui lòng chọn lãnh đạo trước khi thêm dữ liệu");
            }


        });
      
        $("#addLuongKH").click(function () {

            if ($("#drpNam").val() > 0) {
                $("#AddNew").modal('show');

            } else {
                alert("Vui lòng chọn năm trước khi thêm mới dữ liệu");
            }


        });
        $("#UdpateLuongKH").click(function () {
            if (confirm("Có muốn thực hiện?")) {
                if ($("#LuongKHTamUng").val() >= 0) {
                    KHLuongTamUng.SaveData();
                    $("#myModal").modal('hide');

                } else {
                    alert("Vui lòng nhập Lương KH tạm ứng");
                }
            }

        });
        KHLuongTamUng.registerEvent();
    },
    registerEvent: function () {
        //$('.btn-edit').off('click').on('click', function (e) {
        //    var id = $(this).data('id');
        //    $("#myModal").modal('show');
        //    KHLuongTamUng.LoadDataID(id);
        //});
        //$(".DeleteLuongKH").click(function () {
        //    if (confirm("Có muốn thực hiện?")) {
        //        var id = $(this).data('id');
        //        KHLuongTamUng.Delete(id)
        //    }
        //});
    },

    LoadFind: function(){
           
            //$('#example1').DataTable({
            //    "paging": true,
            //    "lengthChange": true,
            //    "searching": true,
            //    "ordering": true,
            //    "info": true,
            //    "autoWidth": true
            //});
    },
    AddNew:function(lanhdao,nam){
        var salary = $("#LuongKHTamUng").val();
        var isActive = $("#IsActive").prop('checked');
        var id = $("#ID").val();
        $.ajax({
            url: '/TinhLuongBoSungQuy/AddNewLanhDao',
            type: 'POST',
            dataType: 'json',
            data: {
                LanhDao: lanhdao, Nam: nam
            },
            success: function (resp) {

                if (resp.status) {
                    alert("Thêm mới thành công");
                    $("#AddNew").modal('hide');
                    KHLuongTamUng.LoadData();
                }
                else {
                    alert("Xảy ra lỗi thực thi hoặc Nhân sự đã tồn tại trong bảng!");
                }
            }
        });

    },
    Delete: function (id) {
        $.ajax({
            url: '/TinhLuongBoSungQuy/DeleteLanhDao',
            type: 'POST',
            dataType: 'json',
            data: {
                ID: id
            },
            success: function (resp) {

                if (resp.status) {
                    alert("Xóa thành công");
                    KHLuongTamUng.LoadData();
                }
                else {
                    alert("Xảy ra lỗi thực thi. Vui lòng thử lại!");
                }
            }
        });

    },
    LoadData: function(){
            $("#divLoading").show();
            $.ajax({
                url: '/TinhLuongBoSungQuy/LoadDataLuongKHTamUng',
                type: 'GET',
                dataType: 'json',
                data: {
                    Nam: $("#drpNam").val()
                },
                success: function (resp) {

                    if (resp.status) {
                        var data = resp.data;
                        var html = "";

                        var template = $("#KhTamUng").html();

                        $.each(data, function (i, item) {
                            html += Mustache.render(template, {
                                STT: item.STT,
                                Nam: item.Nam,
                                DonViID: item.DonViID,
                                NhanSuID: item.NhanSuID,
                                HoTen: item.HoTen,
                                LuongKHTamUng: item.LuongKHTamUng,
                                TenDonVi: item.TenDonVi,
                                IsActive: item.IsActive == true ? "<span class=\"label label-success\">Đang dùng</span>" : "<span class=\"label label-danger\">Đang khóa</span>"
                            });

                        });
                        // $("#tbodyBSDV1").html(html2);

                        $("#tbodyKHTamUng").html(html);
                        if (data.length > 0) {
                            $("#example1_info").show();
                            $("#example1_paginate").show();
                            $("#example1").DataTable();
                        } else {
                            $("#example1_info").hide();
                            $("#example1_paginate").hide();
                        }
                        KHLuongTamUng.registerEvent();
                        //if (resp.totalBangThongTin > 0) {
                        //    bsquyController.paging(resp.totalBangThongTin, function () {
                        //        bsquyController.LoadData_BangThongTin(value, type, Nam, LoaiBS);
                        //    }, changeSize);
                        //} else if (resp.totalBangThongTin == 0) {
                        //    $('#pagination').empty();
                        //    $('#pagination').removeData("twbs-pagination");
                        //    $('#pagination').unbind('page');
                        //}

                        //if (resp.totalBSDonVi > 0) {
                        //    bsquyController.paging2(resp.totalBSDonVi, function () {
                        //        bsquyController.loadData(Quy, Nam, LoaiBS);
                        //    });
                        //} else if (resp.totalBSDonVi == 0) {
                        //    $("#pagination2").hide();
                        //}
                        $("#divLoading").hide();
                    }
                    else {
                        alert("Gặp vấn đề khi tải dữ liệu, Vui lòng thử lại!");
                        window.location.reload();
                    }
                }
            });
    },
    LoadDataID: function (ID) {
        $.ajax({
            url: '/TinhLuongBoSungQuy/GetLuongKHTamUng_ID',
            type: 'GET',
            dataType: 'json',
            data: {
                ID:ID
            },
            success: function (resp) {

                if (resp.status) {
                    var data = resp.data;
                    $("#ID").val(ID);
                    $("#HoTen").val(data[0].HoTen);
                    $("#LuongKHTamUng").val(data[0].LuongKHTamUng);
                    $("#IsActive").prop("checked", data[0].IsActive)

                    //var html = "";

                    //var template = $("#KhTamUng").html();

                    //$.each(data, function (i, item) {
                    //    html += Mustache.render(template, {
                    //        STT: item.STT,
                    //        Nam: item.Nam,
                    //        DonViID: item.DonViID,
                    //        NhanSuID: item.NhanSuID,
                    //        HoTen: item.HoTen,
                    //        LuongKHTamUng: item.LuongKHTamUng,
                    //        TenDonVi: item.TenDonVi,
                    //        IsActive: item.IsActive == true ? "<span class=\"label label-success\"><a href=\"\" class=\"sttKey\" data-tinhtrang=\"" + item.IsActive + "\" data-nhansuid=\"" + item.NhanSuID + "\" data-nam=\"" + item.Nam + "\" data-donviid=\"" + item.DonViID + "\" style=\"color:white;\">Đang dùng </a></span>" : "<span class=\"label label-danger\"><a href=\"\" class=\"sttKey\" data-tinhtrang=\"" + item.IsActive + "\" data-nhansuid=\"" + item.NhanSuID + "\" data-nam=\"" + item.Nam + "\" data-donviid=\"" + item.DonViID + "\" style=\"color:white;\">Đang khóa </a></span>"
                    //    });

                    //});
                    //// $("#tbodyBSDV1").html(html2);

                    //$("#tbodyKHTamUng").html(html);
                    //KHLuongTamUng.registerEvent();
                    //if (resp.totalBangThongTin > 0) {
                    //    bsquyController.paging(resp.totalBangThongTin, function () {
                    //        bsquyController.LoadData_BangThongTin(value, type, Nam, LoaiBS);
                    //    }, changeSize);
                    //} else if (resp.totalBangThongTin == 0) {
                    //    $('#pagination').empty();
                    //    $('#pagination').removeData("twbs-pagination");
                    //    $('#pagination').unbind('page');
                    //}

                    //if (resp.totalBSDonVi > 0) {
                    //    bsquyController.paging2(resp.totalBSDonVi, function () {
                    //        bsquyController.loadData(Quy, Nam, LoaiBS);
                    //    });
                    //} else if (resp.totalBSDonVi == 0) {
                    //    $("#pagination2").hide();
                    //}
                    $("#divLoading").hide();
                }
                else {
                    alert("Gặp vấn đề khi tải dữ liệu, Vui lòng thử lại!");
                    window.location.reload();
                }
            }
        });
    },
    SaveData: function () {
        var salary = $("#LuongKHTamUng").val();
        var isActive = $("#IsActive").prop('checked');
        var id = $("#ID").val();
            $.ajax({
                url: '/TinhLuongBoSungQuy/UpdateLuongKH',
                type: 'POST',
                dataType: 'json',
                data: {
                    ID: id,LuongKHTamUng:salary,IsActive:isActive
                },
                success: function (resp) {

                    if (resp.status) {
                        KHLuongTamUng.LoadData();
                    }
                    else {
                        alert("Gặp vấn đề khi tải dữ liệu, Vui lòng thử lại!");
                    }
                }
            });

    }
}
KHLuongTamUng.init();

function update(e, elm) {
    var id = $(elm).data('id');
    $("#myModal").modal('show');
    KHLuongTamUng.LoadDataID(id);
};
function dele(e, elm) {
    if (confirm("Có chắc chắn muốn xóa?")) {
        var id = $(elm).data('id');
        KHLuongTamUng.Delete(id);
    }
  
};

