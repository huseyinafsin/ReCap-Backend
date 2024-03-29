using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;

using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using Business.Mapping;
using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Core.Services;
using Core.DataAccess.EntityFramework;
using Core.DataAccess;

namespace WebAPI
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

            services.AddControllers();
            services.AddCors();
            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MemoryBufferThreshold = int.MaxValue;
            });
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //Automapper
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new CarProfile());
            });

            var connString = Configuration.GetConnectionString("Default");
            services.AddDbContext<DbContext,ReCapContext>(options => { options.UseSqlServer(connString); });

            //services
            services.AddScoped<ICarService, CarManager>();
            services.AddScoped<ICarDal, EfCarDal>();

            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IBrandDal, EfBrandDal>();

            services.AddScoped<IColorService, ColorManager>();
            services.AddScoped<IColorDal, EfColorDal>();

            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<ICustomerDal, EfCustomerDal>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, EfUserDal>();

            services.AddScoped<IRentalService, RentalManager>();
            services.AddScoped<IRentalDal, EfRentalDal>();

            services.AddScoped<ICarImageService, CarImageManager>();
            services.AddScoped<ICarImageDal, EfCarImageDal>();

            services.AddScoped<ICreditCardService, CreditCardManager>();
            services.AddScoped<ICreditCardDal, EfCreditCardDal>();

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<ITokenHelper, JwtHelper>();

            services.AddScoped<ICreditCardService, CreditCardManager>();
            services.AddScoped<ICarImageDal, EfCarImageDal>();

            services.AddScoped<IPaymentService, PaymentManager>();
            services.AddScoped<IPaymentDal, EfPaymentDal>();

            services.AddScoped<IMailSubscribeService, MailSubscribeManager>();
            services.AddScoped<IMailSubscriberDal, EfMailSubscribeDal>();

            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sample.FileUpload.Api", Version = "v1" });
                c.OperationFilter<SwaggerFileOperationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.ConfigureCustomExceptionMiddleware();   

            app.UseCors(builder=>builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath,"wwwroot/Images")),
                RequestPath = "/Images"
            });
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
