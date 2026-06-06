using EuroTrans.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<HospitalManager>();
builder.Services.AddScoped<PatientManager>();
builder.Services.AddScoped<HeartManager>();
builder.Services.AddScoped<ExtendedMatcher>();
builder.Services.AddScoped<CandidateManager>();
// Add services to the container.

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
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
