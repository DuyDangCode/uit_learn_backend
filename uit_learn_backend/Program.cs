
using uit_learn_backend.Config;
using uit_learn_backend.Dbs;
using uit_learn_backend.Services;

namespace uit_learn_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection("MongoDb"));

            // Add services to the container.

            builder.Services.AddSingleton<IMongoDbService, MongoDbService>();
            builder.Services.AddSingleton<ISubjectService, SubjectService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }


            app.UseCors();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
