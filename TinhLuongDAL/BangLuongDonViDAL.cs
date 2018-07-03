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
    public class BangLuongDonViDAL
    {
        public DataTable GetBangLuongDonVi(string IDDonVi, decimal thang, decimal nam)
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

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("BangLuong::SelectByIdDonvi::Error occured.", ex);
            }

        }
        public List<DM_DonVi> SelectByDonVi(string IDDonVi)
        {
            try
            {
                SqlParameter parm = new SqlParameter("@IdDonVi", IDDonVi);
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpDM_DonVi_SelectByDonVi", parm);
                return ds.Tables[0].DataTableToList<DM_DonVi>();
            }
            catch (Exception ex)
            {
                throw new Exception("BangLuong::SelectByIdDonvi::Error occured.", ex);
            }
        }
        public DataTable GetBangLuongDonViByNhanSu(string IDNhanSu, decimal thang, decimal nam)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@IdNhanSu", IDNhanSu),
                    new SqlParameter("@Nam", nam),
                    new SqlParameter("@Thang",thang)
               };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[TinhLuongDBTmpBangLuong_GetTableNhanVien]", parm);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("BangLuong::SelectByIdDonvi::Error occured.", ex);
            }

        }
        public List<BangLuong> SelectByField(string fieldName, object value)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@FieldName", fieldName),
                    new SqlParameter("@Value", value),

               };
                DataSet ds = SqlHelper.Dataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpBangLuong_SelectByField", parm);
                return ds.Tables[0].DataTableToList<BangLuong>();
            }
            catch (Exception ex)
            {
                throw new Exception("BangLuong::SelectByIdDonvi::Error occured.", ex);
            }

        }
        public int Update_BangLuongDonVi(BangLuong businessObject)
        {
            try
            {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@Nam", businessObject.Nam),
            new SqlParameter("@Thang", businessObject.Thang),
            new SqlParameter("@STT", businessObject.STT),
            new SqlParameter("@NhanSuID",  businessObject.NhanSuID),
            new SqlParameter("@DonViID", businessObject.DonViID),
            new SqlParameter("@HoTen", businessObject.HoTen),
            new SqlParameter("@HSCB",businessObject.HSCB),
            new SqlParameter("@HSPC", businessObject.HSPC),
            new SqlParameter("@HSLCD",businessObject.HSLCD),
            new SqlParameter("@HSCN",  businessObject.HSCN),
            new SqlParameter("@HSBP",  businessObject.HSBP),
            new SqlParameter("@CSTL", businessObject.CSTL),
            new SqlParameter("@HSGD",businessObject.HSGD),
            new SqlParameter("@TYLEHT_GD", businessObject.TYLEHT_GD),
            new SqlParameter("@DONGIA",  businessObject.DONGIA),
            new SqlParameter("@NC",  businessObject.NC),
            new SqlParameter("@NP",businessObject.NP),
            new SqlParameter("@NR",  businessObject.NR),
            new SqlParameter("@NTS",  businessObject.NTS),
            new SqlParameter("@TNC",  businessObject.TNC),
            new SqlParameter("@DTHU",businessObject.DTHU),
            new SqlParameter("@CODINH", businessObject.CODINH),
            new SqlParameter("@ADSL", businessObject.ADSL),
            new SqlParameter("@MYTV",  businessObject.MYTV),
            new SqlParameter("@FTTH", businessObject.FTTH),
            new SqlParameter("@DIDONG",  businessObject.DIDONG),
            new SqlParameter("@LUONGDTTK", businessObject.LUONGDTTK),
            // sqlCommand.Parameters.Add(new SqlParameter("@LUONGCS", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LUONGCS));
            // sqlCommand.Parameters.Add(new SqlParameter("@LUONGTT", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LUONGTT));
            // sqlCommand.Parameters.Add(new SqlParameter("@LUONGGT", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LUONGGT));
            //sqlCommand.Parameters.Add(new SqlParameter("@LUONGTT_CLNC", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LUONGTT_CLNC));
            //sqlCommand.Parameters.Add(new SqlParameter("@LUONGGT_CLNC", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LUONGGT_CLNC));
            new SqlParameter("@LUONGTN",  businessObject.LUONGTN),
            // sqlCommand.Parameters.Add(new SqlParameter("@LUONGKTP", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LUONGKTP));
            //sqlCommand.Parameters.Add(new SqlParameter("@LUONGKHOANPHEP", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LUONGKHOANPHEP));
            new SqlParameter("@LUONGPTTB",  businessObject.LUONGPTTB),
            new SqlParameter("@LUONGKDTM",  businessObject.LUONGKDTM),
            new SqlParameter("@LUONGKHAC",  businessObject.LUONGKHAC),
            //sqlCommand.Parameters.Add(new SqlParameter("@BHXH", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BHXH));
            // sqlCommand.Parameters.Add(new SqlParameter("@BHYT", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BHYT));
            // sqlCommand.Parameters.Add(new SqlParameter("@BHTN", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BHTN));
            // sqlCommand.Parameters.Add(new SqlParameter("@KHOANNOP", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KHOANNOP));
            // sqlCommand.Parameters.Add(new SqlParameter("@TONGLUONG", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TONGLUONG));
            new SqlParameter("@TAMUNG",  businessObject.TAMUNG),
            new SqlParameter("@USERNAME",  businessObject.UserName),
            new SqlParameter("@NGAYUP",  businessObject.NgayUp),
               // sqlCommand.Parameters.Add(new SqlParameter("@THUCLINH", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.THUCLINH));

           };
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TinhLuongDBTmpBangLuong_Update", parm);

            }
            catch(Exception ex)
            {
                return -1;
            }
        }
        public int Insert_BangLuongDonVi(BangLuong businessObject)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[]
                {
            new SqlParameter("@Nam", businessObject.Nam),
            new SqlParameter("@Thang", businessObject.Thang),
            new SqlParameter("@STT", businessObject.STT),
            new SqlParameter("@NhanSuID",  businessObject.NhanSuID),
            new SqlParameter("@DonViID", businessObject.DonViID),
            new SqlParameter("@HoTen", businessObject.HoTen),
            new SqlParameter("@HSCB",businessObject.HSCB),
            new SqlParameter("@HSPC", businessObject.HSPC),
            new SqlParameter("@HSLCD",businessObject.HSLCD),
            new SqlParameter("@HSCN",  businessObject.HSCN),
            new SqlParameter("@HSBP",  businessObject.HSBP),
            new SqlParameter("@CSTL", businessObject.CSTL),
            new SqlParameter("@HSGD",businessObject.HSGD),
            //new SqlParameter("@TYLEHT_GD", businessObject.TYLEHT_GD),
            new SqlParameter("@DONGIA",  businessObject.DONGIA),
            new SqlParameter("@NC",  businessObject.NC),
            new SqlParameter("@NP",businessObject.NP),
            //new SqlParameter("@NR",  businessObject.NR),
            //new SqlParameter("@NTS",  businessObject.NTS),
            new SqlParameter("@TNC",  businessObject.TNC),
            new SqlParameter("@DTHU",businessObject.DTHU),
            new SqlParameter("@CODINH", businessObject.CODINH),
            new SqlParameter("@ADSL", businessObject.ADSL),
            new SqlParameter("@MYTV",  businessObject.MYTV),
            new SqlParameter("@FTTH", businessObject.FTTH),
            new SqlParameter("@DIDONG",  businessObject.DIDONG),
             //new SqlParameter("@GPHONE",  null),
            //new SqlParameter("@LUONGDTTK", businessObject.LUONGDTTK),
             new SqlParameter("@LUONGCS", null),
              new SqlParameter("@LUONGTT", businessObject.LUONGTT),
               new SqlParameter("@LUONGGT", businessObject.LUONGGT),
            // sqlCommand.Parameters.Add(new SqlParameter("@LUONGCS", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LUONGCS));
            // sqlCommand.Parameters.Add(new SqlParameter("@LUONGTT", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LUONGTT));
            // sqlCommand.Parameters.Add(new SqlParameter("@LUONGGT", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LUONGGT));
            //sqlCommand.Parameters.Add(new SqlParameter("@LUONGTT_CLNC", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LUONGTT_CLNC));
            //sqlCommand.Parameters.Add(new SqlParameter("@LUONGGT_CLNC", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LUONGGT_CLNC));
            new SqlParameter("@LUONGTN",  businessObject.LUONGTN),
            // sqlCommand.Parameters.Add(new SqlParameter("@LUONGKTP", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LUONGKTP));
            //sqlCommand.Parameters.Add(new SqlParameter("@LUONGKHOANPHEP", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LUONGKHOANPHEP));
            //new SqlParameter("@LUONGPTTB",  businessObject.LUONGPTTB),
            //new SqlParameter("@LUONGKDTM",  businessObject.LUONGKDTM),
            //new SqlParameter("@LUONGKHAC",  businessObject.LUONGKHAC),
            new SqlParameter("@BHXH",  businessObject.BHXH),
            new SqlParameter("@BHYT",  businessObject.BHYT),
            new SqlParameter("@BHTN",  businessObject.BHTN),
             new SqlParameter("@KHOANNOP",  businessObject.KHOANNOP),
            new SqlParameter("@TONGLUONG",  businessObject.BHTN),

            //sqlCommand.Parameters.Add(new SqlParameter("@BHXH", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BHXH));
            // sqlCommand.Parameters.Add(new SqlParameter("@BHYT", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BHYT));
            // sqlCommand.Parameters.Add(new SqlParameter("@BHTN", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BHTN));
            // sqlCommand.Parameters.Add(new SqlParameter("@KHOANNOP", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KHOANNOP));
            // sqlCommand.Parameters.Add(new SqlParameter("@TONGLUONG", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TONGLUONG));
            //new SqlParameter("@TAMUNG",  businessObject.TAMUNG),
            new SqlParameter("@USERNAME",  businessObject.UserName),
            new SqlParameter("@THUCLINH",  businessObject.THUCLINH),
                    // sqlCommand.Parameters.Add(new SqlParameter("@THUCLINH", SqlDbType.Decimal, 17, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.THUCLINH));

                };
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Tuyen_TinhLuongDBTmpBangLuong_Insert", parm);

            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}

