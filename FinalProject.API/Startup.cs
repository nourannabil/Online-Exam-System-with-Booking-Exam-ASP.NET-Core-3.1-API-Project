using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using FinalProject.Core.Service;
using FinalProject.Infra.Common;
using FinalProject.Infra.Repository;
using FinalProject.Infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.API
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
            services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("policy",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                };
            });




            services.AddScoped<IDbContext, DbContext>();

            //For Generic Repository :-            
            services.AddScoped<IGenericRepository<CourseTable2>, CourseRepository>();
            services.AddScoped<IGenericRepository<QuestionBank2>, QuestionBankRepository>();
            services.AddScoped<IGenericRepository<Exam2>, ExamRepository>();
            services.AddScoped<IGenericRepository<AvaliableTable2>, AvailableRepository>();
            services.AddScoped<IGenericRepository<ExamBooking2>, BookingRepository>();
            services.AddScoped<IGenericRepository<VisaTable2>, VisaRepository>();
            services.AddScoped<IGenericRepository<InvoiceTable2>, InvoiceRepository>();
            services.AddScoped<IGenericRepository<ExamCertificate2>, CertificateRepository>();
            services.AddScoped<IGenericRepository<HomeTable2>, HomeRepository>();
            services.AddScoped<IGenericRepository<AboutTable2>, AboutRepository>();
            services.AddScoped<IGenericRepository<ContactUsTable2>, ContactUsRepository>();
            services.AddScoped<IGenericRepository<ContactUsForm2>, ContactFormRepository>();
            services.AddScoped<IGenericRepository<StatusTable2>, StatusRepository>();
            services.AddScoped<IGenericRepository<TestimonialTable2>, TestimonialRepository>();
            services.AddScoped<IGenericRepository<RoleTable2>, RoleRepository>();
            services.AddScoped<IGenericRepository<UserTable2>, UserRepository>();
            services.AddScoped<IGenericRepository<LoginTable2>, LoginRepository>();

            //For Repository :- 
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IQuestionBankRepository, QuestionBankRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingCycleRepository, BookingCycleRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<ICertificateRepository, CertificateRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserInvoiceRepository, UserInvoiceRepository>();
            services.AddScoped<IStatisticsRepository, StatisticsRepository>();
            services.AddScoped<IJWTRepository, JWTRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IAvailableRepository, AvailableRepository>();
            services.AddScoped<IRegisterRepository, RegisterRepository>();


            //////////////////////////////////////////////////////////////////
            //For GenericService :-
            services.AddScoped<IGenericService<CourseTable2>, CourseService>();
            services.AddScoped<IGenericService<QuestionBank2>, QuestionBankService>();
            services.AddScoped<IGenericService<Exam2>, ExamService>();
            services.AddScoped<IGenericService<AvaliableTable2>, AvailableService>();
            services.AddScoped<IGenericService<ExamBooking2>, BookingService>();
            services.AddScoped<IGenericService<VisaTable2>, VisaService>();
            services.AddScoped<IGenericService<InvoiceTable2>, InvoiceService>();
            services.AddScoped<IGenericService<ExamCertificate2>, CertificateService>();
            services.AddScoped<IGenericService<HomeTable2>, HomeService>();
            services.AddScoped<IGenericService<AboutTable2>, AboutService>();
            services.AddScoped<IGenericService<ContactUsTable2>, ContactUsService>();
            services.AddScoped<IGenericService<ContactUsForm2>, ContactFormService>();
            services.AddScoped<IGenericService<StatusTable2>, StatusService>();
            services.AddScoped<IGenericService<TestimonialTable2>, TestimonialService>();
            services.AddScoped<IGenericService<RoleTable2>, RoleService>();
            services.AddScoped<IGenericService<UserTable2>, UserService>();
            services.AddScoped<IGenericService<LoginTable2>, LoginService>();


            //For Service :- 
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IQuestionBankService, QuestionBankService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingCycleService, BookingCycleService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICertificateService, CertificateService>();
            services.AddScoped<ITestimonialService, TestimonialService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserInvoiceService, UserInvoiceService>();
            services.AddScoped<IStatisticsService, StatisticsService>();
            services.AddScoped<IJWTService, JWTService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IAvailableService, AvailableService>();
            services.AddScoped<IRegisterService, RegisterService>();


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseCors("policy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
