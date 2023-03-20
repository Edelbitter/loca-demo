using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var supportedCultures = new[] { "fr", "en" };

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultureInfos = supportedCultures.Select(c => new CultureInfo(c)).ToArray();

    options.DefaultRequestCulture = new RequestCulture(
        culture: supportedCultures[0],
        uiCulture: supportedCultures[0]
    );
    options.SupportedCultures = supportedCultureInfos;
    options.SupportedUICultures = supportedCultureInfos;

    options.AddInitialRequestCultureProvider(
        new CustomRequestCultureProvider(async context =>
        {
            return await Task.FromResult(new ProviderCultureResult(supportedCultures[0]));
        })
    );
});

builder.Services.AddLocalization(o => o.ResourcesPath = "Resources");

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

app.UseRequestLocalization();

app.UseAuthorization();

app.MapControllers();

app.Run();
