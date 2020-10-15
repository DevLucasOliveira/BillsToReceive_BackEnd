using Bills.Api.Services;
using Bills.Api.Utils;
using Bills.Domain.Account.Handlers;
using Bills.Domain.Account.Repositories;
using Bills.Domain.Account.Services;
using Bills.Domain.Admin.Handlers;
using Bills.Domain.Admin.Repositories;
using Bills.Domain.Clients.Handlers;
using Bills.Domain.Clients.Repositories;
using Bills.Domain.Orders.Handlers;
using Bills.Domain.Orders.Repositories;
using Bills.Infra.Contexts;
using Bills.Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Text;

namespace bills.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyPolicy",
                    builder =>
                    {
                        //builder.WithOrigins("https://master.d275g3lbfmxyua.amplifyapp.com")
                        //builder.AllowAnyOrigin()
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "aplication/json" });
            });

            services.AddControllers();

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IKeyAccessRepository, KeyAccessRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<UserHandler, UserHandler>();
            services.AddScoped<AdminHandler, AdminHandler>();
            services.AddScoped<ClientHandler, ClientHandler>();
            services.AddScoped<OrderHandler, OrderHandler>();
            services.AddScoped<KeyAccessHandler, KeyAccessHandler>();
            services.AddScoped<ITokenService, TokenService>();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                 .AddJwtBearer(x =>
                 {
                     x.RequireHttpsMetadata = false;
                     x.SaveToken = true;
                     x.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(key),
                         ValidateIssuer = false,
                         ValidateAudience = false
                     };
                 });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bills", Version = "v1" });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "docs/swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
            c.SwaggerEndpoint("/docs/swagger/v1/swagger.json", "Bills");
            c.RoutePrefix = "docs/swagger";
            });


            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}