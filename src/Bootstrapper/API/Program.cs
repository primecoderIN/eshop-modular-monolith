var builder = WebApplication.CreateBuilder(args);

// Add services and dependencies to the DI container.

//builder.Services.AddControllers();

builder.Services
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCatalogModule()
   .UseOrderingModule()
   .UseBasketModule();


app.Run();
