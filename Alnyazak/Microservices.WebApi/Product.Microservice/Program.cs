using Product.Microservice.Configrations;
using Newtonsoft.Json.Serialization;
using Shared.Models.Middlewares;
using Product.Microservice.RabbitMQBackground;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
            builder => builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
});
builder.Services.ConfigureMapper();
builder.Services.ConfigureSupervisor();
builder.Services.ConfigureRepository();
builder.Services.ConfigureSQLDatabase(builder.Configuration);
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews().
                AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddHostedService<RabbitMQBackgroundProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(x => x
     .AllowAnyMethod()
     .AllowAnyHeader()
     .SetIsOriginAllowed(origin => true)
     .AllowCredentials());

app.UseMiddleware<ExceptionMiddleware>();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();