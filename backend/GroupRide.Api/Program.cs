using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", policy =>
    policy.WithOrigins("http://localhost:5173")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());
});



var app = builder.Build();

app.UseCors("DevCors");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/healthz", () => Results.Ok(new { status = "ok" }));

app.MapGet("/api/hello", () => new { meesage = "Hello World!" })
.WithName("Hello")
.WithTags("Diagnostics");

app.Run();
