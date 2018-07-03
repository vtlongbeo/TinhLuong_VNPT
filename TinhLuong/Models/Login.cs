using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TinhLuong.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Vui lòng không để trống tài khoản")]
        [StringLength(100)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống mật khẩu")]
        [StringLength(100)]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}