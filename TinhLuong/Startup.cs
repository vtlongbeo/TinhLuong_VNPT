using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TinhLuong.Startup))]
namespace TinhLuong
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
