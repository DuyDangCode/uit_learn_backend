
using uit_learn_backend.Config;
using uit_learn_backend.Core;
using uit_learn_backend.Dbs;
using uit_learn_backend.Repos;
using uit_learn_backend.Services;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

{
    builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection("MongoDb"));
    builder.Services.Configure<CloudinaryConfig>(builder.Configuration.GetSection("Cloudinary"));
}

// Add services to the container.
{
    // init db
    builder.Services.AddSingleton<IMongoDbService, MongoDbService>();
    builder.Services.AddSingleton<ICloudinaryService, CloudinaryService>();

    //add service
    builder.Services.AddScoped<ISubjectService, SubjectService>();
    builder.Services.AddScoped<ICourseService, CourseService>();

    //add repo
    builder.Services.AddScoped<IPhotoRepo, PhotoRepo>();
    builder.Services.AddScoped<ISubjectRepo, SubjectRepo>();
    builder.Services.AddScoped<ICourseRepo, CourseRepo>();
}

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<CustomExceptMiddleware>();
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

