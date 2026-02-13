using Microsoft.AspNetCore.Mvc;
using SmartApprovalSystem.API.Extentions;
using SmartApprovalSystem.API.Middlewares;
using SmartApprovalSystem.Application.Interfaces;
using SmartApprovalSystem.Infrastructure.Data.Seed;
using SmartApprovalSystem.Infrastructure.Extentions;
using SmartApprovalSystem.Infrastructure.ServiceImplementaion;
var builder = WebApplication.CreateBuilder(args);

#region Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddIdentityServices();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IApprovalService, ApprovalService>();
builder.Services.AddScoped<IDataSeeding , IdentityDataSeeder>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContext, UserContext>();
builder.Services.AddValidatorRegister();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddSwaggerDocumentation();
#endregion


#region Configure the HTTP request pipeline.
var app = builder.Build();
Console.WriteLine("CALLING SEED");

await app.AddSeedDataAsync();
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();   
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();


app.MapControllers();

#endregion

app.Run();
