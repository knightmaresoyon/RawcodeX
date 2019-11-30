using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using RawcodeX.UI.Models;
using System.Web.Services.Description;

[assembly: OwinStartupAttribute(typeof(RawcodeX.UI.Startup))]
namespace RawcodeX.UI
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();
            
        }

        public void CreateUserAndRoles()
        
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Create Super Admin Role
            if (!roleManager.RoleExists("SuperAdmin"))
            {
                var role = new ApplicationRole("SuperAdmin","I am Admin");
                roleManager.Create(role);
            }

            // Create Default User
            var user = new ApplicationUser();
            user.UserName = "rakib";
            user.FirstName = "Md.Rakibul";
            user.LastName = "Islam";
            user.Email= "rakib@gmail.com";
            user.PhoneNumber = "01682503355";
            string psw = "123456";

            var newUser = userManager.Create(user, psw);

            if(newUser.Succeeded)
            {
                userManager.AddToRole(user.Id, "SuperAdmin");
            }

            // Default UserStore constructor uses the default connection string named: DefaultConnection
            //var userStore = new UserStore<IdentityUser>();
            //var manager = new UserManager<IdentityUser>(userStore);
            //var user = new IdentityUser() { UserName = UserName.Text };

        }
    }
}
