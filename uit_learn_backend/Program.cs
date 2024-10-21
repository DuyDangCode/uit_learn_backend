
using uit_learn_backend.Config;
using uit_learn_backend.Dbs;
using uit_learn_backend.Repos;
using uit_learn_backend.Services;


var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection("MongoDb"));
    builder.Services.Configure<CloudinaryConfig>(builder.Configuration.GetSection("Cloudinary"));
}

// Add services to the container.
{
    builder.Services.AddSingleton<IMongoDbService, MongoDbService>();
    builder.Services.AddSingleton<ICloudinaryService, CloudinaryService>();

    builder.Services.AddScoped<ISubjectService, SubjectService>();
    builder.Services.AddScoped<ISubjectRepo, SubjectRepo>();
}

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

