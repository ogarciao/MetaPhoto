using MetaPhoto.Dtos;
using MetaPhoto.Interfaces;
using MetaPhoto.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policy =>
        {
            policy.AllowAnyOrigin()
            .WithExposedHeaders("x-total-count");
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IService<Photo>, PhotoService>();
builder.Services.AddScoped<IService<Album>, AlbumService>();
builder.Services.AddScoped<IService<User>, UserService>();

builder.Services.AddScoped<IApiClient<Photo>, ApiClient<Photo>>();
builder.Services.AddScoped<IApiClient<Album>, ApiClient<Album>>();
builder.Services.AddScoped<IApiClient<User>, ApiClient<User>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
