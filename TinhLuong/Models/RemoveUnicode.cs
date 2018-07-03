using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TinhLuong.Models
{
    public class RemoveUnicode
    {
        public static string ConvertToUnsign2(string str)
        {
            string strFormD = str.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strFormD.Length; i++)
            {
                System.Globalization.UnicodeCategory uc =
                System.Globalization.CharUnicodeInfo.GetUnicodeCategory(strFormD[i]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(strFormD[i]);
                }
            }
            sb = sb.Replace('Đ', 'd');
            sb = sb.Replace('đ', 'd');
            sb = sb.Replace(' ', '-');
            sb = sb.Replace(".", "");
            sb = sb.Replace("  ", "-");
            sb = sb.Replace("/", "");
            return (sb.ToString().Normalize(NormalizationForm.FormD).ToLower());
        }
    }
}