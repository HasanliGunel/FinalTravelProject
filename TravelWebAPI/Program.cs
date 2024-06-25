
using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using DataAccess.Contrete;
using Entities.Concrete.TableModel;
using Entities.Concrete.TableModel.Membership;
using FluentValidation;

namespace TravelWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApplicationDbContext>()
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<IAboutDal, AboutDal>();
            builder.Services.AddScoped<IAboutService, AboutManager>();
            builder.Services.AddScoped<IValidator<About>, AboutValidation>();

            builder.Services.AddScoped<IDestinationDal, DestinationDal>();
            builder.Services.AddScoped<IDestinationService, DestinationManager>();

            builder.Services.AddScoped<IPackageDal, PackageDal>();
            builder.Services.AddScoped<IPackageService, PackageManager>();

            builder.Services.AddScoped<IAdvantageDal, AdvantageDal>();
            builder.Services.AddScoped<IAdvantageService, AdvantageManager>();
            builder.Services.AddScoped<IValidator<Advantage>, AdvantageValidation>();

            builder.Services.AddScoped<ICategoryOfBlogDal, CategoryOfBlogDal>();
            builder.Services.AddScoped<ICategoryOfBlogService, CategoryOfBlogManager>();
            builder.Services.AddScoped<IValidator<CategoryOfBlog>, CategoryOfBlogValidation>();

            builder.Services.AddScoped<IBlogDal, BlogDal>();
            builder.Services.AddScoped<IBlogService, BlogManager>();
            builder.Services.AddScoped<IValidator<Blog>, BlogValidation>();

            builder.Services.AddScoped<IBookNowDal, BookNowDal>();
            builder.Services.AddScoped<IBookNowService, BookNowManager>();
            builder.Services.AddScoped<IValidator<BookNow>, BookNowValidation>();

            builder.Services.AddScoped<IContactDal, ContactDal>();
            builder.Services.AddScoped<IContactService, ContactManager>();
            builder.Services.AddScoped<IValidator<Contact>, ContactValidation>();

            builder.Services.AddScoped<ITagDal, TagDal>();
            builder.Services.AddScoped<ITagService, TagManager>();
            builder.Services.AddScoped<IValidator<Tag>, TagValidation>();

            builder.Services.AddScoped<IGuideDal, GuideDal>();
            builder.Services.AddScoped<IGuideService, GuideManager>();
            builder.Services.AddScoped<IValidator<Guide>, GuideValidation>();

            builder.Services.AddScoped<IServiceDal, ServiceDal>();
            builder.Services.AddScoped<IServiceService, ServiceManager>();
            builder.Services.AddScoped<IValidator<Service>, ServiceValidation>();

            builder.Services.AddScoped<ITestimonialDal, TestmonialDal>();
            builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
            builder.Services.AddScoped<IValidator<Testimonial>, TestimonialValidation>();

            builder.Services.AddScoped<IHomeSlideDal, HomeSlideDal>();
            builder.Services.AddScoped<IHomeSlideService, HomeSlideManager>();
            builder.Services.AddScoped<IValidator<HomeSlide>, HomeSlideValidation>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
