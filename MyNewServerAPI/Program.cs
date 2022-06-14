using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyNewServerAPI.Data;
using MyNewServerAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyNewServerAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyNewServerAPIContext") ?? throw new InvalidOperationException("Connection string 'MyNewServerAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow All",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader().AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000")
            .AllowCredentials(); 
        });

});

/*builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyHeader()
                   .AllowAnyMethod()
                   .SetIsOriginAllowed((host) => true)
                   .AllowCredentials();
        }));*/

builder.Services.AddSignalR();
builder.Services.AddRazorPages();
//builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Allow All");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<MyHub>("/MyHub");
});

//app.UseCors("CorsPolicy");


app.MapControllers();

app.Run();
