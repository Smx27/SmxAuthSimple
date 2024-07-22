using SmxAuthSimple.API.Extensions;
using SmxAuthSimple.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
#if(EnableSwaggerSupport)
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerDocAndApplicationInfo(builder.Configuration);
#endif
builder.Services.AddIdentityServices();
// Here this token is must have please add if not 
builder.Services.AddAuthenticationAndTokenValidation(builder.Configuration.GetValue<string>("JwtToken"));
#if(UseSqlite)
builder.Services.AddSqLiteDatabase(builder.Configuration.GetConnectionString("DefaultConnection"));
#elif (UseSqlServer)
builder.Services.AddSqlServerDatabase(builder.Configuration.GetConnectionString("DefaultConnection"));
#endif
// Please add application dependencies here 
builder.Services.AddApplicationDependencies();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
#if(EnableSwaggerSupport)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint($"/swagger/v1/swagger.json", builder.Configuration["SwaggerOptions:Version"]);
        options.RoutePrefix = "swagger";
    });
    app.MapSwagger();
}
#endif
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
// Adding default data to application like roles and admin user
await app.AddDefaultApplicationData();
app.Run();