using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongINFO
{
    public class LuongLapDat
    {
        private int _ID;
        private string _ThangNam;
        private string _ThueBaoID;
        private string _PhanLoai;
        private int _NhanVienID;
        private string _HoTen;
        private string _TenChucDanh;
        private string _UserName;
        private string _SoDienThoai;
        private string _LoaiDichVu;
        private string _LoaiDichVuSub;
        private string _KhachHangID;
        private string _HopDongID;
        private string _TenLapDat;
        private string _TenDiaChi;
        private DateTime _NgayHopDong;
        private string _MaskTrangThai;
        private string _TrangThaiHD;
        private DateTime _NgayPhatTrien;
        private DateTime _NgayYeuCau;
        private DateTime _NgayThucHienYeuCau;
        private DateTime _ThoiHanChoPhep;
        private int _QuaHanPT;
        private DateTime _NgayTinhCuoc;
        private string _KeoDay;
        private int _DonGia;
        private string _GiaiTrinh;
        private string _GhiChuGiaiTrinh;
        private int _TG_LAPDAT;
        private int _TG_LAPDAT_NGAY;
        private string _NguoiCauHinh;
        private DateTime _NgayCauHinh;
        private int _TraLoiID;
        private string _XacThuc;
        
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string ThangNam
        {
            get { return _ThangNam; }
            set { _ThangNam = value; }
        }
        public string ThueBaoID
        {
            get { return _ThueBaoID; }
            set { _ThueBaoID = value; }
        }
        public string PhanLoai
        {
            get { return _PhanLoai; }
            set { _PhanLoai = value; }
        }
        public int NhanVienID
        {
            get { return _NhanVienID; }
            set { _NhanVienID = value; }
        }
        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }
        public string TenChucDanh
        {
            get { return _TenChucDanh; }
            set { _TenChucDanh = value; }
        }
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public string SoDienThoai
        {
            get { return _SoDienThoai; }
            set { _SoDienThoai = value; }
        }
        public string LoaiDichVu
        {
            get { return _LoaiDichVu; }
            set { _LoaiDichVu = value; }
        }
        public string LoaiDichVuSub
        {
            get { return _LoaiDichVuSub; }
            set { _LoaiDichVuSub = value; }
        }
        public string KhachHangID
        {
            get { return _KhachHangID; }
            set { _KhachHangID = value; }
        }
        public string HopDongID
        {
            get { return _HopDongID; }
            set { _HopDongID = value; }
        }
        public string TenLapDat
        {
            get { return _TenLapDat; }
            set { _TenLapDat = value; }
        }
        public string TenDiaChi
        {
            get { return _TenDiaChi; }
            set { _TenDiaChi = value; }
        }
        public DateTime NgayHopDong
        {
            get { return _NgayHopDong; }
            set { _NgayHopDong = value; }
        }
        public string MaskTrangThai
        {
            get { return _MaskTrangThai; }
            set { _MaskTrangThai = value; }
        }
        public string TrangThaiHD
        {
            get { return _TrangThaiHD; }
            set { _TrangThaiHD = value; }
        }
        public DateTime NgayPhatTrien
        {
            get { return _NgayPhatTrien; }
            set { _NgayPhatTrien = value; }
        }
        public DateTime NgayYeuCau
        {
            get { return _NgayYeuCau; }
            set { _NgayYeuCau = value; }
        }
        public DateTime NgayThucHienYeuCau
        {
            get { return _NgayThucHienYeuCau; }
            set { _NgayThucHienYeuCau = value; }
        }
        public DateTime ThoiHanChoPhep
        {
            get { return _ThoiHanChoPhep; }
            set { _ThoiHanChoPhep = value; }
        }
        public int QuaHanPT
        {
            get { return _QuaHanPT; }
            set { _QuaHanPT = value; }
        }
        public DateTime NgayTinhCuoc
        {
            get { return _NgayTinhCuoc; }
            set { _NgayTinhCuoc = value; }
        }
        public string KeoDay
        {
            get { return _KeoDay; }
            set { _KeoDay = value; }
        }
        public int DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }
        public string GiaiTrinh
        {
            get { return _GiaiTrinh; }
            set { _GiaiTrinh = value; }
        }
        public string GhiChuGiaiTrinh
        {
            get { return _GhiChuGiaiTrinh; }
            set { _GhiChuGiaiTrinh = value; }
        }
        public int TG_LAPDAT
        {
            get { return _TG_LAPDAT; }
            set { _TG_LAPDAT = value; }
        }
        public int TG_LAPDAT_NGAY
        {
            get { return _TG_LAPDAT_NGAY; }
            set { _TG_LAPDAT_NGAY = value; }
        }
        public string NguoiCauHinh
        {
            get { return _NguoiCauHinh; }
            set { _NguoiCauHinh = value; }
        }
        public DateTime NgayCauHinh
        {
            get { return _NgayCauHinh; }
            set { _NgayCauHinh = value; }
        }
        public int TraLoiID
        {
            get { return _TraLoiID; }
            set { _TraLoiID = value; }
        }
      

        public string XacThuc
        {
            get
            {
                return _XacThuc;
            }

            set
            {
                _XacThuc = value;
            }
        }
    }

    public class LuongKK
    {
        public List<LuongTH> LuongPH { set; get; }
        public List<LuongTH> LuongKKLD { set; get; }
        public List<LuongLapDat> ChiTiet { set; get; }
    }

    public class LuongTH
    {
        private int _NhanVienID;
        private int _SoLuong;
        private int _Luong;

        public int NhanVienID
        {
            get
            {
                return _NhanVienID;
            }

            set
            {
                _NhanVienID = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return _SoLuong;
            }

            set
            {
                _SoLuong = value;
            }
        }

        public int Luong
        {
            get
            {
                return _Luong;
            }

            set
            {
                _Luong = value;
            }
        }
    }
}
