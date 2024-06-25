using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;

using Entities.Concrete.TableModel;
using Entities.Concrete.TableModel.Membership;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace TravelWebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddScoped
            //builder.Services.AddTransient
            //builder.Services.AddSingleton
            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();
            builder.Services.AddDbContext<ApplicationDbContext>()
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 5;

                options.User.RequireUniqueEmail = true;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(20);
                options.Cookie.Name = "TravelDb";
                options.Cookie.HttpOnly = false;
            });

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>();

            builder.Services.AddScoped<IAboutDal, AboutDal>();
            builder.Services.AddScoped<IAboutService, AboutManager>();
            builder.Services.AddScoped<IValidator<About>,AboutValidation>();

            builder.Services.AddScoped<IDestinationDal, DestinationDal>();
            builder.Services.AddScoped<IDestinationService, DestinationManager>();

            builder.Services.AddScoped<IPackageDal, PackageDal>();
            builder.Services.AddScoped<IPackageService, PackageManager>();

            builder.Services.AddScoped<IAdvantageDal, AdvantageDal>();
            builder.Services.AddScoped<IAdvantageService, AdvantageManager>();
            builder.Services.AddScoped<IValidator<Advantage>, AdvantageValidation>();

            builder.Services.AddScoped<ICategoryOfBlogDal , CategoryOfBlogDal>();
            builder.Services.AddScoped<ICategoryOfBlogService, CategoryOfBlogManager>();
            builder.Services.AddScoped<IValidator<CategoryOfBlog>, CategoryOfBlogValidation>();

            builder.Services.AddScoped<IBlogDal , BlogDal>();
            builder.Services.AddScoped<IBlogService, BlogManager>();
            builder.Services.AddScoped<IValidator<Blog>, BlogValidation>();

            

            builder.Services.AddScoped<IContactDal , ContactDal>();
            builder.Services.AddScoped<IContactService, ContactManager>();
            builder.Services.AddScoped<IValidator<Contact>, ContactValidation>();

            builder.Services.AddScoped<ITagDal, TagDal>();
            builder.Services.AddScoped<ITagService, TagManager>();
            builder.Services.AddScoped<IValidator<Tag>, TagValidation>();

            builder.Services.AddScoped<IGuideDal, GuideDal>();
            builder.Services.AddScoped<IGuideService, GuideManager>();
            builder.Services.AddScoped<IValidator<Guide>, GuideValidation>();

            builder.Services.AddScoped<IServiceDal,  ServiceDal>();
            builder.Services.AddScoped<IServiceService, ServiceManager>();
            builder.Services.AddScoped<IValidator<Service>, ServiceValidation>();   

            builder.Services.AddScoped<ITestimonialDal, TestmonialDal>();
            builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
            builder.Services.AddScoped<IValidator<Testimonial>, TestimonialValidation>();

            builder.Services.AddScoped<IHomeSlideDal, HomeSlideDal>();  
            builder.Services.AddScoped<IHomeSlideService, HomeSlideManager>();
            builder.Services.AddScoped<IValidator<HomeSlide>, HomeSlideValidation>();

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                            name: "areas",
                            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");

            });

            app.Run();
        }
    }
}
