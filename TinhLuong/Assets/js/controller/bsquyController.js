var homeconfig = {
    pageSize:15,
    pageIndex1: 1,
    pageIndex: 1,
    pageIndex2: 1,
    pageIndex3: 1
}

var bsquyController = {
   
    init: function () {
        $("#XoaLuongBS").click(function () {
            if (confirm("Bạn có muốn xóa không?")) {
                if ($("#drpNam").val() > 0  && $("#LoaiBS").val() > 0) {
                    bsquyController.DeleteLuongBoSung($("#drpNam").val(), $("#LoaiBS").val());

                } else {
                    alert("Vui lòng chọn đầy đủ thông tin trước thực hiện");
                }
            }
        });
        $("#TinhLuongBS").click(function () {
            if (confirm("Có muốn thực hiện?")) {
                if ($("#drpNam").val() > 0 && $("#LoaiBS").val() > 0) {
                    bsquyController.TinhLuongBoSung($("#drpNam").val(), $("#LoaiBS").val());

                } else {
                    alert("Vui lòng chọn đầy đủ thông tin trước khi tính toán");
                }
            }
          

        });
        $("#viewSalary").click(function () {
            if ($("#drpNam").val() > 0  && $("#LoaiBS").val() > 0) {
                bsquyController.LoadData_BangThongTin(null,null, $("#drpNam").val(), $("#LoaiBS").val(),false);
                bsquyController.LoadData_BSDV(null, null,  $("#drpNam").val(), $("#LoaiBS").val(), false);
                bsquyController.LoadData_BSLanhDao( $("#drpNam").val(), $("#LoaiBS").val(), false);
                bsquyController.LoadData_NguonBSDV(null, $("#drpNam").val(), $("#LoaiBS").val(), false);
               
            } else {
                alert("Vui lòng chọn đầy đủ thông tin xem thông tin");
            }
        
        });
        $("#drpNam").change(function () {
            $("#LoaiBS").empty();
            $.ajax({
                url: "/TinhLuongBoSungQuy/LoadBS",
                data: { Nam: $("#drpNam").val() },
                dataType: "json",
                type: "POST",
                // here we are get value of selected country and passing same value
                success: function (dao) {
                    // states contains the JSON formatted list
                    // of states passed from the controller
                    $("#LoaiBS").append('<option>--Chọn--</option>')
                    $.each(dao, function (i, khoa) {

                        $("#LoaiBS").append('<option value="' + khoa.Value + '">' +
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
        //bsquyController.loadData();
        bsquyController.registerEvent();
    },
    registerEvent: function () {
        $('.P3Quy_BSDV').off('keypress').on('keypress', function (e) {
            if (e.which == 13) {
                var id = $(this).data('id');
                var value = $(this).val();
                var type = "P3BSDV";
                $.ajax({
                    url: '/TinhLuongBoSungQuy/UpdateBSQuy',
                    type: 'POST',
                    dataType: 'json',
                    data: { ID: id, Value: value, Type: type },
                    success: function (resp) {
                        if (resp.status == false) {
                            alert("Cập nhật thất bại. Vui lòng thử lại");
                        } else {
                            alert("Cập nhật thành công");
                        }
                    }
                })
            }
        });
       
        $('.P2Quy_BangThongTin').off('keypress').on('keypress', function (e) {
            if (e.which == 13) {
                var id = $(this).data('id');
                var value = $(this).val();
                var type = "P2";
                $.ajax({
                    url: '/TinhLuongBoSungQuy/UpdateBSQuy',
                    type: 'POST',
                    dataType: 'json',
                    data: { ID: id, Value: value, Type: type },
                    success: function (resp) {
                        if (resp.status == false) {
                            alert("Cập nhật thất bại. Vui lòng thử lại");
                        } else {
                            alert("Cập nhật thành công");
                        }
                    }
                })
            }
        });
        $('.P3Quy_BangThongTin').off('keypress').on('keypress', function (e) {
            if (e.which == 13) {
                var id = $(this).data('id');
                var value = $(this).val();
                var type = "P3";
                $.ajax({
                    url: '/TinhLuongBoSungQuy/UpdateBSQuy',
                    type: 'POST',
                    dataType: 'json',
                    data: { ID: id, Value: value, Type: type },
                    success: function (resp) {
                        if (resp.status == false) {
                            alert("Cập nhật thất bại. Vui lòng thử lại");
                        } else {
                            alert("Cập nhật thành công");
                        }
                    }
                })
            }
        });
        $('.GiamTruQuyLuong_BSDV').off('keypress').on('keypress', function (e) {
            if (e.which == 13) {
                var id = $(this).data('id');
                var value = $(this).val();
                var type = "GIAMTRUQUYLUONG";
                $.ajax({
                    url: '/TinhLuongBoSungQuy/UpdateBSQuy',
                    type: 'POST',
                    dataType: 'json',
                    data: { ID: id, Value: value, Type: type },
                    success: function (resp) {
                        if (resp.status == false) {
                            alert("Cập nhật thất bại. Vui lòng thử lại");
                        } else {
                            alert("Cập nhật thành công");
                        }
                    }
                })
            }
        });
    },
    FindTable:function(){
        $("#tblBSDV").DataTable();
        $("#example2").DataTable();
        $("#example1").DataTable();
        $("#example22").DataTable();
    },
    TinhLuongBoSung: function ( Nam, LoaiBS) {
        $("#divLoading").show();
        $.ajax({
            url: '/TinhLuongBoSungQuy/TinhLuongBoSung',
            type: 'POST',
            dataType: 'json',
            data: {
                 Nam: Nam, LoaiBS: LoaiBS
            },
            success: function (resp) {
                window.location.reload();
            }
        });
    },
    DeleteLuongBoSung: function ( Nam, LoaiBS) {
        $("#divLoading").show();
        $.ajax({
            url: '/TinhLuongBoSungQuy/DeleteLuongBoSung',
            type: 'POST',
            dataType: 'json',
            data: {
                Nam: Nam, LoaiBS: LoaiBS
            },
            success: function (resp) {
                window.location.reload();
            }
        });
    },
    LoadData_BangThongTin: function (value,type, Nam, LoaiBS,changeSize) {
        $("#divLoading").show();
        $.ajax({
            url: '/TinhLuongBoSungQuy/LoadData_BangThongTin',
            type: 'GET',
            dataType: 'json',
            data:{
              value:value,type:type, Nam:Nam,LoaiBS:LoaiBS,  page:homeconfig.pageIndex,pageSize:homeconfig.pageSize
            },
            success: function (resp) {

                if (resp.status) {
                    var data = resp.dataBangThongTin;
                    var html = "";
                   
                    var template = $("#BangThongTin").html();
                    
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            STT: item.STT,
                            Quy: item.Quy,
                            Nam: item.Nam,
                            DonViChaID: item.DonViChaID,
                            DonViID: item.DonViID,
                            NhanSuID: item.NhanSuID,
                            HoTen: item.HoTen,
                            P1TB_Quy: item.P1TB_Quy,
                            P2TB_Quy: item.P2TB_Quy,
                            P3TB_Quy: item.P3TB_Quy,
                            P1P2TB_Quy: item.P1P2TB_Quy,
                            P1P2P3TB_Quy: item.P1P2P3TB_Quy,
                            TongTienBoSung: item.TongTienBoSung,
                            SoTaiKhoan: item.SoTaiKhoan,
                            LoaiBS: item.LoaiBS
                        });

                    });
                   // $("#tbodyBSDV1").html(html2);
                  
                    $("#tbodyBangThongTin").html(html);
                    $("#example1").DataTable();
                    //if (resp.totalBangThongTin>0) {
                    //    bsquyController.paging(resp.totalBangThongTin, function () {
                    //        bsquyController.LoadData_BangThongTin(value,type, Nam, LoaiBS);
                    //    },changeSize);
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
    LoadData_NguonBSDV: function (search, Nam, LoaiBS,changeSize) {
        $("#divLoading").show();
        $.ajax({
            url: '/TinhLuongBoSungQuy/LoadData_NguonBSDV',
            type: 'GET',
            dataType: 'json',
            data: {
               search:search,Nam: Nam, LoaiBS: LoaiBS, page: homeconfig.pageIndex1, pageSize: homeconfig.pageSize
            },
            success: function (resp) {

                if (resp.status) {
                    var data1 = resp.dataNguonBSDonVi;
                    var html1 = "";
                    var template1 = $("#NguonBSDV").html();
                  
                    $.each(data1, function (i, item) {
                        html1 += Mustache.render(template1, {
                            STT: item.STT,
                            Quy: item.Quy,
                            Nam: item.Nam,
                            DonViID: item.DonViID,
                            P3Quy: item.P3Quy,
                            DiemP1: item.DiemP1,
                            P1P3: item.P1P3,
                            NguonP3DV: item.NguonP3DV,
                            GiamTruQuyLuong: item.GiamTruQuyLuong,
                            NguonP3SauGiamTru: item.NguonP3SauGiamTru,
                            LoaiBS: item.LoaiBS
                        });

                    });
                  
                    // $("#tbodyBSDV1").html(html2);
                    $("#tbodyBSDV").html(html1);
                    $("#tblBSDV").DataTable();
                    //if (resp.totalNguonBSDonVi > 0) {
                    //    bsquyController.paging1(resp.totalNguonBSDonVi, function () {
                    //        bsquyController.LoadData_NguonBSDV(search,Nam, LoaiBS);
                    //    },changeSize);
                    //} else if (resp.totalNguonBSDonVi == 0) {
                    //    $('#pagination1').empty();
                    //    $('#pagination1').removeData("twbs-pagination");
                    //    $('#pagination1').unbind('page');
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
    LoadData_BSDV: function (value,type, Nam, LoaiBS,changeSize) {
        $("#divLoading").show();
        $.ajax({
            url: '/TinhLuongBoSungQuy/LoadData_BSDV',
            type: 'GET',
            dataType: 'json',
            data: {
               value:value,type:type, Nam: Nam, LoaiBS: LoaiBS, page: homeconfig.pageIndex2, pageSize: homeconfig.pageSize
            },
            success: function (resp) {

                if (resp.status) {
                    var data2 = resp.dataBSDonVi;
                    var html2 = "";
                    var template2 = $("#BSDonVi").html();
                    $.each(data2, function (i, item) {
                        html2 += Mustache.render(template2, {
                            STT: item.STT,
                            Quy: item.Quy,
                            Nam: item.Nam,
                            DonViID: item.DonViID,
                            DonViChaID: item.DonViChaID,
                            P1: item.P1,
                            P1P2: item.P1P2,
                            P3: item.P3,
                            NguonP3BoSung: item.NguonP3BoSung,
                            TenDonVi: item.TenDonVi,
                            LoaiBS: item.LoaiBS
                        });

                    });
                   
                    $("#tbodyBSDV1").html(html2);
                    $("#example2").DataTable();
                    //if (resp.totalBSDonVi > 0) {
                    //    bsquyController.paging2(resp.totalBSDonVi, function () {
                    //        bsquyController.LoadData_BSDV(value,type,Nam, LoaiBS);
                    //    }, changeSize);
                    //} else if (resp.totalBSDonVi == 0) {
                    //    $('#pagination2').empty();
                    //    $('#pagination2').removeData("twbs-pagination");
                    //    $('#pagination2').unbind('page');
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
    LoadData_BSLanhDao: function ( Nam, LoaiBS,changeSize) {
        $("#divLoading").show();
        $.ajax({
            url: '/TinhLuongBoSungQuy/LoadData_BSLanhDao',
            type: 'GET',
            dataType: 'json',
            data: {
                Nam: Nam, LoaiBS: LoaiBS, page: homeconfig.pageIndex3, pageSize: homeconfig.pageSize
            },
            success: function (resp) {

                if (resp.status) {
                    var data2 = resp.dataBSDonVi;
                    var html2 = "";
                    var template2 = $("#BSLanhDao").html();
                    $.each(data2, function (i, item) {
                        html2 += Mustache.render(template2, {
                            STT: item.STT,
                            Quy: item.Quy,
                            Nam: item.Nam,
                            DonViID: item.DonViID,
                            DonViChaID: item.DonViChaID,
                            NhanSuID: item.NhanSuID,
                            TienLuongKHP3Quy: item.TienLuongKHP3Quy,
                            P3DonVi: item.P3DonVi,
                            GiamTruTienP3Quy: item.GiamTruTienP3Quy ,
                            BoSungP3Quy: item.BoSungP3Quy,
                            HoTen:item.HoTen,
                            LoaiBS: item.LoaiBS
                        });

                    });

                    $("#tbodyBSLanhDao").html(html2);
                    $("#example22").DataTable();
                    //if (resp.totalBSDonVi > 0) {
                    //    bsquyController.paging3(resp.totalBSDonVi, function () {
                    //        bsquyController.LoadData_BSLanhDao( Nam, LoaiBS);
                    //    }, changeSize);
                    //} else if (resp.totalBSDonVi == 0) {
                    //    $('#pagination3').empty();
                    //    $('#pagination3').removeData("twbs-pagination");
                    //    $('#pagination3').unbind('page');
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
    paging: function (totalRow, callback,changeSize) {
        if (changeSize == true || totalRow == 0) {
            $('#pagination').empty();
            $('#pagination').removeData("twbs-pagination");
            $('#pagination').unbind('page');
        }
        var totalPage = Math.ceil(totalRow / homeconfig.pageSize);
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            visiblePages: 5,
            first: 'Đầu',
            next: 'Tiếp',
            prev: 'Trước',
            last:'Cuối',
            onPageClick: function (event, page) {
                homeconfig.pageIndex = page;
                setTimeout(callback, 20);
            }
        });


    },
    paging1: function (totalRow, callback, changeSize) {
        if ( changeSize == true||totalRow==0) {
            $('#pagination1').empty();
            $('#pagination1').removeData("twbs-pagination");
            $('#pagination1').unbind('page');
        }
        var totalPage = Math.ceil(totalRow / homeconfig.pageSize);
        $('#pagination1').twbsPagination({
            totalPages: totalPage,
            visiblePages: 5,
            first: 'Đầu',
            next: 'Tiếp',
            prev: 'Trước',
            last:'Cuối',
            onPageClick: function (event, page) {
                homeconfig.pageIndex1 = page;
                setTimeout(callback, 20);
            }
        });
    },
    paging2: function (totalRow, callback, changeSize) {
        if ( changeSize == true || totalRow == 0) {
            $('#pagination2').empty();
            $('#pagination2').removeData("twbs-pagination");
            $('#pagination2').unbind('page');
        }
        var totalPage = Math.ceil(totalRow / homeconfig.pageSize);
        $('#pagination2').twbsPagination({
            totalPages: totalPage,
            visiblePages: 5,
            first: 'Đầu',
            next: 'Tiếp',
            prev: 'Trước',
            last: 'Cuối',
            onPageClick: function (event, page) {
                homeconfig.pageIndex2 = page;
                setTimeout(callback, 20);
            }
        });
    },
    paging3: function (totalRow, callback, changeSize) {
        if (changeSize == true || totalRow == 0) {
            $('#pagination3').empty();
            $('#pagination3').removeData("twbs-pagination");
            $('#pagination3').unbind('page');
        }
        var totalPage = Math.ceil(totalRow / homeconfig.pageSize);
        $('#pagination3').twbsPagination({
            totalPages: totalPage,
            visiblePages: 5,
            first: 'Đầu',
            next: 'Tiếp',
            prev: 'Trước',
            last: 'Cuối',
            onPageClick: function (event, page) {
                homeconfig.pageIndex3 = page;
                setTimeout(callback, 20);
            }
        });
    }
}
bsquyController.init();

function searchCaNhan(e, elm, type) {
    if (e.which == 13) {
        var value = $(elm).val();
        bsquyController.LoadData_BangThongTin(value, type, $("#drpNam").val(), $("#LoaiBS").val(),true);
    }
};
function searchToTram(e, elm, type) {
    if (e.which == 13) {
        var value = $(elm).val();
        bsquyController.LoadData_BSDV(value,type, $("#drpNam").val(), $("#LoaiBS").val(),true);
    }
};
///
function searchBSDV(e, elm) {
    if (e.which == 13) {
        var value = $(elm).val();
        bsquyController.LoadData_NguonBSDV(value, $("#drpNam").val(), $("#LoaiBS").val(),true);
    }
};
function update_bangThongTin(e, elm, type) {
    if (e.which == 13) {
        var id = $(elm).data('id');
        var value = $(elm).val();
        $.ajax({
            url: '/TinhLuongBoSungQuy/UpdateBSQuy',
            type: 'POST',
            dataType: 'json',
            data: { ID: id, Value: value, Type: type },
            success: function (resp) {
                if (resp.status == false) {
                    alert("Cập nhật thất bại. Vui lòng thử lại");
                } else {
                    alert("Cập nhật thành công");
                }
            }
        })
    }
};
function update_SoTK(e,elm) {
    if (e.which == 13) {
        var id = $(elm).data('id');
        var value = $(elm).val();
        $.ajax({
            url: '/TinhLuongBoSungQuy/UpdateBSQuy',
            type: 'POST',
            dataType: 'json',
            data: { ID: id, Value: value },
            success: function (resp) {
                if (resp.status == false) {
                    alert("Cập nhật thất bại. Vui lòng thử lại");
                } else {
                    alert("Cập nhật thành công");
                }
            }
        })
    }
}