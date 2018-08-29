using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BooksStore_Management.Startup))]
namespace BooksStore_Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
