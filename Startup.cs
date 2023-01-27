using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace DriverTracking
{
    public class Startup
    {


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDistributedMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession(opts =>
            {
                opts.Cookie.IsEssential = true; // make the session cookie Essential
            });


            ////services.AddAntiforgery(options =>
            ////{
            ////    // Set Cookie properties using CookieBuilder properties†.
            ////    //options.FormFieldName = "AntiforgeryFieldname";
            ////    options.HeaderName = "XSRF-TOKEN";
            ////    options.SuppressXFrameOptionsHeader = false;
            ////});

            //services.AddMvc().AddRazorPagesOptions(option =>
            //{
            //    option.RootDirectory = "/Views/Home";
            //    option.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseCookiePolicy();
            app.UseSession();
            app.UseWebSockets();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            //app.UseMvcWithDefaultRoute();

           
        }

    }

}