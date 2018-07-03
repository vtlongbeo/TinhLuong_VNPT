$(".isActive").click(function () {
    var a = $(this).data("stt"), b = $(this).data("user"), c = 1 == a ? "Bạn có muốn khóa tài khoản này không?" : "Bạn có muốn mở khóa tài khoản này không?";
    confirm(c) && $.ajax({
        type: "POST", url: "/PhanQuyen/Change_IsActive", data: '{UserName: "' + b + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (a) { window.location.reload() }
    })
}), $(".resetPass").click(function () {
    var a = $(this).data("user"); confirm("Bạn có muốn reset mật khẩu về mặc định?") && $.ajax({
        type: "POST", url: "/PhanQuyen/ResetPass", data: '{UserName: "' + a + '" }',
        contentType: "application/json; charset=utf-8", dataType: "json", success: function (a) { window.location.reload() }
    })
}), $(".deleteUser").click(function () {
    var a = $(this).data("user");
    confirm("Bạn có muốn xóa tài khoản này không?") && $.ajax({ type: "POST", url: "/PhanQuyen/DeleteUser", 
        data: '{UserName: "' + a + '" }', contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (a) { window.location.reload() }
    })
});