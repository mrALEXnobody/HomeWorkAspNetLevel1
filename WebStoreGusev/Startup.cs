using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebStoreGusev.DAL;
using WebStoreGusev.Infrastructure;
using WebStoreGusev.Infrastructure.Interfaces;
using WebStoreGusev.Infrastructure.Services;

namespace WebStoreGusev
{
    public class Startup
    {
        #region Подключение конструктора принимающего IConfiguration

        /// <summary>
        /// Свойство для доступа к конфигурации.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Конструктор, принимающий интерфейс IConfiguration.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion


        public void ConfigureServices(IServiceCollection services)
        {
            // Подключение MVC
            services.AddMvc();

            #region Глобальные фильтры

            // Подключение фильтра ко всем контроллерам и всем Action-методам.

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(typeof(SampleActionFilter));

            // Aльтернативный вариант подключения

            //options.Filters.Add(new SampleActionFilter());
            //});

            #endregion

            #region Подключение БД

            services.AddDbContext<WebStoreContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            #endregion


            #region Подключаем разрешение зависимости

            // Добавляем разрешение зависимости

            // Методы указывают на время жизни сервиса

            // Singleton - будет жить все время жизни проекта
            services.AddSingleton<IEmployeesService, InMemoryEmployeeService>();
            services.AddSingleton<ICarsService, InMemoryCarService>();
            //services.AddSingleton<IProductService, InMemoryProductService>();
            
            services.AddScoped<IProductService, SqlProductService>();

            // Scoped - время жизни Http запроса
            //services.AddScoped<IEmployeesService, InMemoryEmployeeService>();

            // Transient - пересоздает сервис при каждом запросе
            //services.AddTransient<IEmployeesService, InMemoryEmployeeService>();

            #endregion

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Режим разработчика
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Подключение статических ресурсов.
            app.UseStaticFiles();

            // устанавливать кастомные обработчики
            app.Map("/index", CustomIndexHandler);

            app.UseMiddleware<TokenMiddleware>();

            // Можно прописать логику 
            // "останавливать выполнение запроса или продолжать".
            UseSample(app);

            app.UseRouting();

            #region Настройка маршрутизации MVC

            // Настройка маршрутизации MVC
            app.UseEndpoints(endpoints =>
            {
                // Подключение MVC 3.1
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // Аналогичное подключение MVC
            //app.UseMvcWithDefaultRoute();

            #endregion

            #region Подключение приветственной страницы

            // Подключение приветственной страницы.
            app.UseWelcomePage();
            // Приветственная страница доступна только по адресу /welcome
            //app.UseWelcomePage("/welcome");

            #endregion

            // Run заканчивает обработку запроса
            RunSample(app);
        }

        private void UseSample(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                bool isError = false;
                //...
                if (isError)
                {
                    await context.Response
                        .WriteAsync("Error occured. You're in custom pipline module...");
                }
                else
                {
                    await next.Invoke();
                }
            });
        }

        private void RunSample(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Привет из конвейера обработки запроса (метод app.Run())");
            });
        }

        private void CustomIndexHandler(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Index");
            });
        }
    }
}
