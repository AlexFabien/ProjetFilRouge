using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizApi.quiz;
using QuizApi.Services;
using QuizApi.Repositories;
using QuizApi.Dtos;

namespace QuizApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QUIZ_API", Version = "v1" });
            });

            services.AddTransient<QuizContext, QuizContext>();

            services.AddTransient<IRepository<Acteur>, ActeurRepository>();
            services.AddTransient<IService<ActeurDto>, ActeurService>();

            //services.AddTransient<IRepository<ActeurHasQuestion>, ActeurHasQuestionRepository>();
            //services.AddTransient<IService<ActeurHasQuestionDto>, ActeurHasQuestionService>();

            //services.AddTransient<IRepository<ActeurHasQuiz>, ActeurHasQuizRepository>();
            //services.AddTransient<IService<ActeurHasQuizDto>, ActeurHasQuizService>();

            services.AddTransient<IRepository<Niveau>, NiveauRepository>();
            services.AddTransient<IService<NiveauDto>, NiveauService>();

            services.AddTransient<IRepository<Parametrage>, ParametrageRepository>();
            services.AddTransient<IService<ParametrageDto>, ParametrageService>();

            services.AddTransient<QuestionRepository, QuestionRepository>();
            //services.AddTransient<IService<QuestionDto>, QuestionService>();

            services.AddTransient<QuizRepository, QuizRepository>();
            services.AddTransient<IService<QuizDto>, QuizService>();
            services.AddTransient<QuestionService, QuestionService>();
            services.AddTransient<VentillationRepository, VentillationRepository>();

            services.AddTransient<IRepository<Repondu>, ReponduRepository>();
            services.AddTransient<IService<ReponduDto>, ReponduService>();

            services.AddTransient<IRepository<Reponse>, ReponseRepository>();
            services.AddTransient<IService<ReponseDto>, ReponseService>();

            services.AddTransient<IRepository<ReponseCandidat>, ReponseCandidatRepository>();
            services.AddTransient<IService<ReponseCandidatDto>, ReponseCandidatService>();

            services.AddTransient<IRepository<Role>, RoleRepository>();
            services.AddTransient<IService<RoleDto>, RoleService>();

            services.AddTransient<IRepository<Technologie>, TechnologieRepository>();
            services.AddTransient<IService<TechnologieDto>, TechnologieService>();


            //services.AddTransient<IRepository<TypeQuestion>, TypeQuestionRepository>();
            //services.AddTransient<IService<TypeQuestionDto>, TypeQuestionService>();

            //services.AddTransient<IRepository<Ventillation>, VentillationRepository>();
            //services.AddTransient<IService<VentillationDto>, VentillationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QUIZ_API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseBrowserLink();
        }
    }
}
