using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhLuongDataAdapter;
using System.Data.SqlClient;
using System.Data;
using TinhLuongINFO;

namespace TinhLuongDAL
{
    public class ImportExcelDAL
    {
        public bool GetChotSo(decimal thang, decimal nam, string IdDonVi, string BangID)
        {
            int outPut = 0;
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Thang", SqlDbType.Decimal),
                new SqlParameter("@Nam", SqlDbType.Decimal),
                new SqlParameter("@BangID", SqlDbType.VarChar,50),
                new SqlParameter("@IdDonVi", SqlDbType.VarChar,50),
                new SqlParameter("@OutPut",  SqlDbType.Int),
            };
            parm[0].Value = thang;  
            parm[1].Value = nam;
            parm[2].Value = BangID;
            parm[3].Value = IdDonVi;
            parm[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Check_ChotSo", parm);
            outPut = int.Parse(parm[4].Value.ToString());
            if (outPut == 0) return true;
            else return false;
        }

        public bool CapNhatBangLuongKy1_Import(int nam, int thang, string nhansuid, string donviid, int anca, int ctp_khth, int tt_themgio, int chenuoc,
              int ctp_khac, int boiduongk3, int khac, int luongky1, string USERNAME)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam", nam),
                new SqlParameter("@nhansuid", nhansuid),
                new SqlParameter("@DonViID",donviid),
                new SqlParameter("@anca",  anca),
                new SqlParameter("@ctp_khth", ctp_khth),
                new SqlParameter("@tt_themgio",  tt_themgio),
                new SqlParameter("@chenuoc", chenuoc),
                new SqlParameter("@ctp_khac", ctp_khac),
                new SqlParameter("@boiduongk3", boiduongk3),
                new SqlParameter("@khac", khac),
                new SqlParameter("@luongky1", luongky1),
                new SqlParameter("@USERNAME", USERNAME),
             };
            // dbCmd.Parameters.Add(new SqlParameter("@chuyenkhoan", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, chuyenkhoan));
            try
            {
                var rs = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "BangLuongKy1_Update_Import", parm);
                if (rs > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Import_BaoHongGiamTru(int nam, int thang, int PhieuBaoHongID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam", nam),
                new SqlParameter("@PhieuBaoHongID", PhieuBaoHongID),
                
             };
            // dbCmd.Parameters.Add(new SqlParameter("@chuyenkhoan", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, chuyenkhoan));
            try
            {
                var rs = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_ImportBaoHong_GiamTru", parm);
                if (rs > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete_BaoHongGiamTru(int nam, int thang)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam", nam)

             };
            // dbCmd.Parameters.Add(new SqlParameter("@chuyenkhoan", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, chuyenkhoan));
            try
            {
                var rs = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Delete_BaoHongGiamTru", parm);
                if (rs > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete_MLLTB(int nam, int thang, string Loai)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam", nam),
                new SqlParameter("@Loai",Loai)

             };
            // dbCmd.Parameters.Add(new SqlParameter("@chuyenkhoan", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, chuyenkhoan));
            try
            {
                var rs = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Delete_Tuyen_Insert_MLLTB", parm);
                if (rs >= 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Insert_MLLTB(int nam, int thang, string DonViID, string Loai,int TGMLL, int SLTB)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam", nam),
                new SqlParameter("@DonViID",DonViID),
                new SqlParameter("@Loai",Loai),
                new SqlParameter("@TGMLL",TGMLL),
                new SqlParameter("@SLTB",SLTB)

             };
            // dbCmd.Parameters.Add(new SqlParameter("@chuyenkhoan", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, chuyenkhoan));
            try
            {
                var rs = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_Insert_MLLTB", parm);
                if (rs > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateUNGCUU(int Nam, int Thang, string NhanSuID, int LuongTN,string UserName)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",Nam),
                new SqlParameter("@Thang",Thang),
                new SqlParameter("@NhanSuID",NhanSuID),
                new SqlParameter("@LUONGTN",LuongTN),
                new SqlParameter("@USERNAME",UserName)
            };
            // Use connection object of base class
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_UNGCUU_Update", parm);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("BangLuongUC Truc dem:Update Error occured.", ex);
            }
        }

        public bool Delete_UngCuu(decimal nam, decimal thang, string username)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",nam),
                new SqlParameter("@Thang",thang),
                new SqlParameter("@USERNAME",username)
            };
            // Use connection object of base class
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_DeleteUngCuu", parm);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("BangLuongUC Truc dem:Update Error occured.", ex);
            }
        }
        public bool UpdateDT(int nam, int thang, int nhansuid, string donviid, decimal doanhthu, string username)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@Nam",nam),
                    new SqlParameter("@Thang",thang),
                    new SqlParameter("@NhanSuID",nhansuid),
                    new SqlParameter("@DonViID",donviid),
                    new SqlParameter("@DIDONG", doanhthu),
                    new SqlParameter("USERNAME",username),
                    new SqlParameter("@NGAYUP",DateTime.Now)
                };
                var rs = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpBangLuongTHUCUOC_Update", parm);
                if (rs > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw new Exception("BangLuong::Update::Error occured.", ex);
            }
        }
        public List<string> GetBangLuongDonVi(string IDDonVi, decimal thang, decimal nam)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@IdDonVi", IDDonVi),
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@Thang",thang)
               };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpBangLuong_SelectByDonVi", parm);

                return ds.Tables[0].DataTableToList<BangLuong>().Select(x => x.NhanSuID).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("BangLuong::SelectByIdDonvi::Error occured.", ex);
            }
        }
        public bool Update_SQLPTTB(decimal nam, decimal thang, string IdDonVi, string username)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter("@Nam",nam),
                new SqlParameter("@Thang",thang),
                new SqlParameter("@IdDonVi", IdDonVi),
                new SqlParameter("@UserName",username)
           };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_UpdateSQL_PTTB_DTTK", parm);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateTAMUNGKTP(BangLuong bl)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam",bl.Nam),
                new SqlParameter("@Thang",bl.Thang),
                new SqlParameter("@NhanSuID",bl.NhanSuID),
                new SqlParameter("@DonViID",bl.DonViID),
                new SqlParameter("@HSCN",bl.HSCN),
                new SqlParameter("@HSBP",bl.HSBP),
                new SqlParameter("@USERNAME",bl.UserName),
                new SqlParameter("@NGAYUP",bl.NgayUp)
            };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_TAMUNGKTP_Update", parm);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("BangLuong::Update::Error occured.", ex);
            }
        }
        public bool Update_BSC(decimal nam, decimal thang, string username)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter("@Nam",nam),
                new SqlParameter("@Thang",thang),
                new SqlParameter("@UserName",username)
           };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_UpdateBSC", parm);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        ///Khuyến khích lắp đặt
        ///
        public bool Delete_KKLD(decimal nam, decimal thang, string username,int Loai)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
                new SqlParameter("@Nam", nam),
                new SqlParameter("@Thang", thang),
                new SqlParameter("@UserName", username),
                new SqlParameter("@Loai", Loai)
             };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_DeleteKKLD", parm);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateLAPDAT(BangLuongLapDat bl)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam", bl.Nam),
                new SqlParameter("@Thang", bl.Thang),
                new SqlParameter("@USERNAME", bl.UserName),
                new SqlParameter("@NhanSuID", bl.NhanSuID),
                new SqlParameter("@LUONGKKLD",bl.LUONGKKLD),
                new SqlParameter("@LUONGPHLD",bl.LUONGPHLD),
                new SqlParameter("@LUONGSPITTER",bl.LUONGSPITTER)
            };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_LAPDAT_Insert", parm);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("BangLuongKK Lap Dat:Insert Error occured.", ex);
            }
        }

        ///MYTV
        ///
        public bool UpdateKDTM(BangLuong bl)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
                new SqlParameter("@Nam",bl.Nam),
                new SqlParameter("@Thang",bl.Thang),
                new SqlParameter("@USERNAME",bl.UserName),
                new SqlParameter("@NhanSuID",bl.NhanSuID),
                new SqlParameter("@DonViID", bl.DonViID),
                new SqlParameter("@MYTV", bl.MYTV),
                new SqlParameter("@NGAYUP", null)
          };
            try
            {
               var rs= SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_P3_Update", parm);
                if (rs > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update_KHENTHUONG(decimal Nam, decimal Thang, string UserName, decimal LuongKK, string NhanSuID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam", Nam),
                new SqlParameter("@Thang",Thang),
                new SqlParameter("@NhanSuID",NhanSuID),
                new SqlParameter("@LUONG_KK_KHAC",LuongKK),
                new SqlParameter("@UserName",UserName)
            };
            try
            {
                var rs = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_KHENTHUONG_Update", parm);
                if (rs > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete_TangGiam(decimal nam, decimal thang, string username)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
                new SqlParameter("@Nam", nam),
                new SqlParameter("@Thang", thang),
                new SqlParameter("@UserName", username)
             };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_DeleteTangGiam", parm);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete_LuongKhac(decimal nam, decimal thang, string username,int Loai,string donViId)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
                new SqlParameter("@Nam", nam),
                new SqlParameter("@Thang", thang),
                new SqlParameter("@UserName", username),
                new SqlParameter("@Loai", Loai),
                new SqlParameter("@DonViID", donViId)
             };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_DeleteLuongKhac", parm);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update_LUONGKHAC(decimal Nam, decimal Thang, string UserName, decimal LuongKhac, string NhanSuID,string LoaiLuong)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam", Nam),
                new SqlParameter("@Thang",Thang),
                new SqlParameter("@NhanSuID",NhanSuID),
                new SqlParameter("@LUONGKHAC",LuongKhac),
                new SqlParameter("@UserName",UserName),
                new SqlParameter("@Type",LoaiLuong)
            };
            try
            {
                var rs = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_LUONGKHAC_Insert", parm);
                if (rs > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update_DoanhThuNgoai(decimal Nam, decimal Thang, string UserName, decimal LUONGKDTM, string NhanSuID, string DonViID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam", Nam),
                new SqlParameter("@Thang",Thang),
                new SqlParameter("@NhanSuID",NhanSuID),
                new SqlParameter("@LUONGKDTM",LUONGKDTM),
                new SqlParameter("@UserName",UserName),
                new SqlParameter("@DonViID",DonViID),
                new SqlParameter("@NGAYUP",null)
            };
            try
            {
                var rs = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_LUONGKDTM_Update", parm);
                if (rs > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update_TangGiam(decimal Nam, decimal Thang, string UserName, decimal LUONGKTP, string NhanSuID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Nam", Nam),
                new SqlParameter("@Thang",Thang),
                new SqlParameter("@NhanSuID",NhanSuID),
                new SqlParameter("@LUONGKTP",LUONGKTP),
                new SqlParameter("@UserName",UserName)
            };
            try
            {
                var rs = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_TANGGIAM_Insert", parm);
                if (rs > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete_BoSung_Temp()
        {
            
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_DeleteBoSung_Temp");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateBoSung(string NhanSuID, int TongTien, string DonViID, string DonViChaID,int ChuyenKhoan,string NgayCK, int ThuNop, string Username,string sotk)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@NhanSuID",NhanSuID),
                new SqlParameter("@TONGTIEN",TongTien),
                new SqlParameter("@DonViID",DonViID),
                new SqlParameter("@DonViChaID",DonViChaID),
                new SqlParameter("@NGAYCK", NgayCK),
                new SqlParameter("@CHUYENKHOAN",ChuyenKhoan),
                new SqlParameter("@SOTK",sotk),
                new SqlParameter("@ThuNop",ThuNop),
                new SqlParameter("@USERNAME",Username)
            };
            // Use connection object of base class
           
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_BoSung_Insert", parm);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("BangLuongBoSung:Insert Error occured.", ex);
            }
            
        }

        public DataTable GetKKLapDat(int thang, int nam, string type)
        {
            string ThangNam = "";
            if (thang < 10)
                ThangNam = "0" + thang.ToString() + "/" + nam.ToString();
            else
                ThangNam = thang.ToString() + "/" + nam.ToString();
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@ThangLuong",ThangNam),
                new SqlParameter("@Type",type)
            };
            try
            {
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Tuyen_sp_getLuongLapDat]", parm);
                return ds.Tables[0];
            }
            catch(Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable GetLuongTBDuyTri(int thang, int nam)
        {
            string ThangNam = "";
            if (thang < 10)
                ThangNam = "0" + thang.ToString() + "/" + nam.ToString();
            else
                ThangNam = thang.ToString() + "/" + nam.ToString();
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@ThangNam",ThangNam)
            };
            try
            {
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Tuyen_sp_LuongTBDuyTri]", parm);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable TinhLuong_MLLTB(int thang, int nam)
        {
          
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Thang",thang),
                new SqlParameter("@Nam",nam)
            };
            try
            {
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Tuyen_TinhLuong_MLLTB]", parm);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public int Get_SoNgayCong(int thang, int nam)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam",nam)
            };
            try
            {
                return(int) SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_sp_GetSoNgayTrongThang", parm);
            }
            catch
            {
                return -1;
            }
        }

        public bool Delete_LuongKTP(decimal nam, decimal thang, string username, int Loai, string donViId)
        {
            SqlParameter[] parm = new SqlParameter[]
             {
                new SqlParameter("@Nam", nam),
                new SqlParameter("@Thang", thang),
                new SqlParameter("@UserName", username),
                new SqlParameter("@Loai", Loai),
                new SqlParameter("@DonViID", donViId)
             };
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmp_DeleteLuongKTP", parm);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
