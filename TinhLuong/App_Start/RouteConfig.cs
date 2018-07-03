using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TinhLuong
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            ///role group
            routes.MapRoute(
            "role-group",
       "role-group",
     new
     {
         controller = "RoleGroup",
         action = "Index",

     },
     namespaces: new[] { "TinhLuong.Controllers" }
     );
   ////////////////////////DONDICHMANGCAP
            routes.MapRoute(
        "import-dondichcap",
       "import-dondichcap",
      new
      {
          controller = "ImportDonDichMangCapDong",
          action = "Index",

      },
      namespaces: new[] { "TinhLuong.Controllers" }
      );


                routes.MapRoute(
              "import-dondichcap/docfile",
         "import-dondichcap/doc-file",
        new
        {
            controller = "ImportDonDichMangCapDong",
            action = "Success",

        },
        namespaces: new[] { "TinhLuong.Controllers" }
        );


            #region Cham cong

            routes.MapRoute(
            "cham-cong-donvi",
       "cham-cong-donvi",
      new
      {
          controller = "ChamCong",
          action = "Index",

      },
      namespaces: new[] { "TinhLuong.Controllers" }
      );

            routes.MapRoute(
            "bao-cao-chamcong",
       "bao-cao-chamcong",
      new
      {
          controller = "ChamCong",
          action = "BaoCaoChamCong",

      },
      namespaces: new[] { "TinhLuong.Controllers" }
      );

            routes.MapRoute(
                "ChamCongCaNhan",
                   "cham-cong-ca-nhan/{metatitle2}-{NhanSuID}-{metatitle}-{Thang}-{metatitle1}-{Nam}",
                 new
                 {
                     controller = "ChamCong",
                     action = "ChiTietChamCong",
                     NhanSuID = UrlParameter.Optional,
                     Thang = UrlParameter.Optional,
                     Nam = UrlParameter.Optional,
                     

                 },
                 namespaces: new[] { "TinhLuong.Controllers" }
                 );


            routes.MapRoute(
               "ChamCongTrucDem",
                  "cham-cong-truc-dem/{metatitle2}-{NhanSuID}-{metatitle}-{Thang}-{metatitle1}-{Nam}",
                new
                {
                    controller = "ChamCong",
                    action = "ChiTietTrucDem",
                    NhanSuID = UrlParameter.Optional,
                    Thang = UrlParameter.Optional,
                    Nam = UrlParameter.Optional,


                },
                namespaces: new[] { "TinhLuong.Controllers" }
                );


            routes.MapRoute(
                "chamcongdonvidetail",
                   "cham-cong-don-vi/{metatitle2}-{DonViID}-{metatitle}-{Thang}-{metatitle1}-{Nam}",
                 new
                 {
                     controller = "ChamCong",
                     action = "IndexDetail",
                     DonVi = UrlParameter.Optional,
                     Thang = UrlParameter.Optional,
                     Nam = UrlParameter.Optional,
                     

                 },
                 namespaces: new[] { "TinhLuong.Controllers" }
                 );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             "cham-cong-don-vi",
                "cham-cong-don-vi",
              new
              {
                  controller = "ChamCong",
                  action = "Index",
                  Thang = UrlParameter.Optional,
                  Nam = UrlParameter.Optional,

              },
              namespaces: new[] { "TinhLuong.Controllers" }
              );
            #endregion

            //khuyến khích lắp đặt
            #region Khuyen khich lap dat
            routes.MapRoute(
               "TinhLuongKhuyenKhichLapDat",
                  "KKLD",
                new
                {
                    controller = "KKLD",
                    action = "Index",

                },
                namespaces: new[] { "TinhLuong.Controllers" }
                );

            routes.MapRoute(
                "TinhLuongKhuyenKhichLapDatThang",
                 "KKLD/{metatitle}-{Thang}-{metatitle1}-{Nam}",
               new
               {
                   controller = "KKLD",
                   action = "IndexDetail",
                   Thang = UrlParameter.Optional,
                   Nam = UrlParameter.Optional,

               },
               namespaces: new[] { "TinhLuong.Controllers" }
               );

            routes.MapRoute(
                "XuatExcelChITiet",
                 "KKLD/ExportToExcel/{metatitle}-{Thang}-{metatitle1}-{Nam}-{metatitle2}-{Type}",
               new
               {
                   controller = "KKLD",
                   action = "ExportToExcel",
                   Thang = UrlParameter.Optional,
                   Nam = UrlParameter.Optional,
                   Type = UrlParameter.Optional,

               },
               namespaces: new[] { "TinhLuong.Controllers" }
               );


            #endregion


            #region Giam tru bao hong 3 lan
            routes.MapRoute(
               "baohong3lan",
                  "baohong3lan",
                new
                {
                    controller = "BaoHong3Lan",
                    action = "Index",

                },
                namespaces: new[] { "TinhLuong.Controllers" }
                );


            routes.MapRoute(
               "baohong3lanThang",
                "baohong3lan/{metatitle}-{Thang}-{metatitle1}-{Nam}",
              new
              {
                  controller = "BaoHong3Lan",
                  action = "IndexDetail",
                  Thang = UrlParameter.Optional,
                  Nam = UrlParameter.Optional,

              },
              namespaces: new[] { "TinhLuong.Controllers" }
              );


            routes.MapRoute(
                "XuatExcelChITietBaoHong",
                 "baohong3lan/ExportToExcel/{metatitle}-{Thang}-{metatitle1}-{Nam}-{metatitle2}-{Type}",
               new
               {
                   controller = "BaoHong3Lan",
                   action = "ExportToExcel",
                   Thang = UrlParameter.Optional,
                   Nam = UrlParameter.Optional,
                   Type = UrlParameter.Optional,

               },
               namespaces: new[] { "TinhLuong.Controllers" }
               );


            #endregion


            #region Cắt hủy  trong tháng
            routes.MapRoute(
              "cathuy",
                 "tbcathuy",
               new
               {
                   controller = "TBCatHuy",
                   action = "Index",

               },
               namespaces: new[] { "TinhLuong.Controllers" }
               );

            routes.MapRoute(
               "cathuythang",
                "tbcathuy/{metatitle}-{Thang}-{metatitle1}-{Nam}",
              new
              {
                  controller = "TBCatHuy",
                  action = "IndexDetail",
                  Thang = UrlParameter.Optional,
                  Nam = UrlParameter.Optional,

              },
              namespaces: new[] { "TinhLuong.Controllers" }
              );

            routes.MapRoute(
                "XuatExcelCatHuy",
                 "tbcathuy/ExportToExcel/{metatitle}-{Thang}-{metatitle1}-{Nam}-{metatitle2}-{Type}",
               new
               {
                   controller = "TBCatHuy",
                   action = "ExportToExcel",
                   Thang = UrlParameter.Optional,
                   Nam = UrlParameter.Optional,
                   Type = UrlParameter.Optional,

               },
               namespaces: new[] { "TinhLuong.Controllers" }
               );


            #endregion

            #region Import Chay May Phat Dien
            routes.MapRoute(
            "ImportChayMPD",
              "ImportChayMPD",
             new
             {
                 controller = "ImportChayMPD",
                 action = "Index",

             },
             namespaces: new[] { "TinhLuong.Controllers" }
             );

            routes.MapRoute(
                     "ImportChayMPD/docfile",
                "ImportChayMPD/doc-file",
               new
               {
                   controller = "ImportChayMPD",
                   action = "Success",

               },
               namespaces: new[] { "TinhLuong.Controllers" }
               );

            #endregion


            #region import luong lap dat splitter

                 routes.MapRoute(
                           "import-ld-splitter",
                      "import-ld-splitter",
                     new
                     {
                         controller = "ImportSpitter",
                         action = "Index",

                     },
                     namespaces: new[] { "TinhLuong.Controllers" }
                     );


                            routes.MapRoute(
                          "import-ld-splitter/docfile",
                     "import-ld-splitter/doc-file",
                    new
                    {
                        controller = "ImportSpitter",
                        action = "Success",

                    },
                    namespaces: new[] { "TinhLuong.Controllers" }
                    );

            #endregion

           



            routes.MapRoute(
           "importphlapdat",
      "import-phlapdat",
     new
     {
         controller = "ImportPHLD",
         action = "Index",

     },
     namespaces: new[] { "TinhLuong.Controllers" }
     );


            routes.MapRoute(
          "importphlapdat/docfile",
     "import-phlapdat/doc-file",
    new
    {
        controller = "ImportPHLD",
        action = "Success",

    },
    namespaces: new[] { "TinhLuong.Controllers" }
    );



            



            ///import mll tb
            /// 
            routes.MapRoute(
            "import-mlltb",
       "import-mlltb",
      new
      {
          controller = "ImportMLLTB",
          action = "Index",

      },
      namespaces: new[] { "TinhLuong.Controllers" }
      );
            routes.MapRoute(
    "import-mlltb-docfile",
    "import-mlltb/doc-file",
    new
    {
        controller = "ImportMLLTB",
        action = "Success",

    },
   

        namespaces: new[] { "TinhLuong.Controllers" }
    );

            ///lương ứng cưu
            /// 
            routes.MapRoute(
            "import-ungcuu",
       "import-ungcuu",
      new
      {
          controller = "ImportLuongUngCuu",
          action = "Index",

      },
      namespaces: new[] { "TinhLuong.Controllers" }
      );
            routes.MapRoute(
    "import-ungcuu-docfile",
    "import-ungcuu/doc-file",
    new
    {
        controller = "ImportLuongUngCuu",
        action = "Success",

    },
    namespaces: new[] { "TinhLuong.Controllers" }
    );

            ///import giamrtru baohong
            /// 
            routes.MapRoute(
            "import-baohong",
       "import-baohong",
      new
      {
          controller = "ImportBaoHongGiamTru",
          action = "Index",

      },
      namespaces: new[] { "TinhLuong.Controllers" }
      );
            routes.MapRoute(
    "import-baohong-docfile",
    "import-baohong/doc-file",
    new
    {
        controller = "ImportBaoHongGiamTru",
        action = "Success",

    },
    namespaces: new[] { "TinhLuong.Controllers" }
    );


            ///lương bs
            /// 
            routes.MapRoute(
            "import-bs",
       "import-bs",
      new
      {
          controller = "ImportTienLuongBS",
          action = "Index",

      },
      namespaces: new[] { "TinhLuong.Controllers" }
      );
            routes.MapRoute(
    "import-bs-docfile",
    "import-bs/doc-file",
    new
    {
        controller = "ImportTienLuongBS",
        action = "Success",

    },
    namespaces: new[] { "TinhLuong.Controllers" }
    );
            ///lấy dữ liệu đầu tháng
            ///
            /// 
            routes.MapRoute(
           "lay-du-lieu-dau-thang",
      "lay-du-lieu-thang",
     new
     {
         controller = "LayDuLieuDauThang",
         action = "Index",
         GroupID = UrlParameter.Optional,

     },
     namespaces: new[] { "TinhLuong.Controllers" }
     );
            ///Luowng khtamung
            /// 
            routes.MapRoute(
              "luong-kh-tamung",
         "luong-kh-tamung",
        new
        {
            controller = "TinhLuongBoSungQuy",
            action = "LuongKHTamUng",
            GroupID = UrlParameter.Optional,

        },
        namespaces: new[] { "TinhLuong.Controllers" }
        );
            ///Du lieu bo sung quy
            /// 
            routes.MapRoute(
              "dulieu-bsquy",
         "dulieu-bsq",
        new
        {
            controller = "TinhLuongBoSungQuy",
            action = "Detail",
            GroupID = UrlParameter.Optional,

        },
        namespaces: new[] { "TinhLuong.Controllers" }
        );
            ///Du lieu bo sung quy
            /// 
            routes.MapRoute(
              "tinh-luong-bsq",
         "tinh-luong-bsq",
        new
        {
            controller = "TinhLuongBoSungQuy",
            action = "Index",
            GroupID = UrlParameter.Optional,

        },
        namespaces: new[] { "TinhLuong.Controllers" }
        );

            routes.MapRoute(
              "role-group-add",
         "role-group/addnew/{metatitle}-{GroupID}",
        new
        {
            controller = "RoleGroup",
            action = "AddRole",
            GroupID = UrlParameter.Optional,

        },
        namespaces: new[] { "TinhLuong.Controllers" }
        );
            //import kkld
            routes.MapRoute(
    "ImportKKLD",
       "import-kkld",
     new
     {
         controller = "ImportKKLD",
         action = "Index",

     },
     namespaces: new[] { "TinhLuong.Controllers" }
     );

          routes.MapRoute(
        "Importkkld-docfile",
        "import-kkld/doc-file",
        new
        {
            controller = "ImportKKLD",
            action = "Success",

        },
        namespaces: new[] { "TinhLuong.Controllers" }
        );
            //import khoản kỳ 1
            routes.MapRoute(
    "ImportKy1",
       "import-ky-1",
     new
     {
         controller = "ImportExcel",
         action = "Index",

     },
     namespaces: new[] { "TinhLuong.Controllers" }
     );

            routes.MapRoute(
          "ImportKy1-docfile",
          "import-ky-1/doc-file",
          new
          {
              controller = "ImportExcel",
              action = "Success",

          },
          namespaces: new[] { "TinhLuong.Controllers" }
          );
            //import hsp2
            routes.MapRoute(
    "Importp2",
       "import-hsp2",
     new
     {
         controller = "ImportP2",
         action = "Index",

     },
     namespaces: new[] { "TinhLuong.Controllers" }
     );

            routes.MapRoute(
          "Importp2-docfile",
          "import-hsp2/doc-file",
          new
          {
              controller = "ImportP2",
              action = "Success",

          },
          namespaces: new[] { "TinhLuong.Controllers" }
          );
            //import hệ số p3
            routes.MapRoute(
    "Importp3",
       "import-hsp3",
     new
     {
         controller = "ImportHeSoP3",
         action = "Index",

     },
     namespaces: new[] { "TinhLuong.Controllers" }
     );

            routes.MapRoute(
        "import-hsp3-docfile",
        "import-hsp3/doc-file",
        new
        {
            controller = "ImportHeSoP3",
            action = "Success",

        },
        namespaces: new[] { "TinhLuong.Controllers" }
        );
           
            //import tăng giảm
            routes.MapRoute(
    "Importp tang giam",
       "import-tanggiam-ktp",
     new
     {
         controller = "ImportTangGiam_KKTietKiemVT",
         action = "Index",

     },
     namespaces: new[] { "TinhLuong.Controllers" }
     );

            routes.MapRoute(
        "import-tanggiam-ktp-docfile",
        "import-tanggiam-ktp/doc-file",
        new
        {
            controller = "ImportTangGiam_KKTietKiemVT",
            action = "Success",

        },
        namespaces: new[] { "TinhLuong.Controllers" }
        );
            //import lương sủa chữa
            routes.MapRoute(
    "import-luong-suachua",
       "import-luong-suachua",
     new
     {
         controller = "ImportLuongSuaChua",
         action = "Index",

     },
     namespaces: new[] { "TinhLuong.Controllers" }
     );

            routes.MapRoute(
        "import-luong-suachua-docfile",
        "import-luong-suachua/doc-file",
        new
        {
            controller = "ImportLuongSuaChua",
            action = "Success",

        },
        namespaces: new[] { "TinhLuong.Controllers" }
        );
            //import doanh thu ngoài
            routes.MapRoute(
    "import-doanhthungoai",
       "import-doanhthungoai",
     new
     {
         controller = "ImportDoanhThuNgoai",
         action = "Index",

     },
     namespaces: new[] { "TinhLuong.Controllers" }
     );

            routes.MapRoute(
        "import-doanhthungoai-docfile",
        "import-doanhthungoai/doc-file",
        new
        {
            controller = "ImportDoanhThuNgoai",
            action = "Success",

        },
        namespaces: new[] { "TinhLuong.Controllers" }
        );
            //import lương KKKhenTHuong
            routes.MapRoute(
    "ImportKKKhenThong",
       "import-luongkk-khac",
     new
     {
         controller = "ImportKKKhenThuong",
         action = "Index",

     },
     namespaces: new[] { "TinhLuong.Controllers" }
     );

            routes.MapRoute(
        "import-kkkhenthuong-docfile",
        "import-luongkk-khac/doc-file",
        new
        {
            controller = "ImportKKKhenThuong",
            action = "Success",

        },
        namespaces: new[] { "TinhLuong.Controllers" }
        );
            //import doanh thu
            routes.MapRoute(
    "Importdoanhthu",
       "import-doanh-thu",
     new
     {
         controller = "ImportDoanhThu",
         action = "Index",

     },
     namespaces: new[] { "TinhLuong.Controllers" }
     );

            routes.MapRoute(
"Import-doanh-thu-docfile",
"import-doanh-thu/doc-file",
new
{
    controller = "ImportDoanhThu",
    action = "Success",

},
namespaces: new[] { "TinhLuong.Controllers" }
);

            // ---thống kê chung
            //Lương bổ sung
            routes.MapRoute(
         "LuongBosung",
            "luong-bo-sung",
          new
          {
              controller = "LuongBoSung",
              action = "Index",

          },
          namespaces: new[] { "TinhLuong.Controllers" }
          );

            //--chốt sổ

            routes.MapRoute(
          "ThongKechung",
             "bao-cao-don-vi",
           new
           {
               controller = "BaoCaoChung",
               action = "Index",
           },
           namespaces: new[] { "TinhLuong.Controllers" }
           );
            routes.MapRoute(
           "ThongKechungDetail",
              "bao-cao-don-vi/{metatitle}-{thang}-{metatitle1}-{nam}-{metatitle2}-{DonViCha}-{metatitle3}-{Totram}-{metatitle4}-{NhanVien}",
            new
            {
                controller = "BaoCaoChung",
                action = "getData",
                thang = UrlParameter.Optional,
                nam = UrlParameter.Optional,
                DonViCha = UrlParameter.Optional,
                ToTram = UrlParameter.Optional,
                NhanVien = UrlParameter.Optional,
            },
            namespaces: new[] { "TinhLuong.Controllers" }
            );
            //--chốt sổ
            routes.MapRoute(
           "ChotsoDV_detail",
              "chot-so-don-vi/{metatitle}-{Thang}-{metatitle1}-{Nam}-{metatitle2}-{DonViID}-{metatitle3}-{BangLuong}",
            new
            {
                controller = "ChotSo",
                action = "IndexDetail",
                Thang = UrlParameter.Optional,
                Nam = UrlParameter.Optional,
                DonViID = UrlParameter.Optional,
                BangLuong = UrlParameter.Optional,
            },
            namespaces: new[] { "TinhLuong.Controllers" }
            );
            routes.MapRoute(
         "ChotsoDV",
            "chot-so-don-vi",
          new
          {
              controller = "ChotSo",
              action = "Index"
          },
          namespaces: new[] { "TinhLuong.Controllers" }
          );



            routes.MapRoute(
             "bangluongdonvidetail",
                "bang-luong-don-vi/{metatitle}-{Thang}-{metatitle1}-{Nam}",
              new
              {
                  controller = "BangLuongDonVi",
                  action = "IndexDetail",
                  Thang = UrlParameter.Optional,
                  Nam = UrlParameter.Optional,

              },
              namespaces: new[] { "TinhLuong.Controllers" }
              );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             "bangluongdonvi",
                "bang-luong-don-vi",
              new
              {
                  controller = "BangLuongDonVi",
                  action = "Index",
                  Thang = UrlParameter.Optional,
                  Nam = UrlParameter.Optional,

              },
              namespaces: new[] { "TinhLuong.Controllers" }
              );

            routes.MapRoute(
             "capnhatcackhoanthanhtoand",
                "update-khoan-thanh-toan/{metatitle}-{Thang}-{metatitle1}-{Nam}",
              new
              {
                  controller = "UpdateKhoanThanhToan",
                  action = "IndexDetail",
                  Thang = UrlParameter.Optional,
                  Nam = UrlParameter.Optional,

              },
              namespaces: new[] { "TinhLuong.Controllers" }
              );
            routes.MapRoute(
             "capnhatcackhoanthanhtoan",
                "update-khoan-thanh-toan",
              new
              {
                  controller = "UpdateKhoanThanhToan",
                  action = "Index",
                  Thang = UrlParameter.Optional,
                  Nam = UrlParameter.Optional,

              },
              namespaces: new[] { "TinhLuong.Controllers" }
              );

            /// quy luong dv
            ///  routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            ///  
            routes.MapRoute(
             "quyluongdonvidetail",
                "quy-luong-don-vi/{metatitle}-{Thang}-{metatitle1}-{Nam}",
              new
              {
                  controller = "QuyLuong",
                  action = "IndexDetail",
                  Thang = UrlParameter.Optional,
                  Nam = UrlParameter.Optional,

              },
              namespaces: new[] { "TinhLuong.Controllers" }
              );
            routes.MapRoute(
             "quyluongdonvi",
                "quy-luong-don-vi",
              new
              {
                  controller = "QuyLuong",
                  action = "Index",
                  Thang = UrlParameter.Optional,
                  Nam = UrlParameter.Optional,

              },
              namespaces: new[] { "TinhLuong.Controllers" }
              );
            //dang nhâp
            routes.MapRoute(
           "dang-nhap",
              "dang-nhap",
            new
            {
                controller = "Login",
                action = "Index",
                Thang = UrlParameter.Optional,
                Nam = UrlParameter.Optional,

            },
            namespaces: new[] { "TinhLuong.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
