using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();


builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder => {
        builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddOcelot(builder.Configuration);
var app = builder.Build();


app.UseHttpsRedirection();
app.UseCors(devCorsPolicy);
app.UseAuthorization();

app.MapControllers();

await app.UseOcelot();

app.Run();