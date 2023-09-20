
using Lab1.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using WebApiProject.DTO;
using WebApiProject.Models;
using WebApiProject.MyHubs;
using WebApiProject.repo;
using WebApiProject.Repository;

namespace WebApiProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
            );
            //builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            //.AddEntityFrameworkStores<Context>()
            //.AddDefaultTokenProviders();
            // Add services to the container.
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength =8;

            }
            ).AddEntityFrameworkStores<Context>();

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                    });
            });
            //var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyAllowSpecificOrigins,
            //                      builder =>
            //                      {
            //                          builder.WithOrigins("http://example.com",
            //                                              "http://localhost:4500/DataProfile");
            //                      });
            //});
            //auth solve not found
            builder.Services.AddAuthorization(options =>
            {

                options.AddPolicy("ApiScope", policy =>
                {

                    policy.RequireAuthenticatedUser();

                    policy.RequireClaim("scope", "api1");

                });

            });
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:ValidIss"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAud"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecrytKey"])),

                };
            });
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET 5 Web API",
                    Description = " ITI Projrcy"
                });
                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },

                        new string[] { }
                    }
                });
            });

            builder.Services.AddScoped<IprofileRepository, ProfileRepository>();
            builder.Services.AddScoped<ISkillRepository, SkillRepository>();
            builder.Services.AddScoped<Ireposatory<Location>, Reposatory<Location>>();
            builder.Services.AddScoped<Ireposatory<Profile>, Reposatory<Profile>>();
            builder.Services.AddScoped<Ireposatory<Job>, Reposatory<Job>>();
            builder.Services.AddScoped<Ireposatory<Category>, Reposatory<Category>>();
            builder.Services.AddScoped<Ireposatory<SavedJobs>, Reposatory<SavedJobs>>();
            builder.Services.AddScoped<Ireposatory<Proposal>, Reposatory<Proposal>>();
            builder.Services.AddScoped<Ireposatory<Hire>, Reposatory<Hire>>();
            builder.Services.AddScoped<IJobHourly, JobHourly>();
            builder.Services.AddScoped<IjobFixedPrice, JobFixedPrice>();
            builder.Services.AddScoped<Ijobing, jobing>();
            builder.Services.AddScoped<IRepository<Job>, JobRepository<Job>>();
            builder.Services.AddScoped<IRepository<JobDTO>, JobRepository<JobDTO>>();
            builder.Services.AddScoped<IRepository<Proposal>, JobRepository<Proposal>>();
            builder.Services.AddScoped<IRepository<ProposalDTO>, JobRepository<ProposalDTO>>();
            builder.Services.AddScoped<IRepository<Profile>, JobRepository<Profile>>();

            builder.Services.AddSignalR();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();
            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.MapHub<ChatHub>("/ChatHub");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chat");
            });

            app.MapControllers();

            app.Run();
        }
    }
}