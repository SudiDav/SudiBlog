using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(SudiBlog.Areas.Identity.IdentityHostingStartup))]
namespace SudiBlog.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                //services.AddDbContext<ApplicationDbContext>(options =>
                //    options.UseNpgsql(
                //        context.Configuration.GetConnectionString("ApplicationDbContextConnection")));

                //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<ApplicationDbContext>();
            });
        }
    }
}
