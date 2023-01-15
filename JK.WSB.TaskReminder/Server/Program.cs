using JK.WSB.TaskReminder.Server.Data;
using JK.WSB.TaskReminder.Server.Repositories;
using JK.WSB.TaskReminder.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"),
    b => b.MigrationsAssembly("JK.WSB.TaskReminder.Server")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddLogging(config =>
{
    config.AddDebug();
    config.AddConsole();
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IQuestRepository, QuestRepository>();
builder.Services.AddScoped<IStepRepository, StepRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IQuestService, QuestService>();
builder.Services.AddScoped<IStepService, StepService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
