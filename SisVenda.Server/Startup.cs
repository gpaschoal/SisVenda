using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SisVenda.Domain.Handlers;
using SisVenda.Domain.Repositories;
using SisVenda.Infra.Contexts;
using SisVenda.Infra.Repositories;
using System.Text;

namespace SisVenda.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            string conn = Configuration.GetConnectionString("DefaultConnection");

            services.AddCors();
            services.AddDbContext<SisVendaContext>(opt => opt.UseSqlServer(conn, b => b.MigrationsAssembly("SisVenda.Server")));
            //New Migrations: dotnet ef migrations add NewMigration --project SisVenda.Infra
            services.AddScoped<SisVendaContext, SisVendaContext>();
            services.AddControllers(opt => opt.EnableEndpointRouting = false);

            //Repos
            services.AddTransient<IPeopleRepository, PeopleRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IUnitMeasurementRepository, UnitMeasurementRepository>();

            //Handlers
            services.AddTransient<PeopleHandler, PeopleHandler>();
            services.AddTransient<UnitMeasurementHandler, UnitMeasurementHandler>();

            byte[] key = Encoding.ASCII.GetBytes(Settings.SECRET);
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
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(opt =>
               opt.AllowAnyOrigin() //opt.WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
