global using PhonebookContacts.Server.Repositories;
global using Microsoft.EntityFrameworkCore;

using AutoMapper;
using PhonebookContacts.Server;
using Microsoft.AspNetCore.Mvc;
using PhonebookContacts.Data.Response;
using PhonebookContacts.Server.Services.Contacts;

var builder = WebApplication.CreateBuilder(args);

// Entity framework
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// AutoMapper
builder.Services.AddSingleton<IMapper>(sp =>
{
    var config = new MapperConfiguration(cfg => {
        cfg.AddProfile<MapperProfile>();
    });

    return config.CreateMapper();
});


// Services
builder.Services.AddScoped<IContactsService, ContactsService>();


// Swagger/OpenAPI
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(Response), 200));
    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(Response), 404));
    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(Response), 500));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();

    // Swagger/OpenAPI
    app.UseSwagger();
    app.UseSwaggerUI();
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
