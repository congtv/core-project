using Core.Web.Extension;
using Core.Web.Migrations;
using Core.Web.Models.Dto.Request;
using Core.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Web
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
            services.AddDbContext<CoreDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<CoreDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            #region Mapper
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserLoginRequest, IdentityUser>();
                cfg.CreateMap<UserRegisterRequest, IdentityUser>();
                //cfg.CreateMap<MQuestion, QuestionDto>();
                //cfg.CreateMap<MAnswer, AnswerDto>();
                //cfg.CreateMap<TAnswerResult, AnswerResultDto>();

                //cfg.CreateMap<AnswerResultDetailDto, TAnswerResultDetail>();
                //cfg.CreateMap<AnswerResultDto, TAnswerResult>();

                //cfg.CreateMap<MSchool, SchoolDto>();

                //cfg.CreateMap<MComment, CommentDto>();

                cfg.CreateMap<DeliveryQuestionSetDto, TDeliveryQuestionSet>();

            });

            #endregion

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
