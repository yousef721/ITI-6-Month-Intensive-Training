
using Lap03.Data;
using Lap03.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace Lap03;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddDbContext<ApplicationDbContext>();

        builder.Services.AddIdentity<Employee, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

        #region JWT

        builder.Services.AddAuthentication(option =>{
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(
        //validate token
        op =>
        {
            op.SaveToken = true;
            #region secret key
            string key = "THIS_IS_SUPER_SECRET_KEY_FOR_JWT_12345";
            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            #endregion
            op.TokenValidationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = secretKey,
                ValidateLifetime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                RoleClaimType = ClaimTypes.Role,
                NameClaimType = ClaimTypes.Name
            };
        });

        #endregion


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
